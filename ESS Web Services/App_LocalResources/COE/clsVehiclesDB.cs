using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ESS_Web_Services
{
    public class clsVehiclesDB : IDisposable
    {
        private System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection();
        private System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
        private int _ID = 0;
        private string _Reference = string.Empty;
        private string _Make = string.Empty;
        private bool _Resource = false;
        private string _Registration = string.Empty;
        private string _Status = string.Empty;
        private string _Crew = string.Empty;
        private int _Kilometres = 0;
        private string _Remarks = string.Empty;
        private string _NewCrew = string.Empty;
        private double _LastLat = 0d;
        private double _LastLon = 0d;
        private bool _Deleted = false;
        private string _Cellphone = string.Empty;
        private DateTime _LastStatusDate = DateAndTime.DateAdd(DateInterval.Year, -100, DateAndTime.Now);
        private string _TrackingId = string.Empty;
        private int _TrackingSpeed = 0;
        private string _TrackingDirection = string.Empty;
        private string _TrackingDatetime = string.Empty;
        private string _TrackingStatus = string.Empty;
        private string _Year = string.Empty;
        private DateTime _LicenseExpiry = DateAndTime.DateAdd(DateInterval.Year, -100, DateAndTime.Now);
        private string _Type = string.Empty;
        private string _RadioNumber = string.Empty;
        private string _RadioNetwork = string.Empty;
        private string _BellCode = string.Empty;
        private string _BayNumber = string.Empty;
        private bool _MobileTimes = false;
        private bool _MdtInstalled = false;
        private string _MdtMessage = string.Empty;
        private string _FleetNumber = string.Empty;
        private string _CallNumbers = string.Empty;
        private string _VehicleValue = string.Empty;
        private string _PurchaseDate = string.Empty;
        private string _LevelOfCare = string.Empty;
        private string _Skills = string.Empty;
        private string _PagerType = string.Empty;
        private int _CategoryId = 0;
        private int _ServiceIntervalKms = 0;
        private int _ServiceIntervalWeeks = 0;
        private int _StationId = 0;
        private int _LicenseTypeId = 0;
        private int _ChargeCategoryId = 0;
        private string _LicenseType = string.Empty;
        private int _TempStationId = 0;
        private int _RequiredCrew = 0;
        private int _MinimumCrew = 0;
        private string _DeliveryDate = string.Empty;
        private string _EngineNumber = string.Empty;
        private string _VinNumber = string.Empty;
        private string _Model = string.Empty;
        private string _Comments = string.Empty;
        private string _Station = string.Empty;
        private string _AssetNumber = string.Empty;

        public virtual void Dispose()
        {
            cn.Close();
            sqlCommand.Dispose();
        }

        public clsVehiclesDB()
        {
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["essConnectionString"].ToString();
            cn.Open();
            sqlCommand.Connection = cn;
        }

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        public string Station
        {
            get
            {
                return _Station;
            }

            set
            {
                _Station = value;
            }
        }

        public string Reference
        {
            get
            {
                return _Reference;
            }

            set
            {
                _Reference = value;
            }
        }

        public string Make
        {
            get
            {
                return _Make;
            }

            set
            {
                _Make = value;
            }
        }

        public bool Resource
        {
            get
            {
                return _Resource;
            }

            set
            {
                _Resource = value;
            }
        }

        public string Registration
        {
            get
            {
                return _Registration;
            }

            set
            {
                _Registration = value;
            }
        }

        public string Status
        {
            get
            {
                return _Status;
            }

            set
            {
                _Status = value;
            }
        }

        public string Crew
        {
            get
            {
                return _Crew;
            }

            set
            {
                _Crew = value;
            }
        }

        public int Kilometres
        {
            get
            {
                return _Kilometres;
            }

            set
            {
                _Kilometres = value;
            }
        }

        public string Remarks
        {
            get
            {
                return _Remarks;
            }

            set
            {
                _Remarks = value;
            }
        }

        public string NewCrew
        {
            get
            {
                return _NewCrew;
            }

            set
            {
                _NewCrew = value;
            }
        }

        public double LastLat
        {
            get
            {
                return _LastLat;
            }

            set
            {
                _LastLat = value;
            }
        }

        public double LastLon
        {
            get
            {
                return _LastLon;
            }

            set
            {
                _LastLon = value;
            }
        }

        public bool Deleted
        {
            get
            {
                return _Deleted;
            }

            set
            {
                _Deleted = value;
            }
        }

        public string Cellphone
        {
            get
            {
                return _Cellphone;
            }

            set
            {
                _Cellphone = value;
            }
        }

        public DateTime LastStatusDate
        {
            get
            {
                return _LastStatusDate;
            }

            set
            {
                _LastStatusDate = value;
            }
        }

        public string TrackingId
        {
            get
            {
                return _TrackingId;
            }

            set
            {
                _TrackingId = value;
            }
        }

        public int TrackingSpeed
        {
            get
            {
                return _TrackingSpeed;
            }

            set
            {
                _TrackingSpeed = value;
            }
        }

        public string TrackingDirection
        {
            get
            {
                return _TrackingDirection;
            }

            set
            {
                _TrackingDirection = value;
            }
        }

        public string TrackingDatetime
        {
            get
            {
                return _TrackingDatetime;
            }

            set
            {
                _TrackingDatetime = value;
            }
        }

        public string TrackingStatus
        {
            get
            {
                return _TrackingStatus;
            }

            set
            {
                _TrackingStatus = value;
            }
        }

        public string Year
        {
            get
            {
                return _Year;
            }

            set
            {
                _Year = value;
            }
        }

        public DateTime LicenseExpiry
        {
            get
            {
                return _LicenseExpiry;
            }

            set
            {
                _LicenseExpiry = value;
            }
        }

        public string Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }

        public string RadioNumber
        {
            get
            {
                return _RadioNumber;
            }

            set
            {
                _RadioNumber = value;
            }
        }

        public string RadioNetwork
        {
            get
            {
                return _RadioNetwork;
            }

            set
            {
                _RadioNetwork = value;
            }
        }

        public string BellCode
        {
            get
            {
                return _BellCode;
            }

            set
            {
                _BellCode = value;
            }
        }

        public string BayNumber
        {
            get
            {
                return _BayNumber;
            }

            set
            {
                _BayNumber = value;
            }
        }

        public bool MobileTimes
        {
            get
            {
                return _MobileTimes;
            }

            set
            {
                _MobileTimes = value;
            }
        }

        public bool MdtInstalled
        {
            get
            {
                return _MdtInstalled;
            }

            set
            {
                _MdtInstalled = value;
            }
        }

        public string MdtMessage
        {
            get
            {
                return _MdtMessage;
            }

            set
            {
                _MdtMessage = value;
            }
        }

        public string FleetNumber
        {
            get
            {
                return _FleetNumber;
            }

            set
            {
                _FleetNumber = value;
            }
        }

        public string CallNumbers
        {
            get
            {
                return _CallNumbers;
            }

            set
            {
                _CallNumbers = value;
            }
        }

        public string VehicleValue
        {
            get
            {
                return _VehicleValue;
            }

            set
            {
                _VehicleValue = value;
            }
        }

        public string PurchaseDate
        {
            get
            {
                return _PurchaseDate;
            }

            set
            {
                _PurchaseDate = value;
            }
        }

        public string LevelOfCare
        {
            get
            {
                return _LevelOfCare;
            }

            set
            {
                _LevelOfCare = value;
            }
        }

        public string Skills
        {
            get
            {
                return _Skills;
            }

            set
            {
                _Skills = value;
            }
        }

        public string PagerType
        {
            get
            {
                return _PagerType;
            }

            set
            {
                _PagerType = value;
            }
        }

        public int CategoryId
        {
            get
            {
                return _CategoryId;
            }

            set
            {
                _CategoryId = value;
            }
        }

        public int ServiceIntervalKms
        {
            get
            {
                return _ServiceIntervalKms;
            }

            set
            {
                _ServiceIntervalKms = value;
            }
        }

        public int ServiceIntervalWeeks
        {
            get
            {
                return _ServiceIntervalWeeks;
            }

            set
            {
                _ServiceIntervalWeeks = value;
            }
        }

        public int StationId
        {
            get
            {
                return _StationId;
            }

            set
            {
                _StationId = value;
            }
        }

        public int LicenseTypeId
        {
            get
            {
                return _LicenseTypeId;
            }

            set
            {
                _LicenseTypeId = value;
            }
        }

        public int ChargeCategoryId
        {
            get
            {
                return _ChargeCategoryId;
            }

            set
            {
                _ChargeCategoryId = value;
            }
        }

        public string LicenseType
        {
            get
            {
                return _LicenseType;
            }

            set
            {
                _LicenseType = value;
            }
        }

        public int TempStationId
        {
            get
            {
                return _TempStationId;
            }

            set
            {
                _TempStationId = value;
            }
        }

        public int RequiredCrew
        {
            get
            {
                return _RequiredCrew;
            }

            set
            {
                _RequiredCrew = value;
            }
        }

        public int MinimumCrew
        {
            get
            {
                return _MinimumCrew;
            }

            set
            {
                _MinimumCrew = value;
            }
        }

        public string DeliveryDate
        {
            get
            {
                return _DeliveryDate;
            }

            set
            {
                _DeliveryDate = value;
            }
        }

        public string EngineNumber
        {
            get
            {
                return _EngineNumber;
            }

            set
            {
                _EngineNumber = value;
            }
        }

        public string VinNumber
        {
            get
            {
                return _VinNumber;
            }

            set
            {
                _VinNumber = value;
            }
        }

        public string Model
        {
            get
            {
                return _Model;
            }

            set
            {
                _Model = value;
            }
        }

        public string Comments
        {
            get
            {
                return _Comments;
            }

            set
            {
                _Comments = value;
            }
        }

        public string AssetNumber
        {
            get
            {
                return _AssetNumber;
            }

            set
            {
                _AssetNumber = value;
            }
        }

        public string GetItem(int intId)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", intId);
            sqlCommand.CommandText = "SELECT VEHICLES.*,STATIONS.Code FROM VEHICLES LEFT JOIN STATIONS ON STATIONS.id = VEHICLES.station_id WHERE VEHICLES.id = @id";
            return ReadItem();
        }

        public string ReadItem()
        {
            System.Data.SqlClient.SqlDataReader myReader;
            myReader = sqlCommand.ExecuteReader();
            myReader.Read();
            try
            {
                if (myReader.HasRows)
                {
                    _ID = Conversions.ToInteger(myReader["id"]);
                    _Reference = myReader["Reference"].ToString();
                    _Make = myReader["Make"].ToString();
                    _Resource = Conversions.ToBoolean(myReader["Resource"]);
                    _Registration = myReader["Registration"].ToString();
                    _Status = myReader["Status"].ToString();
                    _Crew = myReader["Crew"].ToString();
                    _Kilometres = Conversions.ToInteger(myReader["Kilometres"]);
                    _Remarks = myReader["Remarks"].ToString();
                    _NewCrew = myReader["New_Crew"].ToString();
                    if (!string.IsNullOrEmpty(myReader["last_lat"].ToString()))
                        _LastLat = Conversions.ToDouble(myReader["Last_Lat"]);
                    if (!string.IsNullOrEmpty(myReader["last_lon"].ToString()))
                        _LastLon = Conversions.ToDouble(myReader["Last_Lon"]);
                    _Deleted = Conversions.ToBoolean(myReader["deleted"]);
                    _Cellphone = myReader["cellphone"].ToString();
                    _LastStatusDate = Conversions.ToDate(myReader["last_status_date"]);
                    _TrackingId = myReader["Tracking_ID"].ToString();
                    _TrackingSpeed = Conversions.ToInteger(myReader["Tracking_Speed"]);
                    _TrackingDirection = myReader["Tracking_Direction"].ToString();
                    _TrackingDatetime = myReader["Tracking_DateTime"].ToString();
                    _TrackingStatus = myReader["Tracking_Status"].ToString();
                    _Year = myReader["Year"].ToString();
                    _LicenseExpiry = Conversions.ToDate(myReader["License_Expiry"]);
                    _Type = myReader["Type"].ToString();
                    _RadioNumber = myReader["Radio_Number"].ToString();
                    _RadioNetwork = myReader["Radio_Network"].ToString();
                    _BellCode = myReader["Bell_Code"].ToString();
                    _BayNumber = myReader["Bay_Number"].ToString();
                    _MobileTimes = Conversions.ToBoolean(myReader["mobile_times"]);
                    _MdtInstalled = Conversions.ToBoolean(myReader["MDT_installed"]);
                    _MdtMessage = myReader["MDT_Message"].ToString();
                    _FleetNumber = myReader["fleet_number"].ToString();
                    _CallNumbers = myReader["call_numbers"].ToString();
                    _VehicleValue = myReader["vehicle_value"].ToString();
                    _PurchaseDate = myReader["purchase_date"].ToString();
                    _LevelOfCare = myReader["level_of_care"].ToString();
                    _Skills = myReader["skills"].ToString();
                    _PagerType = myReader["pager_type"].ToString();
                    _CategoryId = Conversions.ToInteger(myReader["category_id"]);
                    _ServiceIntervalKms = Conversions.ToInteger(myReader["service_interval_kms"]);
                    _ServiceIntervalWeeks = Conversions.ToInteger(myReader["service_interval_weeks"]);
                    _StationId = Conversions.ToInteger(myReader["station_id"]);
                    _LicenseTypeId = Conversions.ToInteger(myReader["license_type_id"]);
                    _ChargeCategoryId = Conversions.ToInteger(myReader["Charge_category_id"]);
                    _LicenseType = myReader["license_type"].ToString();
                    _TempStationId = Conversions.ToInteger(myReader["temp_station_id"]);
                    _RequiredCrew = Conversions.ToInteger(myReader["required_crew"]);
                    _MinimumCrew = Conversions.ToInteger(myReader["minimum_crew"]);
                    _DeliveryDate = myReader["Delivery_Date"].ToString();
                    _EngineNumber = myReader["Engine_Number"].ToString();
                    _VinNumber = myReader["Vin_Number"].ToString();
                    _Model = myReader["Model"].ToString();
                    _Comments = myReader["Comments"].ToString();
                    _Station = myReader["code"].ToString(); // from stations table
                    _AssetNumber = myReader["asset_Number"].ToString();
                }
            }
            catch (Exception ex)
            {
                if (!myReader.IsClosed)
                    myReader.Close();
                // Dim rmclass As New RMClass
                // rmclass.LogError("dbvehicles", "getitem", ex, sqlCommand.CommandText)
                // rmclass.Dispose()
                return ex.Message;
            }

            myReader.Close();
            return "";
        }

        public string Save(int intId)
        {
            if (string.IsNullOrEmpty(_Reference.ToString()))
            {
                Page page = HttpContext.Current.Handler as Page;
                // File.AppendAllText(HttpContext.Current.Server.MapPath("~/temp/iain.txt"), "Vehicle Reference is null. From " & page.Title & " " & HttpContext.Current.Session("username") & vbCrLf)
                return "Error reference is null";
            }

            System.Data.SqlClient.SqlDataReader myReader;
            bool isItemFound = false;
            if (intId == 0)
            {
                return Insert();
            }

            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", intId);
            sqlCommand.CommandText = "SELECT ID FROM vehicles WHERE id = @id";
            myReader = sqlCommand.ExecuteReader();
            myReader.Read();
            if (myReader.HasRows)
                isItemFound = true;
            myReader.Close();
            if (isItemFound)
            {
                return Update(intId);
            }
            else
            {
                return Insert();
            }
        }

        private string Insert()
        {
            try
            {
                sqlCommand.CommandText = "INSERT INTO vehicles (Reference,Make,Resource,Registration,Status,Crew,Kilometres,Remarks,New_Crew,Last_Lat,Last_Lon,deleted,cellphone,last_status_date,Tracking_ID,Tracking_Speed,Tracking_Direction,Tracking_DateTime,Tracking_Status,Year,License_Expiry,Type,Radio_Number,Radio_Network,Bell_Code,Bay_Number,mobile_times,MDT_installed,MDT_Message,fleet_number,call_numbers,vehicle_value,purchase_date,level_of_care,skills,pager_type,category_id,service_interval_kms,service_interval_weeks,station_id,license_type_id,Charge_category_id,license_type,temp_station_id,required_crew,minimum_crew,Delivery_Date,Engine_Number,Vin_Number,Model,Comments,asset_number) VALUES (" + "@Reference,@Make,@Resource,@Registration,@Status,@Crew,@Kilometres,@Remarks,@NewCrew,@LastLat,@LastLon,@Deleted,@Cellphone,@LastStatusDate,@TrackingId,@TrackingSpeed,@TrackingDirection,@TrackingDatetime,@TrackingStatus,@Year,@LicenseExpiry,@Type,@RadioNumber,@RadioNetwork,@BellCode,@BayNumber,@MobileTimes,@MdtInstalled,@MdtMessage,@FleetNumber,@CallNumbers,@VehicleValue,@PurchaseDate,@LevelOfCare,@Skills,@PagerType,@CategoryId,@ServiceIntervalKms,@ServiceIntervalWeeks,@StationId,@LicenseTypeId,@ChargeCategoryId,@LicenseType,@TempStationId,@RequiredCrew,@MinimumCrew,@DeliveryDate,@EngineNumber,@VinNumber,@Model,@Comments,@AssetNumber)";
                this.SetParameters();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Dim rmclass As New RMClass
                // rmclass.LogError("dbvehicles", "insert", ex, sqlCommand.CommandText)
                // rmclass.Dispose()
                return ex.Message;
            }

            return "";
        }

        private string Update(int intId)
        {
            try
            {
                sqlCommand.CommandText = "UPDATE vehicles SET " + "Reference = @Reference," + "Make = @Make," + "Resource = @Resource," + "Registration = @Registration," + "Status = @Status," + "Crew = @Crew," + "Kilometres = @Kilometres," + "Remarks = @Remarks," + "New_Crew = @NewCrew," + "Last_Lat = @LastLat," + "Last_Lon = @LastLon," + "deleted = @Deleted," + "cellphone = @Cellphone," + "last_status_date = @LastStatusDate," + "Tracking_ID = @TrackingId," + "Tracking_Speed = @TrackingSpeed," + "Tracking_Direction = @TrackingDirection," + "Tracking_DateTime = @TrackingDatetime," + "Tracking_Status = @TrackingStatus," + "Year = @Year," + "License_Expiry = @LicenseExpiry," + "Type = @Type," + "Radio_Number = @RadioNumber," + "Radio_Network = @RadioNetwork," + "Bell_Code = @BellCode," + "Bay_Number = @BayNumber," + "mobile_times = @MobileTimes," + "MDT_installed = @MdtInstalled," + "MDT_Message = @MdtMessage," + "fleet_number = @FleetNumber," + "call_numbers = @CallNumbers," + "vehicle_value = @VehicleValue," + "purchase_date = @PurchaseDate," + "level_of_care = @LevelOfCare," + "skills = @Skills," + "pager_type = @PagerType," + "category_id = @CategoryId," + "service_interval_kms = @ServiceIntervalKms," + "service_interval_weeks = @ServiceIntervalWeeks," + "station_id = @StationId," + "license_type_id = @LicenseTypeId," + "Charge_category_id = @ChargeCategoryId," + "license_type = @LicenseType," + "temp_station_id = @TempStationId," + "required_crew = @RequiredCrew," + "minimum_crew = @MinimumCrew," + "Delivery_Date = @DeliveryDate," + "Engine_Number = @EngineNumber," + "Vin_Number = @VinNumber," + "Model = @Model," + "Comments = @Comments," + "Asset_Number = @AssetNumber " + "WHERE id = @id";




















































                this.SetParameters();
                sqlCommand.Parameters.AddWithValue("@ID", intId);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Dim rmclass As New RMClass
                // rmclass.LogError("dbvehicles", "update", ex, sqlCommand.CommandText)
                // rmclass.Dispose()
                return ex.Message;
            }

            return "";
        }

        public void Delete(int intId)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", intId);
            sqlCommand.CommandText = "DELETE FROM vehicles WHERE ID = @ID";
            sqlCommand.ExecuteNonQuery();
        }

        public int GetLastid()
        {
            System.Data.SqlClient.SqlDataReader Myreader;
            int Newid;
            sqlCommand.CommandText = "SELECT @@IDENTITY as Newid";
            Myreader = sqlCommand.ExecuteReader();
            Myreader.Read();
            Newid = Conversions.ToInteger(Myreader["NewID"]);
            Myreader.Close();
            return Newid;
        }

        private void SetParameters() {
            sqlCommand.Parameters.Clear();
       sqlCommand.Parameters.AddWithValue("@Reference", _Reference);
            sqlCommand.Parameters.AddWithValue("@Make", _Make);
            sqlCommand.Parameters.AddWithValue("@Resource", _Resource);
            sqlCommand.Parameters.AddWithValue("@Registration", _Registration);
            sqlCommand.Parameters.AddWithValue("@Status", _Status);
            sqlCommand.Parameters.AddWithValue("@Crew", _Crew);
            sqlCommand.Parameters.AddWithValue("@Kilometres", _Kilometres);
            sqlCommand.Parameters.AddWithValue("@Remarks", _Remarks);
            sqlCommand.Parameters.AddWithValue("@NewCrew", _NewCrew);
            sqlCommand.Parameters.AddWithValue("@LastLat", _LastLat);
            sqlCommand.Parameters.AddWithValue("@LastLon", _LastLon);
            sqlCommand.Parameters.AddWithValue("@Deleted", _Deleted);
            sqlCommand.Parameters.AddWithValue("@Cellphone", _Cellphone);
            sqlCommand.Parameters.AddWithValue("@LastStatusDate", _LastStatusDate);
            sqlCommand.Parameters.AddWithValue("@TrackingId", _TrackingId);
            sqlCommand.Parameters.AddWithValue("@TrackingSpeed", _TrackingSpeed);
            sqlCommand.Parameters.AddWithValue("@TrackingDirection", _TrackingDirection);
            sqlCommand.Parameters.AddWithValue("@TrackingDatetime", _TrackingDatetime);
            sqlCommand.Parameters.AddWithValue("@TrackingStatus", _TrackingStatus);
            sqlCommand.Parameters.AddWithValue("@Year", _Year);
            sqlCommand.Parameters.AddWithValue("@LicenseExpiry", _LicenseExpiry);
            sqlCommand.Parameters.AddWithValue("@Type", _Type);
            sqlCommand.Parameters.AddWithValue("@RadioNumber", _RadioNumber);
            sqlCommand.Parameters.AddWithValue("@RadioNetwork", _RadioNetwork);
            sqlCommand.Parameters.AddWithValue("@BellCode", _BellCode);
            sqlCommand.Parameters.AddWithValue("@BayNumber", _BayNumber);
            sqlCommand.Parameters.AddWithValue("@MobileTimes", _MobileTimes);
            sqlCommand.Parameters.AddWithValue("@MdtInstalled", _MdtInstalled);
            sqlCommand.Parameters.AddWithValue("@MdtMessage", _MdtMessage);
            sqlCommand.Parameters.AddWithValue("@FleetNumber", _FleetNumber);
            sqlCommand.Parameters.AddWithValue("@CallNumbers", _CallNumbers);
            sqlCommand.Parameters.AddWithValue("@VehicleValue", _VehicleValue);
            sqlCommand.Parameters.AddWithValue("@PurchaseDate", _PurchaseDate);
            sqlCommand.Parameters.AddWithValue("@LevelOfCare", _LevelOfCare);
            sqlCommand.Parameters.AddWithValue("@Skills", _Skills);
            sqlCommand.Parameters.AddWithValue("@PagerType", _PagerType);
            sqlCommand.Parameters.AddWithValue("@CategoryId", _CategoryId);
            sqlCommand.Parameters.AddWithValue("@ServiceIntervalKms", _ServiceIntervalKms);
            sqlCommand.Parameters.AddWithValue("@ServiceIntervalWeeks", _ServiceIntervalWeeks);
            sqlCommand.Parameters.AddWithValue("@StationId", _StationId);
            sqlCommand.Parameters.AddWithValue("@LicenseTypeId", _LicenseTypeId);
            sqlCommand.Parameters.AddWithValue("@ChargeCategoryId", _ChargeCategoryId);
            sqlCommand.Parameters.AddWithValue("@LicenseType", _LicenseType);
            sqlCommand.Parameters.AddWithValue("@TempStationId", _TempStationId);
            sqlCommand.Parameters.AddWithValue("@RequiredCrew", _RequiredCrew);
            sqlCommand.Parameters.AddWithValue("@MinimumCrew", _MinimumCrew);
            sqlCommand.Parameters.AddWithValue("@DeliveryDate", _DeliveryDate);
            sqlCommand.Parameters.AddWithValue("@EngineNumber", _EngineNumber);
            sqlCommand.Parameters.AddWithValue("@VinNumber", _VinNumber);
       sqlCommand.Parameters.AddWithValue("@Model", _Model);
            sqlCommand.Parameters.AddWithValue("@Comments", _Comments);
            sqlCommand.Parameters.AddWithValue("@AssetNumber", _AssetNumber);

               foreach (System.Data.SqlClient.SqlParameter _SqlParameter in sqlCommand.Parameters)
            {
                if (_SqlParameter.Value is null)
                {
                    _SqlParameter.Value = DBNull.Value;
                }
            }
        }
        public string GetItemByAssetNo(ref string assetNo)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@AssetNo", assetNo);
            sqlCommand.CommandText = "SELECT * FROM VEHICLES  WHERE Asset_Number = @AssetNo AND VEHICLES.deleted <> 1";
            return ReadItem();
        }
    }
}