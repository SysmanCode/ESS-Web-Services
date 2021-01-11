using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;
using log4net;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace ESS_Web_Services
{

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    [ScriptService()]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class EssService : WebService
    {
        private System.Data.SqlClient.SqlConnection Cn = new System.Data.SqlClient.SqlConnection();
        private System.Data.SqlClient.SqlCommand SqlCommand = new System.Data.SqlClient.SqlCommand();
        private ILog log = LogManager.GetLogger("");

        [WebMethod()]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod()]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void TestSub(string IncNum, string Status)
        {
            log.Info(IncNum + " " + Status);
        }

        [WebMethod()]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void SearchIncidents(string StartDate, string EndDate, string Category, string Status, string key)
        {
            OpenConnection();
            if (!CheckKey(key))
            {
                CloseConnection();
                return;
            }

            var SqlQuery = new StringBuilder();
            bool isDate = false;
            bool isCategory = false;
            SqlQuery.Append("SELECT TOP 100 call_num FROM CALLS");
            if (!string.IsNullOrEmpty(StartDate) & !string.IsNullOrEmpty(EndDate))
            {
                isDate = true;
                SqlQuery.Append(" WHERE dateTime between '" + StartDate + "' AND '" + EndDate + "'");
            }

            if (!string.IsNullOrEmpty(Category))
            {
                isCategory = true;
                if (isDate)
                {
                    SqlQuery.Append(" AND Category = '" + Category + "'");
                }
                else
                {
                    SqlQuery.Append(" WHERE Category = '" + Category + "'");
                }
            }

            if (!string.IsNullOrEmpty(Status))
            {
                if (isDate | isCategory)
                {
                    SqlQuery.Append(" AND Status = '" + Status + "'");
                }
                else
                {
                    SqlQuery.Append(" WHERE Status = '" + Status + "'");
                }
            }

            SqlQuery.Append(" ORDER BY ID DESC");
            var IncidentList = new List<clsServiceCallsList.IncidentList>();
            var dbCall = new dbcalls();
            var dbStats = new dbCallStats();
            System.Data.SqlClient.SqlDataReader myReader;
            SqlCommand.CommandText = SqlQuery.ToString();
            // log.Info(SqlQuery.ToString)
            myReader = SqlCommand.ExecuteReader();
            while (myReader.Read())
            {
                dbCall.GetItem(myReader["call_num"].ToString());
                dbStats.GetItem(myReader["call_num"].ToString());
                var Vehicles = new List<clsServiceCallsList.VehicleList>();
                Vehicles = dbCall.GetVehiclesList(myReader["call_num"].ToString());
                var incident = new clsServiceCallsList.IncidentList()
                {
                    IncidentNumber = dbCall.CallNum,
                    Datetime = dbCall.Datetime,
                    Priority = GetPriority(dbCall.PriorityId),
                    Category = dbCall.Category,
                    SubCategory = dbCall.Subcategory,
                    Location = dbCall.Location,
                    LocationNumber = dbCall.LocationNumber,
                    Floor = dbCall.Floor,
                    LocationTelelephone = dbCall.LocationTel,
                    Complex = dbCall.Complex,
                    Poi = dbCall.Poi,
                    Street = dbCall.Street,
                    StreetNumber = dbCall.StreetNum,
                    Suburb = dbCall.Suburb,
                    Town = dbCall.Town,
                    Xroad = dbCall.Xroad,
                    Province = dbCall.Province,
                    Latitude = dbCall.Latitude,
                    Longitude = dbCall.Longitude,
                    Station = GetStation(dbCall.StationId),
                    Status = dbCall.Status,
                    Vehicles = Vehicles,
                    Statistics = new clsServiceCallsList.StatsList()
                    {
                        CallAcknowledged = dbStats.CallAcknowledged,
                        CallAnswered = dbStats.CallAnswered,
                        CallDespatched = dbStats.CallDespatched,
                        CallTransferred = dbStats.CallTransferred,
                        CallClosed = dbStats.CallClosed,
                        CallTaken = dbStats.CallTaken,
                        VehArrived = dbStats.VehArrived,
                        LastVehLeft = dbStats.LastVehLeft
                    }
                };
                IncidentList.Add(incident);
                log.Info(myReader["call_num"].ToString());
            }

            myReader.Close();
            dbCall.Dispose();
            dbStats.Dispose();
            CloseConnection();
            var ServiceCall = new clsServiceCallsList();
            ServiceCall.ESSIncident = IncidentList;
            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ServiceCall));
        }

        private bool CheckKey(string key)
        {
            bool CheckKeyRet = default;
            CheckKeyRet = true;
            var dbServiceSites = new dbServiceSites();
            dbServiceSites.GetSitebyKey(ref key);
            if (dbServiceSites.ID < 1)
            {
                // key not found
                var ServiceCallErr = new clsServiceCalls()
                {
                    ESSIncident = new clsServiceCalls.IncidentList()
                    {
                        IncidentNumber = "",
                        ErrorDescription = "key not found"
                    }
                };
                dbServiceSites.Dispose();
                Context.Response.ContentType = "application/json; charset=utf-8";
                Context.Response.Write(JsonConvert.SerializeObject(ServiceCallErr));
                CheckKeyRet = false;
            }

            dbServiceSites.Dispose();
            return CheckKeyRet;
        }

        [WebMethod()]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetIncident(string IncNum, string key)
        {
            OpenConnection();
            if (!CheckKey(key))
            {
                CloseConnection();
                return;
            }
            // 
            var Vehicles = new List<clsServiceCalls.VehicleList>();
            var dbCall = new dbcalls();
            dbCall.GetItem(IncNum);

            // log.Info(IncNum)

            var dbStats = new dbCallStats();
            dbStats.GetItem(IncNum);
            Vehicles = GetVehicles(IncNum);
            string tempPriority = GetPriority(dbCall.PriorityId);
            string tempStation = GetStation(dbCall.StationId);

            var ServiceCall = new clsServiceCalls()
            {
                ESSIncident = new clsServiceCalls.IncidentList()
                {
                    IncidentNumber = dbCall.CallNum.Substring(0, System.Math.Min(200, dbCall.CallNum.Length)),
                    Datetime = dbCall.Datetime,
                    Priority = tempPriority.Substring(0, System.Math.Min(200, tempPriority.Length)),
                    Category = dbCall.Category.Substring(0, System.Math.Min(200, dbCall.Category.Length)),
                    SubCategory = dbCall.Subcategory.Substring(0, System.Math.Min(200, dbCall.Subcategory.Length)),
                    Location = dbCall.Location.Substring(0, System.Math.Min(200, dbCall.Location.Length)),
                    LocationNumber = dbCall.LocationNumber.Substring(0, System.Math.Min(200, dbCall.LocationNumber.Length)),
                    Floor = dbCall.Floor.Substring(0, System.Math.Min(200, dbCall.Floor.Length)),
                    LocationTelelephone = dbCall.LocationTel.Substring(0, System.Math.Min(200, dbCall.LocationTel.Length)),
                    Complex = dbCall.Floor.Substring(0, System.Math.Min(200, dbCall.Floor.Length)),
                    Poi = dbCall.Poi.Substring(0, System.Math.Min(200, dbCall.Poi.Length)),
                    Street = dbCall.Street.Substring(0, System.Math.Min(200, dbCall.Street.Length)),
                    StreetNumber = dbCall.StreetNum.Substring(0, System.Math.Min(200, dbCall.StreetNum.Length)),
                    Suburb = dbCall.Suburb.Substring(0, System.Math.Min(200, dbCall.Suburb.Length)),
                    Town = dbCall.Town.Substring(0, System.Math.Min(200, dbCall.Town.Length)),
                    Xroad = dbCall.Xroad.Substring(0, System.Math.Min(200, dbCall.Xroad.Length)),
                    Province = dbCall.Province.Substring(0, System.Math.Min(200, dbCall.Province.Length)),
                    Latitude = dbCall.Latitude,
                    Longitude = dbCall.Longitude,
                    Station = tempStation.Substring(0, System.Math.Min(200, tempStation.Length)),
                    Status = dbCall.Status,
                    Vehicles = Vehicles,
                    Statistics = new clsServiceCalls.StatsList()
                    {
                        CallAcknowledged = dbStats.CallAcknowledged,
                        CallAnswered = dbStats.CallAnswered,
                        CallDespatched = dbStats.CallDespatched,
                        CallTransferred = dbStats.CallTransferred,
                        CallClosed = dbStats.CallClosed,
                        CallTaken = dbStats.CallTaken,
                        VehArrived = dbStats.VehArrived,
                        LastVehLeft = dbStats.LastVehLeft
                    }
                }
            };
            dbCall.Dispose();
            dbStats.Dispose();
            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ServiceCall));
            CloseConnection();
        }

        private void OpenConnection()
        {
            Cn.ConnectionString = ConfigurationManager.ConnectionStrings["essconnectionstring"].ToString();
            Cn.Open();
            SqlCommand.Connection = Cn;
        }

        private void CloseConnection()
        {
            SqlCommand.Dispose();
            Cn.Close();
        }

        private string GetPriority(int id)
        {
            string retString = "";
            var dbPriority = new dbPriorities();
            long argid = id;
            dbPriority.GetItem(ref argid);
            retString = dbPriority.Priority;
            dbPriority.Dispose();
            return retString;
        }

        private string GetStation(int id)
        {
            string retString = "";
            var dbStation = new dbStations();
            long argid = id;
            dbStation.GetItem(ref argid);
            retString = dbStation.Code;
            dbStation.Dispose();
            return retString;
        }

        private List<clsServiceCalls.VehicleList> GetVehicles(string IncNum)
        {
            var Vehicles = new List<clsServiceCalls.VehicleList>();
            System.Data.SqlClient.SqlDataReader myReader;
            SqlCommand.CommandText = "SELECT distinct(Reference) FROM CALL_VEHICLES " + "INNER JOIN VEHICLES ON VEHICLES.ID = CALL_VEHICLES.Vehicle_id WHERE Call_Num = '" + IncNum + "'";
            myReader = SqlCommand.ExecuteReader();
            while (myReader.Read())
            {
                var item = new clsServiceCalls.VehicleList();
                item.Reference = myReader["reference"].ToString();
                Vehicles.Add(item);
            }

            myReader.Close();
            return Vehicles;
        }

        [WebMethod()]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetCategoriesList(string key)
        {
            OpenConnection();
            if (!CheckKey(key))
            {
                CloseConnection();
                return;
            }

            var clsCategory = new List<clsCategories.CategoryList>();
            System.Data.SqlClient.SqlDataReader myReader;
            SqlCommand.CommandText = "SELECT id,category FROM CATEGORIES WHERE Deleted <> 1";
            myReader = SqlCommand.ExecuteReader();
            while (myReader.Read())
            {
                var item = new clsCategories.CategoryList();
                item.ID = Conversions.ToInteger(myReader["id"].ToString());
                item.Category = myReader["category"].ToString();
                clsCategory.Add(item);
            }

            myReader.Close();
            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(clsCategory));
            CloseConnection();
        }

        [WebMethod()]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetSubCategoriesList(string key)
        {
            OpenConnection();
            if (!CheckKey(key))
            {
                CloseConnection();
                return;
            }

            var clsSubCategory = new List<clsSubCategories.SubCategoryList>();
            System.Data.SqlClient.SqlDataReader myReader;
            SqlCommand.CommandText = "SELECT category_id,name FROM SUBCATS WHERE Deleted <> 1";
            myReader = SqlCommand.ExecuteReader();
            while (myReader.Read())
            {
                var item = new clsSubCategories.SubCategoryList();
                item.CategoryID = Conversions.ToInteger(myReader["category_id"].ToString());
                item.SubCategory = myReader["name"].ToString();
                clsSubCategory.Add(item);
            }

            myReader.Close();
            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(clsSubCategory));
            CloseConnection();
        }

        [WebMethod()]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetStatusList(string key)
        {
            OpenConnection();
            if (!CheckKey(key))
            {
                CloseConnection();
                return;
            }

            var testlist = new ArrayList();
            System.Data.SqlClient.SqlDataReader myReader;
            SqlCommand.CommandText = "SELECT Status FROM CALLS_STATUS";
            myReader = SqlCommand.ExecuteReader();
            while (myReader.Read())
                testlist.Add(myReader["Status"].ToString());
            myReader.Close();
            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(testlist));
            CloseConnection();
        }
    }
}