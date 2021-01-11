using System;
using System.Configuration;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace ESS_Web_Services
{
    public class dbStations : IDisposable
    {
        private System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection();
        private System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
        private int _ID = 0;
        private string _Code = string.Empty;
        private string _Station = string.Empty;
        private string _Comms = string.Empty;
        private string _BellCode = string.Empty;
        private double _Latitude = 0d;
        private double _Longitude = 0d;
        private string _DespatchPrinter = string.Empty;
        private bool _PrinterActive = false;
        private int _VehiclesMin = 0;
        private int _PersonnelMin = 0;
        private int _Backup1 = 0;
        private int _Backup2 = 0;
        private int _Backup3 = 0;
        private int _Backup4 = 0;
        private int _StnControlType = 0;
        private int _RegionId = 0;
        private bool _Deleted = false;

        public virtual void Dispose()
        {
            cn.Close();
            sqlCommand.Dispose();
        }

        public dbStations()
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

        public string Code
        {
            get
            {
                return _Code;
            }

            set
            {
                _Code = value;
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

        public string Comms
        {
            get
            {
                return _Comms;
            }

            set
            {
                _Comms = value;
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

        public double Latitude
        {
            get
            {
                return _Latitude;
            }

            set
            {
                _Latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return _Longitude;
            }

            set
            {
                _Longitude = value;
            }
        }

        public string DespatchPrinter
        {
            get
            {
                return _DespatchPrinter;
            }

            set
            {
                _DespatchPrinter = value;
            }
        }

        public bool PrinterActive
        {
            get
            {
                return _PrinterActive;
            }

            set
            {
                _PrinterActive = value;
            }
        }

        public int VehiclesMin
        {
            get
            {
                return _VehiclesMin;
            }

            set
            {
                _VehiclesMin = value;
            }
        }

        public int PersonnelMin
        {
            get
            {
                return _PersonnelMin;
            }

            set
            {
                _PersonnelMin = value;
            }
        }

        public int Backup1
        {
            get
            {
                return _Backup1;
            }

            set
            {
                _Backup1 = value;
            }
        }

        public int Backup2
        {
            get
            {
                return _Backup2;
            }

            set
            {
                _Backup2 = value;
            }
        }

        public int Backup3
        {
            get
            {
                return _Backup3;
            }

            set
            {
                _Backup3 = value;
            }
        }

        public int Backup4
        {
            get
            {
                return _Backup4;
            }

            set
            {
                _Backup4 = value;
            }
        }

        public int StnControlType
        {
            get
            {
                return _StnControlType;
            }

            set
            {
                _StnControlType = value;
            }
        }

        public int RegionId
        {
            get
            {
                return _RegionId;
            }

            set
            {
                _RegionId = value;
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

        private string ReadItem()
        {
            System.Data.SqlClient.SqlDataReader myReader;
            myReader = sqlCommand.ExecuteReader();
            myReader.Read();
            try
            {
                if (myReader.HasRows)
                {
                    _ID = Conversions.ToInteger(myReader["id"]);
                    _Code = myReader["Code"].ToString();
                    _Station = myReader["Station"].ToString();
                    _Comms = myReader["Comms"].ToString();
                    _BellCode = myReader["Bell_Code"].ToString();
                    _Latitude = Conversions.ToDouble(myReader["latitude"]);
                    _Longitude = Conversions.ToDouble(myReader["longitude"]);
                    _DespatchPrinter = myReader["despatch_printer"].ToString();
                    _PrinterActive = Conversions.ToBoolean(myReader["printer_active"]);
                    _VehiclesMin = Conversions.ToInteger(myReader["vehicles_min"]);
                    _PersonnelMin = Conversions.ToInteger(myReader["personnel_min"]);
                    _Backup1 = Conversions.ToInteger(myReader["backup_1"]);
                    _Backup2 = Conversions.ToInteger(myReader["backup_2"]);
                    _Backup3 = Conversions.ToInteger(myReader["backup_3"]);
                    _Backup4 = Conversions.ToInteger(myReader["backup_4"]);
                    _StnControlType = Conversions.ToInteger(myReader["stn_control_type"]);
                    _RegionId = Conversions.ToInteger(myReader["region_id"]);
                    _Deleted = Conversions.ToBoolean(myReader["deleted"]);
                }
            }
            catch (Exception ex)
            {
                if (!myReader.IsClosed)
                    myReader.Close();
                // Dim rmclass As New RMClass
                // rmclass.LogError("dbStations", "getitem", ex, sqlCommand.CommandText)
                // rmclass.dispose()
                return ex.Message;
            }

            myReader.Close();
            return "";
        }

        public string GetItem(ref long id)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlCommand.CommandText = "SELECT * FROM Stations WHERE id = @id";
            return ReadItem();
        }

        public string GetItemByCode(ref string strCode)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@Code", strCode);
            sqlCommand.CommandText = "SELECT * FROM Stations WHERE code = @Code";
            return ReadItem();
        }

        public string Save(long id)
        {
            System.Data.SqlClient.SqlDataReader myReader;
            bool isItemFound = false;
            if (id == 0L)
            {
                return Insert();
            }

            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlCommand.CommandText = "SELECT ID FROM Stations WHERE id = @id";
            myReader = sqlCommand.ExecuteReader();
            myReader.Read();
            if (myReader.HasRows)
                isItemFound = true;
            myReader.Close();
            if (isItemFound)
            {
                return Update(id);
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
                sqlCommand.CommandText = "INSERT INTO Stations (Code,Station,Comms,Bell_Code,latitude,longitude,despatch_printer,printer_active,vehicles_min,personnel_min,backup_1,backup_2,backup_3,backup_4,stn_control_type,region_id,Deleted) VALUES (" + "@Code,@Station,@Comms,@BellCode,@Latitude,@Longitude,@DespatchPrinter,@PrinterActive,@VehiclesMin,@PersonnelMin,@Backup1,@Backup2,@Backup3,@Backup4,@StnControlType,@RegionId,0)";
                SetParameters();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Dim rmclass As New RMClass
                // rmclass.LogError("dbStations", "insert", ex, sqlCommand.CommandText)
                // rmclass.dispose()
                return ex.Message;
            }

            return "";
        }

        private string Update(long id)
        {
            try
            {
                sqlCommand.CommandText = "UPDATE Stations SET " + "Code = @Code," + "Station = @Station," + "Comms = @Comms," + "Bell_Code = @BellCode," + "latitude = @Latitude," + "longitude = @Longitude," + "despatch_printer = @DespatchPrinter," + "printer_active = @PrinterActive," + "vehicles_min = @VehiclesMin," + "personnel_min = @PersonnelMin," + "backup_1 = @Backup1," + "backup_2 = @Backup2," + "backup_3 = @Backup3," + "backup_4 = @Backup4," + "Deleted = @Deleted," + "stn_control_type = @StnControlType," + "region_id = @RegionId " + "WHERE id = @id";

                SetParameters();
                sqlCommand.Parameters.AddWithValue("@ID", id);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Dim rmclass As New RMClass
                // rmclass.LogError("dbStations", "update", ex, sqlCommand.CommandText)
                // rmclass.dispose()
                return ex.Message;
            }

            return "";
        }

        public int GetLastid()
        {
            System.Data.SqlClient.SqlDataReader Myreader;
            int Newid;
            sqlCommand.CommandText = "Select @@IDENTITY As Newid";
            Myreader = sqlCommand.ExecuteReader();
            Myreader.Read();
            Newid = Conversions.ToInteger(Myreader["NewID"]);
            Myreader.Close();
            return Newid;
        }

        private void SetParameters()
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@Code", _Code);
            sqlCommand.Parameters.AddWithValue("@Station", _Station);
            sqlCommand.Parameters.AddWithValue("@Comms", _Comms);
            sqlCommand.Parameters.AddWithValue("@BellCode", _BellCode);
            sqlCommand.Parameters.AddWithValue("@Latitude", _Latitude);
            sqlCommand.Parameters.AddWithValue("@Longitude", _Longitude);
            sqlCommand.Parameters.AddWithValue("@DespatchPrinter", _DespatchPrinter);
            sqlCommand.Parameters.AddWithValue("@PrinterActive", _PrinterActive);
            sqlCommand.Parameters.AddWithValue("@VehiclesMin", _VehiclesMin);
            sqlCommand.Parameters.AddWithValue("@PersonnelMin", _PersonnelMin);
            sqlCommand.Parameters.AddWithValue("@Backup1", _Backup1);
            sqlCommand.Parameters.AddWithValue("@Backup2", _Backup2);
            sqlCommand.Parameters.AddWithValue("@Backup3", _Backup3);
            sqlCommand.Parameters.AddWithValue("@Backup4", _Backup4);
            sqlCommand.Parameters.AddWithValue("@StnControlType", _StnControlType);
            sqlCommand.Parameters.AddWithValue("@RegionId", _RegionId);
            sqlCommand.Parameters.AddWithValue("@Deleted", _Deleted);
            foreach (System.Data.SqlClient.SqlParameter _SqlParameter in sqlCommand.Parameters)
            {
                if (_SqlParameter.Value is null)
                {
                    _SqlParameter.Value = DBNull.Value;
                }
            }
        }

        public string GetRegion(int stationId)
        {
            string strTemp = "";
            System.Data.SqlClient.SqlDataReader Myreader;
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", stationId);
            sqlCommand.CommandText = "Select value FROM STATIONS LEFT JOIN REGIONS On REGIONS.ID = STATIONS.region_id WHERE stations.id = @ID";
            Myreader = sqlCommand.ExecuteReader();
            Myreader.Read();
            if (Myreader.HasRows)
                strTemp = Myreader["value"].ToString();
            Myreader.Close();
            return strTemp;
        }

        public string ReadCodesForRegion(int regionId)
        {
            var strTemp = new StringBuilder();
            System.Data.SqlClient.SqlDataReader Myreader;
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", regionId);
            sqlCommand.CommandText = "Select code FROM STATIONS WHERE region_id = @ID";
            Myreader = sqlCommand.ExecuteReader();
            while (Myreader.Read())
                strTemp.Append(Myreader["code"].ToString());
            Myreader.Close();
            return strTemp.ToString();
        }
    }
}