using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ESS_Web_Services
{
    public class dbcalls : IDisposable
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand sqlCommand = new SqlCommand();
        private int _ID = 0;
        private string _CallNum = string.Empty;
        private DateTime _Datetime;
        private DateTime _OrigDatetime;
        private string _Category = string.Empty;
        private int _CategoryId = 0;
        private string _Location = string.Empty;
        private string _LocationTel = string.Empty;
        private string _Complex = string.Empty;
        private string _Poi = string.Empty;
        private string _Street = string.Empty;
        private string _Suburb = string.Empty;
        private string _Town = string.Empty;
        private string _Xroad = string.Empty;
        private string _Province = string.Empty;
        private string _ProvinceTo = string.Empty;
        private string _TownTo = string.Empty;
        private string _SuburbTo = string.Empty;
        private string _StreetTo = string.Empty;
        private string _StreetNumTo = string.Empty;
        private string _LocationTo = string.Empty;
        private string _XroadTo = string.Empty;
        private string _FloorTo = string.Empty;
        private string _Statement = string.Empty;
        private string _Comments = string.Empty;
        private string _Map = string.Empty;
        private string _Grid = string.Empty;
        private string _CallerTel = string.Empty;
        private string _Status = string.Empty;
        private string _CallerName = string.Empty;
        private string _UserName = string.Empty;
        private int _UserID = 0;
        private string _Subcategory = string.Empty;
        private int _SubcategoryId = 0;
        private string _StreetNum = string.Empty;
        private double _Latitude = 0d;
        private double _Longitude = 0d;
        private string _Remarks = string.Empty;
        private DateTime _AckDate = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private string _CallerAddr = string.Empty;
        private string _Floor = string.Empty;
        private string _Notes = string.Empty;
        private string _AckOperator = string.Empty;
        private string _OrigAddress = string.Empty;
        private string _NotifiedBy = string.Empty;
        private string _VoiceLoggerRef = string.Empty;
        private string _ServiceTrip = string.Empty;
        private string _NoserviceTripReason = string.Empty;
        private bool _OutOfArea = false;
        private bool _Reopen = false;
        private string _OtherCallnum = string.Empty;
        private string _OsiUrl = string.Empty;
        private string _DupCall = string.Empty;
        private string _DesignatedArea = string.Empty;
        private DateTime _Appointdatetime = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _Pickupdatetime = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private bool _IhtFlag = false;
        private string _LocationTelto = string.Empty;
        private double _LongitudeTo = 0d;
        private double _LatitudeTo = 0d;
        private string _ComplexTo = string.Empty;
        private bool _BookedCall = false;
        private string _CallerTel2 = string.Empty;
        private bool _LatecallFlag = false;
        private string _LatecallDate = string.Empty;
        private string _IncCommander = string.Empty;
        private string _LocationNumber = string.Empty;
        private string _LocationNumberto = string.Empty;
        private string _ReportOfficer = string.Empty;
        private string _Vehicles = string.Empty;
        private string _WardArea = string.Empty;
        private bool _RecoveryFlag = false;
        private string _EscortAt = string.Empty;
        private int _LocationId = 0;
        private int _StationAreaId = 0;
        private int _StationId = 0;
        private string _MpdStation = string.Empty;
        private int _MethodId = 0;
        private int _PriorityId = 0;
        private int _OrigPriorityId = 0;
        private string _ResponsibleOfficer = string.Empty;
        private int _ShiftId = 0;
        private bool _RimmsFlag = false;
        private int _RouteNumberId = 0;
        private bool _MasterFlag = false;
        private string _MasterCallNum = string.Empty;
        private string _MasterCallName = string.Empty;
        private string _Xroad2 = string.Empty;
        private string _OsiChecklist = string.Empty;
        private int _FlightTerrainId = 0;
        private int _FlightLightingId = 0;
        private int _FlightHazardId = 0;
        private string _FlightComments = string.Empty;
        private string _What3Words = string.Empty;
        private bool _DisasterFlag = false;
        private bool _MajorIncidentFlag = false;
        private string _SuggestedArea = string.Empty;
        private string _Station = string.Empty;
        private bool _DelayedFlag = false;
        private string _DelayedReason = string.Empty;
        private string _Resolution = string.Empty;

        public virtual void Dispose()
        {
            cn.Close();
            sqlCommand.Dispose();
        }

        public dbcalls()
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

        public string CallNum
        {
            get
            {
                return _CallNum;
            }

            set
            {
                _CallNum = value;
            }
        }

        public DateTime Datetime
        {
            get
            {
                return _Datetime;
            }

            set
            {
                _Datetime = value;
            }
        }

        public DateTime OrigDatetime
        {
            get
            {
                return _OrigDatetime;
            }

            set
            {
                _OrigDatetime = value;
            }
        }

        public string Category
        {
            get
            {
                return _Category;
            }

            set
            {
                _Category = value;
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

        public string Location
        {
            get
            {
                return _Location;
            }

            set
            {
                _Location = value;
            }
        }

        public string LocationTel
        {
            get
            {
                return _LocationTel;
            }

            set
            {
                _LocationTel = value;
            }
        }

        public string Complex
        {
            get
            {
                return _Complex;
            }

            set
            {
                _Complex = value;
            }
        }

        public string Poi
        {
            get
            {
                return _Poi;
            }

            set
            {
                _Poi = value;
            }
        }

        public string Street
        {
            get
            {
                return _Street;
            }

            set
            {
                _Street = value;
            }
        }

        public string Suburb
        {
            get
            {
                return _Suburb;
            }

            set
            {
                _Suburb = value;
            }
        }

        public string Town
        {
            get
            {
                return _Town;
            }

            set
            {
                _Town = value;
            }
        }

        public string Xroad
        {
            get
            {
                return _Xroad;
            }

            set
            {
                _Xroad = value;
            }
        }

        public string Province
        {
            get
            {
                return _Province;
            }

            set
            {
                _Province = value;
            }
        }

        public string ProvinceTo
        {
            get
            {
                return _ProvinceTo;
            }

            set
            {
                _ProvinceTo = value;
            }
        }

        public string TownTo
        {
            get
            {
                return _TownTo;
            }

            set
            {
                _TownTo = value;
            }
        }

        public string SuburbTo
        {
            get
            {
                return _SuburbTo;
            }

            set
            {
                _SuburbTo = value;
            }
        }

        public string StreetTo
        {
            get
            {
                return _StreetTo;
            }

            set
            {
                _StreetTo = value;
            }
        }

        public string StreetNumTo
        {
            get
            {
                return _StreetNumTo;
            }

            set
            {
                _StreetNumTo = value;
            }
        }

        public string LocationTo
        {
            get
            {
                return _LocationTo;
            }

            set
            {
                _LocationTo = value;
            }
        }

        public string XroadTo
        {
            get
            {
                return _XroadTo;
            }

            set
            {
                _XroadTo = value;
            }
        }

        public string FloorTo
        {
            get
            {
                return _FloorTo;
            }

            set
            {
                _FloorTo = value;
            }
        }

        public string Statement
        {
            get
            {
                return _Statement;
            }

            set
            {
                _Statement = value;
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

        public string Map
        {
            get
            {
                return _Map;
            }

            set
            {
                _Map = value;
            }
        }

        public string Grid
        {
            get
            {
                return _Grid;
            }

            set
            {
                _Grid = value;
            }
        }

        public string CallerTel
        {
            get
            {
                return _CallerTel;
            }

            set
            {
                _CallerTel = value;
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

        public string CallerName
        {
            get
            {
                return _CallerName;
            }

            set
            {
                _CallerName = value;
            }
        }

        public string UserName
        {
            get
            {
                return _UserName;
            }

            set
            {
                _UserName = value;
            }
        }

        public string Subcategory
        {
            get
            {
                return _Subcategory;
            }

            set
            {
                _Subcategory = value;
            }
        }

        public int SubcategoryId
        {
            get
            {
                return _SubcategoryId;
            }

            set
            {
                _SubcategoryId = value;
            }
        }

        public string StreetNum
        {
            get
            {
                return _StreetNum;
            }

            set
            {
                _StreetNum = value;
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

        public DateTime AckDate
        {
            get
            {
                return _AckDate;
            }

            set
            {
                _AckDate = value;
            }
        }

        public string CallerAddr
        {
            get
            {
                return _CallerAddr;
            }

            set
            {
                _CallerAddr = value;
            }
        }

        public string Floor
        {
            get
            {
                return _Floor;
            }

            set
            {
                _Floor = value;
            }
        }

        public string Notes
        {
            get
            {
                return _Notes;
            }

            set
            {
                _Notes = value;
            }
        }

        public string AckOperator
        {
            get
            {
                return _AckOperator;
            }

            set
            {
                _AckOperator = value;
            }
        }

        public string OrigAddress
        {
            get
            {
                return _OrigAddress;
            }

            set
            {
                _OrigAddress = value;
            }
        }

        public string NotifiedBy
        {
            get
            {
                return _NotifiedBy;
            }

            set
            {
                _NotifiedBy = value;
            }
        }

        public string VoiceLoggerRef
        {
            get
            {
                return _VoiceLoggerRef;
            }

            set
            {
                _VoiceLoggerRef = value;
            }
        }

        public string ServiceTrip
        {
            get
            {
                return _ServiceTrip;
            }

            set
            {
                _ServiceTrip = value;
            }
        }

        public string NoserviceTripReason
        {
            get
            {
                return _NoserviceTripReason;
            }

            set
            {
                _NoserviceTripReason = value;
            }
        }

        public bool OutOfArea
        {
            get
            {
                return _OutOfArea;
            }

            set
            {
                _OutOfArea = value;
            }
        }

        public bool Reopen
        {
            get
            {
                return _Reopen;
            }

            set
            {
                _Reopen = value;
            }
        }

        public string OtherCallnum
        {
            get
            {
                return _OtherCallnum;
            }

            set
            {
                _OtherCallnum = value;
            }
        }

        public string OsiUrl
        {
            get
            {
                return _OsiUrl;
            }

            set
            {
                _OsiUrl = value;
            }
        }

        public string DupCall
        {
            get
            {
                return _DupCall;
            }

            set
            {
                _DupCall = value;
            }
        }

        public string DesignatedArea
        {
            get
            {
                return _DesignatedArea;
            }

            set
            {
                _DesignatedArea = value;
            }
        }

        public DateTime Appointdatetime
        {
            get
            {
                return _Appointdatetime;
            }

            set
            {
                _Appointdatetime = value;
            }
        }

        public DateTime Pickupdatetime
        {
            get
            {
                return _Pickupdatetime;
            }

            set
            {
                _Pickupdatetime = value;
            }
        }

        public bool IhtFlag
        {
            get
            {
                return _IhtFlag;
            }

            set
            {
                _IhtFlag = value;
            }
        }

        public string LocationTelto
        {
            get
            {
                return _LocationTelto;
            }

            set
            {
                _LocationTelto = value;
            }
        }

        public double LongitudeTo
        {
            get
            {
                return _LongitudeTo;
            }

            set
            {
                _LongitudeTo = value;
            }
        }

        public double LatitudeTo
        {
            get
            {
                return _LatitudeTo;
            }

            set
            {
                _LatitudeTo = value;
            }
        }

        public string ComplexTo
        {
            get
            {
                return _ComplexTo;
            }

            set
            {
                _ComplexTo = value;
            }
        }

        public bool BookedCall
        {
            get
            {
                return _BookedCall;
            }

            set
            {
                _BookedCall = value;
            }
        }

        public string CallerTel2
        {
            get
            {
                return _CallerTel2;
            }

            set
            {
                _CallerTel2 = value;
            }
        }

        public bool LatecallFlag
        {
            get
            {
                return _LatecallFlag;
            }

            set
            {
                _LatecallFlag = value;
            }
        }

        public string LatecallDate
        {
            get
            {
                return _LatecallDate;
            }

            set
            {
                _LatecallDate = value;
            }
        }

        public string IncCommander
        {
            get
            {
                return _IncCommander;
            }

            set
            {
                _IncCommander = value;
            }
        }

        public string LocationNumber
        {
            get
            {
                return _LocationNumber;
            }

            set
            {
                _LocationNumber = value;
            }
        }

        public string LocationNumberto
        {
            get
            {
                return _LocationNumberto;
            }

            set
            {
                _LocationNumberto = value;
            }
        }

        public string ReportOfficer
        {
            get
            {
                return _ReportOfficer;
            }

            set
            {
                _ReportOfficer = value;
            }
        }

        public string Vehicles
        {
            get
            {
                return _Vehicles;
            }

            set
            {
                _Vehicles = value;
            }
        }

        public string WardArea
        {
            get
            {
                return _WardArea;
            }

            set
            {
                _WardArea = value;
            }
        }

        public bool RecoveryFlag
        {
            get
            {
                return _RecoveryFlag;
            }

            set
            {
                _RecoveryFlag = value;
            }
        }

        public string EscortAt
        {
            get
            {
                return _EscortAt;
            }

            set
            {
                _EscortAt = value;
            }
        }

        public int LocationId
        {
            get
            {
                return _LocationId;
            }

            set
            {
                _LocationId = value;
            }
        }

        public int UserId
        {
            get
            {
                return _UserID;
            }

            set
            {
                _UserID = value;
            }
        }

        public int StationAreaId
        {
            get
            {
                return _StationAreaId;
            }

            set
            {
                _StationAreaId = value;
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

        public int MethodId
        {
            get
            {
                return _MethodId;
            }

            set
            {
                _MethodId = value;
            }
        }

        public int PriorityId
        {
            get
            {
                return _PriorityId;
            }

            set
            {
                _PriorityId = value;
            }
        }

        public int OrigPriorityId
        {
            get
            {
                return _OrigPriorityId;
            }

            set
            {
                _OrigPriorityId = value;
            }
        }

        public string ResponsibleOfficer
        {
            get
            {
                return _ResponsibleOfficer;
            }

            set
            {
                _ResponsibleOfficer = value;
            }
        }

        public int ShiftID
        {
            get
            {
                return _ShiftId;
            }

            set
            {
                _ShiftId = value;
            }
        }

        public bool RimmsFlag
        {
            get
            {
                return _RimmsFlag;
            }

            set
            {
                _RimmsFlag = value;
            }
        }

        public int RouteNumberID
        {
            get
            {
                return _RouteNumberId;
            }

            set
            {
                _RouteNumberId = value;
            }
        }

        public bool MasterFlag
        {
            get
            {
                return _MasterFlag;
            }

            set
            {
                _MasterFlag = value;
            }
        }

        public string MasterCallNum
        {
            get
            {
                return _MasterCallNum;
            }

            set
            {
                _MasterCallNum = value;
            }
        }

        public string MasterCallName
        {
            get
            {
                return _MasterCallName;
            }

            set
            {
                _MasterCallName = value;
            }
        }

        public string Xroad2
        {
            get
            {
                return _Xroad2;
            }

            set
            {
                _Xroad2 = value;
            }
        }

        public string OsiChecklist
        {
            get
            {
                return _OsiChecklist;
            }

            set
            {
                _OsiChecklist = value;
            }
        }

        public string FlightComments
        {
            get
            {
                return _FlightComments;
            }

            set
            {
                _FlightComments = value;
            }
        }

        public int FlightTerrainId
        {
            get
            {
                return _FlightTerrainId;
            }

            set
            {
                _FlightTerrainId = value;
            }
        }

        public int FlightLightingId
        {
            get
            {
                return _FlightLightingId;
            }

            set
            {
                _FlightLightingId = value;
            }
        }

        public int FlightHazardId
        {
            get
            {
                return _FlightHazardId;
            }

            set
            {
                _FlightHazardId = value;
            }
        }

        public string What3Words
        {
            get
            {
                return _What3Words;
            }

            set
            {
                _What3Words = value;
            }
        }

        public bool DisasterFlag
        {
            get
            {
                return _DisasterFlag;
            }

            set
            {
                _DisasterFlag = value;
            }
        }

        public bool MajorIncidentFlag
        {
            get
            {
                return _MajorIncidentFlag;
            }

            set
            {
                _MajorIncidentFlag = value;
            }
        }

        public string SuggestedArea
        {
            get
            {
                return _SuggestedArea;
            }

            set
            {
                _SuggestedArea = value;
            }
        }

        public string MpdStation
        {
            get
            {
                return _MpdStation;
            }

            set
            {
                _MpdStation = value;
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

        public bool DelayedFlag
        {
            get
            {
                return _DelayedFlag;
            }

            set
            {
                _DelayedFlag = value;
            }
        }

        public string DelayedReason
        {
            get
            {
                return _DelayedReason;
            }

            set
            {
                _DelayedReason = value;
            }
        }

        public string Resolution
        {
            get
            {
                return _Resolution;
            }

            set
            {
                _Resolution = value;
            }
        }

        public string GetItemByID(int id)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlCommand.CommandText = "SELECT * FROM calls WHERE id = @id";
            return Readitem();
        }

        public string GetItemByCallerTel(string telnum)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@CallerTel", telnum);
            sqlCommand.CommandText = "SELECT top 1 * FROM calls WHERE caller_tel  = @CallerTel ORDER BY ID DESC";
            return Readitem();
        }

        public string GetLastCall()
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", ID);
            sqlCommand.CommandText = "SELECT top 1 * FROM CALLS ORDER BY ID DESC";
            return Readitem();
        }

        private string Readitem()
        {
            SqlDataReader Myreader;
            Myreader = sqlCommand.ExecuteReader();
            Myreader.Read();
            try
            {
                if (Myreader.HasRows)
                {
                    _ID = Conversions.ToInteger(Myreader["id"]);
                    _CallNum = Myreader["Call_Num"].ToString();
                    if (!Information.IsDBNull(Myreader["DateTime"]))
                        _Datetime = Conversions.ToDate(Myreader["DateTime"]);
                    if (!Information.IsDBNull(Myreader["Orig_DateTime"]))
                        _OrigDatetime = Conversions.ToDate(Myreader["Orig_DateTime"]);
                    _Category = Myreader["Category"].ToString();
                    _CategoryId = Conversions.ToInteger(Myreader["Category_id"]);
                    _Location = Myreader["Location"].ToString();
                    _LocationTel = Myreader["Location_tel"].ToString();
                    _Complex = Myreader["Complex"].ToString();
                    _Poi = Myreader["POI"].ToString();
                    _Street = Myreader["Street"].ToString();
                    _Suburb = Myreader["Suburb"].ToString();
                    _Town = Myreader["Town"].ToString();
                    _Xroad = Myreader["Xroad"].ToString();
                    _Province = Myreader["Province"].ToString();
                    _ProvinceTo = Myreader["Province_to"].ToString();
                    _TownTo = Myreader["Town_to"].ToString();
                    _SuburbTo = Myreader["Suburb_to"].ToString();
                    _StreetTo = Myreader["Street_to"].ToString();
                    _StreetNumTo = Myreader["Street_num_to"].ToString();
                    _LocationTo = Myreader["Location_to"].ToString();
                    _XroadTo = Myreader["Xroad_to"].ToString();
                    _FloorTo = Myreader["Floor_to"].ToString();
                    _Statement = Myreader["Statement"].ToString();
                    _Comments = Myreader["Comments"].ToString();
                    _Map = Myreader["Map"].ToString();
                    _Grid = Myreader["Grid"].ToString();
                    _CallerTel = Myreader["Caller_Tel"].ToString();
                    _Status = Myreader["Status"].ToString();
                    _CallerName = Myreader["Caller_Name"].ToString();
                    _UserName = Myreader["Operator"].ToString();
                    _Subcategory = Myreader["SubCategory"].ToString();
                    _SubcategoryId = Conversions.ToInteger(Myreader["SubCategory_Id"]);
                    _StreetNum = Myreader["Street_Num"].ToString();
                    _Latitude = Conversions.ToDouble(Myreader["Latitude"]);
                    _Longitude = Conversions.ToDouble(Myreader["Longitude"]);
                    _Remarks = Myreader["Remarks"].ToString();
                    if (!Information.IsDBNull(Myreader["Ack_Date"]))
                        _AckDate = Conversions.ToDate(Myreader["Ack_Date"]);
                    _CallerAddr = Myreader["Caller_Addr"].ToString();
                    _Floor = Myreader["Floor"].ToString();
                    _Notes = Myreader["Notes"].ToString();
                    _AckOperator = Myreader["Ack_Operator"].ToString();
                    _OrigAddress = Myreader["Orig_address"].ToString();
                    _NotifiedBy = Myreader["Notified_By"].ToString();
                    _VoiceLoggerRef = Myreader["Voice_Logger_ref"].ToString();
                    _ServiceTrip = Myreader["Service_Trip"].ToString();
                    _NoserviceTripReason = Myreader["NoService_Trip_Reason"].ToString();
                    _OutOfArea = Conversions.ToBoolean(Myreader["Out_of_Area"]);
                    _Reopen = Conversions.ToBoolean(Myreader["reopen"]);
                    _OtherCallnum = Myreader["Other_Callnum"].ToString();
                    _OsiUrl = Myreader["osi_URL"].ToString();
                    _DupCall = Myreader["dup_call"].ToString();
                    _DesignatedArea = Myreader["Designated_area"].ToString();
                    if (!Information.IsDBNull(Myreader["appointdatetime"]))
                        _Appointdatetime = Conversions.ToDate(Myreader["appointdatetime"]);
                    if (!Information.IsDBNull(Myreader["pickupdatetime"]))
                        _Pickupdatetime = Conversions.ToDate(Myreader["pickupdatetime"]);
                    _IhtFlag = Conversions.ToBoolean(Myreader["iht_flag"]);
                    _LocationTelto = Myreader["Location_telTo"].ToString();
                    _LongitudeTo = Conversions.ToDouble(Myreader["Longitude_to"]);
                    _LatitudeTo = Conversions.ToDouble(Myreader["Latitude_to"]);
                    _ComplexTo = Myreader["Complex_to"].ToString();
                    _BookedCall = Conversions.ToBoolean(Myreader["booked_call"]);
                    _CallerTel2 = Myreader["caller_tel2"].ToString();
                    _LatecallFlag = Conversions.ToBoolean(Myreader["latecall_flag"]);
                    _LatecallDate = Myreader["latecall_date"].ToString();
                    _IncCommander = Myreader["inc_commander"].ToString();
                    _LocationNumber = Myreader["Location_Number"].ToString();
                    _LocationNumberto = Myreader["Location_Numberto"].ToString();
                    _ReportOfficer = Myreader["report_officer"].ToString();
                    _Vehicles = Myreader["vehicles"].ToString();
                    _WardArea = Myreader["ward_area"].ToString();
                    _RecoveryFlag = Conversions.ToBoolean(Myreader["recovery_flag"]);
                    _EscortAt = Myreader["escort_at"].ToString();
                    _LocationId = Conversions.ToInteger(Myreader["location_id"]);
                    _StationAreaId = Conversions.ToInteger(Myreader["station_area_id"]);
                    _StationId = Conversions.ToInteger(Myreader["station_id"]);
                    _MethodId = Conversions.ToInteger(Myreader["method_id"]);
                    _PriorityId = Conversions.ToInteger(Myreader["Priority_Id"]);
                    _OrigPriorityId = Conversions.ToInteger(Myreader["orig_priority_id"]);
                    _ShiftId = Conversions.ToInteger(Myreader["shift_id"]);
                    _ResponsibleOfficer = Myreader["Responsible_Officer"].ToString();
                    _RimmsFlag = Conversions.ToBoolean(Myreader["rimms_flag"]);
                    _RouteNumberId = Conversions.ToInteger(Myreader["route_number_id"]);
                    _UserID = Conversions.ToInteger(Myreader["user_id"]);
                    _MasterFlag = Conversions.ToBoolean(Myreader["master_flag"]);
                    _MasterCallNum = Myreader["master_call_num"].ToString();
                    _MasterCallName = Myreader["master_call_name"].ToString();
                    _Xroad2 = Myreader["xroad2"].ToString();
                    _OsiChecklist = Myreader["osi_checklist"].ToString();
                    _FlightComments = Myreader["flight_comments"].ToString();
                    _FlightTerrainId = Conversions.ToInteger(Myreader["flight_terrain_id"]);
                    _FlightLightingId = Conversions.ToInteger(Myreader["flight_lighting_id"]);
                    _FlightHazardId = Conversions.ToInteger(Myreader["flight_hazard_id"]);
                    _What3Words = Myreader["What3Words"].ToString();
                    _DisasterFlag = Conversions.ToBoolean(Myreader["disaster_flag"]);
                    _MajorIncidentFlag = Conversions.ToBoolean(Myreader["major_incident_flag"]);
                    _SuggestedArea = Myreader["Suggested_Area"].ToString();
                    _MpdStation = Myreader["mpd_Station"].ToString();
                    _Station = Myreader["station"].ToString();
                    _DelayedFlag = Conversions.ToBoolean(Myreader["Delayed_Flag"]);
                    _DelayedReason = Myreader["Delayed_Reason"].ToString();
                    _Resolution = Myreader["Resolution"].ToString();
                }
            }
            catch (Exception ex)
            {
                if (!Myreader.IsClosed)
                    Myreader.Close();
                // Dim rmclass As New RMClass
                // rmclass.LogError("dbcalls", "getitem", ex, sqlCommand.CommandText)
                // rmclass.dispose()
                return ex.Message;
            }

            Myreader.Close();
            return "";
        }

        public string GetItem(string callNum)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@CallNum", callNum);
            sqlCommand.CommandText = "SELECT * FROM calls WHERE call_Num = @CallNum";
            return Readitem();
        }

        public string Save(string callNum)
        {
            SqlDataReader myReader;
            bool isItemFound = false;
            if (string.IsNullOrEmpty(callNum))
            {
                return Insert();
            }

            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@CallNum", callNum);
            sqlCommand.CommandText = "SELECT ID FROM calls WHERE call_num = @CallNum";
            myReader = sqlCommand.ExecuteReader();
            myReader.Read();
            if (myReader.HasRows)
                isItemFound = true;
            myReader.Close();
            if (isItemFound)
            {
                return Update(callNum);
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
                sqlCommand.CommandText = "INSERT INTO calls (Call_Num,DateTime,Orig_DateTime,Category,Category_id,Location,Location_tel,Complex,POI,Street,Suburb,Town,Xroad,Province,Province_to,Town_to,Suburb_to,Street_to,Street_num_to,Location_to,Xroad_to,Floor_to,Statement,Comments,Map,Grid,Caller_Tel,Status,Caller_Name,Operator,SubCategory,SubCategory_Id,Street_Num,Latitude,Longitude,Remarks,Ack_Date,Caller_Addr,Floor,Notes,Ack_Operator,Orig_address,Notified_By,Voice_Logger_ref,Service_Trip,NoService_Trip_Reason,Out_of_Area,reopen,Other_Callnum,osi_URL,dup_call,Designated_area,appointdatetime,pickupdatetime,iht_flag,Location_telTo,Longitude_to,Latitude_to,Complex_to,booked_call,caller_tel2,latecall_flag,latecall_date,inc_commander,Location_Number,Location_Numberto,report_officer,vehicles,ward_area,recovery_flag,escort_at,location_id,station_area_id,station_id,method_id,Priority_Id,orig_priority_id,Responsible_Officer,shift_id,Rimms_Flag,route_number_id,user_id,master_flag,xroad2,Osi_Checklist,flight_comments,flight_terrain_id,flight_lighting_id,flight_hazard_id,What3Words,Disaster_flag,Major_Incident_Flag,Suggested_Area,mpd_station,station,Delayed_Flag,Delayed_Reason,Resolution) VALUES (" + "@CallNum,@Datetime,@OrigDateTime,@Category,@CategoryId,@Location,@LocationTel,@Complex,@Poi,@Street,@Suburb,@Town,@Xroad,@Province,@ProvinceTo,@TownTo,@SuburbTo,@StreetTo,@StreetNumTo,@LocationTo,@XroadTo,@FloorTo,@Statement,@Comments,@Map,@Grid,@CallerTel,@Status,@CallerName,@Operator,@Subcategory,@SubcategoryId,@StreetNum,@Latitude,@Longitude,@Remarks,@AckDate,@CallerAddr,@Floor,@Notes,@AckOperator,@OrigAddress,@NotifiedBy,@VoiceLoggerRef,@ServiceTrip,@NoserviceTripReason,@OutOfArea,@Reopen,@OtherCallnum,@OsiUrl,@DupCall,@DesignatedArea,@Appointdatetime,@Pickupdatetime,@IhtFlag,@LocationTelto,@LongitudeTo,@LatitudeTo,@ComplexTo,@BookedCall,@CallerTel2,@LatecallFlag,@LatecallDate,@IncCommander,@LocationNumber,@LocationNumberto,@ReportOfficer,@Vehicles,@WardArea,@RecoveryFlag,@EscortAt,@LocationId,@StationAreaId,@StationId,@MethodId,@PriorityId,@OrigPriorityId,@ResponsibleOfficer,@ShiftId,@RimmsFlag,@RouteNumberId,@UserId,@MasterFlag,@Xroad2,@OsiChecklist,@flightcomments,@flightterrainid,@flightlightingid,@flighthazardid,@What3Words,@DisasterFlag,@MajorIncidentFlag,@SuggestedArea,@MpdStation,@Station,@DelayedFlag,@DelayedReason,@Resolution)";
                this.SetParameters();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //var strTemp = new StringBuilder();
                //foreach (var SqlParameter in sqlCommand.Parameters)
                //    strTemp.Append(SqlParameter.ToString() + "=" + SqlParameter.value.ToString() + ",");
                // 
                // Dim rmclass As New RMClass
                // rmclass.LogError("dbcalls", "insert", ex, sqlCommand.CommandText & vbCrLf & strTemp.ToString)
                // rmclass.dispose()
                return ex.Message;
            }

            return "";
        }

        private string Update(string callNum)
        {
            try
            {
                sqlCommand.CommandText = "UPDATE calls SET " + "Call_Num = @CallNum," + "DateTime = @Datetime," + "Orig_DateTime = @OrigDatetime," + "Category = @Category," + "Category_id = @CategoryId," + "Location = @Location," + "Location_tel = @LocationTel," + "Complex = @Complex," + "POI = @Poi," + "Street = @Street," + "Suburb = @Suburb," + "Town = @Town," + "Xroad = @Xroad," + "Province = @Province," + "Province_to = @ProvinceTo," + "Town_to = @TownTo," + "Suburb_to = @SuburbTo," + "Street_to = @StreetTo," + "Street_num_to = @StreetNumTo," + "Location_to = @LocationTo," + "Xroad_to = @XroadTo," + "Floor_to = @FloorTo," + "Statement = @Statement," + "Comments = @Comments," + "Map = @Map," + "Grid = @Grid," + "Caller_Tel = @CallerTel," + "Status = @Status," + "Caller_Name = @CallerName," + "Operator = @Operator," + "SubCategory = @Subcategory," + "SubCategory_Id = @SubcategoryId," + "Street_Num = @StreetNum," + "Latitude = @Latitude," + "Longitude = @Longitude," + "Remarks = @Remarks," + "Ack_Date = @AckDate," + "Caller_Addr = @CallerAddr," + "Floor = @Floor," + "Notes = @Notes," + "Ack_Operator = @AckOperator," + "Orig_address = @OrigAddress," + "Notified_By = @NotifiedBy," + "Voice_Logger_ref = @VoiceLoggerRef," + "Service_Trip = @ServiceTrip," + "NoService_Trip_Reason = @NoserviceTripReason," + "Out_of_Area = @OutOfArea," + "reopen = @Reopen," + "Other_Callnum = @OtherCallnum," + "osi_URL = @OsiUrl," + "dup_call = @DupCall," + "Designated_area = @DesignatedArea," + "appointdatetime = @Appointdatetime," + "pickupdatetime = @Pickupdatetime," + "iht_flag = @IhtFlag," + "Location_telTo = @LocationTelto," + "Longitude_to = @LongitudeTo," + "Latitude_to = @LatitudeTo," + "Complex_to = @ComplexTo," + "booked_call = @BookedCall," + "caller_tel2 = @CallerTel2," + "latecall_flag = @LatecallFlag," + "latecall_date = @LatecallDate," + "inc_commander = @IncCommander," + "Location_Number = @LocationNumber," + "Location_Numberto = @LocationNumberto," + "report_officer = @ReportOfficer," + "vehicles = @Vehicles," + "ward_area = @WardArea," + "recovery_flag = @RecoveryFlag," + "escort_at = @EscortAt," + "location_id = @LocationId," + "station_area_id = @StationAreaId," + "station_id = @StationId," + "method_id = @MethodId," + "Priority_Id = @PriorityId," + "Shift_Id = @ShiftId," + "Rimms_Flag = @RimmsFlag," + "orig_priority_id = @OrigPriorityId," + "route_number_id = @RouteNumberId," + "user_id = @UserId," + "master_flag = @MasterFlag, " + "master_call_num =  @MasterCallNum," + "master_call_name =  @MasterCallName," + "Responsible_Officer = @ResponsibleOfficer," + "Xroad2 = @Xroad2," + "Flight_Comments = @FlightComments," + "Flight_Terrain_id = @FlightTerrainId," + "Flight_Lighting_id = @FlightLightingId," + "Flight_Hazard_Id = @FlightHazardId," + "What3Words = @What3Words," + "Disaster_Flag = @DisasterFlag," + "major_incident_flag = @MajorIncidentFlag," + "Suggested_Area = @SuggestedArea," + "osi_checklist = @OsiChecklist," + "mpd_Station = @MpdStation, " + "Delayed_Flag = @DelayedFlag, " + "Delayed_reason = @DelayedReason, " + "Resolution = @Resolution," + "Station = @Station " + "WHERE Call_Num = @callNum";
                this.SetParameters();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //var strTemp = new StringBuilder();
                //foreach (var SqlParameter in sqlCommand.Parameters)
                //    strTemp.Append(SqlParameter.ToString() + "=" + SqlParameter.value.ToString() + ",");
                // Dim rmclass As New RMClass
                // rmclass.LogError("dbcalls", "update", ex, sqlCommand.CommandText & vbCrLf & strTemp.ToString)
                // rmclass.dispose()
                return ex.Message;
            }

            return "";
        }

        public int GetLastid()
        {
            SqlDataReader Myreader;
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
            sqlCommand.Parameters.AddWithValue("@CallNum", _CallNum);
            sqlCommand.Parameters.AddWithValue("@Datetime", _Datetime);
            sqlCommand.Parameters.AddWithValue("@Category", _Category);
            sqlCommand.Parameters.AddWithValue("@CategoryId", _CategoryId);
            sqlCommand.Parameters.AddWithValue("@Location", _Location);
            sqlCommand.Parameters.AddWithValue("@LocationTel", _LocationTel);
            sqlCommand.Parameters.AddWithValue("@Complex", _Complex);
            sqlCommand.Parameters.AddWithValue("@Poi", _Poi);
            sqlCommand.Parameters.AddWithValue("@Street", _Street);
            sqlCommand.Parameters.AddWithValue("@Suburb", _Suburb);
            sqlCommand.Parameters.AddWithValue("@Town", _Town);
            sqlCommand.Parameters.AddWithValue("@Xroad", _Xroad);
            sqlCommand.Parameters.AddWithValue("@Province", _Province);
            sqlCommand.Parameters.AddWithValue("@ProvinceTo", _ProvinceTo);
            sqlCommand.Parameters.AddWithValue("@TownTo", _TownTo);
            sqlCommand.Parameters.AddWithValue("@SuburbTo", _SuburbTo);
            sqlCommand.Parameters.AddWithValue("@StreetTo", _StreetTo);
            sqlCommand.Parameters.AddWithValue("@StreetNumTo", _StreetNumTo);
            sqlCommand.Parameters.AddWithValue("@LocationTo", _LocationTo);
            sqlCommand.Parameters.AddWithValue("@XroadTo", _XroadTo);
            sqlCommand.Parameters.AddWithValue("@FloorTo", _FloorTo);
            sqlCommand.Parameters.AddWithValue("@Statement", _Statement);
            sqlCommand.Parameters.AddWithValue("@Comments", _Comments);
            sqlCommand.Parameters.AddWithValue("@Map", _Map);
            sqlCommand.Parameters.AddWithValue("@Grid", _Grid);
            sqlCommand.Parameters.AddWithValue("@CallerTel", _CallerTel);
            sqlCommand.Parameters.AddWithValue("@Status", _Status);
            sqlCommand.Parameters.AddWithValue("@CallerName", _CallerName);
            sqlCommand.Parameters.AddWithValue("@Operator", _UserName);
            sqlCommand.Parameters.AddWithValue("@Subcategory", _Subcategory);
            sqlCommand.Parameters.AddWithValue("@SubcategoryId", _SubcategoryId);
            sqlCommand.Parameters.AddWithValue("@StreetNum", _StreetNum);
            sqlCommand.Parameters.AddWithValue("@Latitude", _Latitude);
            sqlCommand.Parameters.AddWithValue("@Longitude", _Longitude);
            sqlCommand.Parameters.AddWithValue("@Remarks", _Remarks);
            sqlCommand.Parameters.Add(new SqlParameter("@AckDate", SqlDbType.DateTime));
            if (_AckDate == Conversions.ToDate("1/1/1900 12:00:00 AM"))
            {
                sqlCommand.Parameters["@AckDate"].Value = System.Data.SqlTypes.SqlDateTime.Null;
            }
            else
            {
                sqlCommand.Parameters["@AckDate"].Value = _AckDate;
            }

            sqlCommand.Parameters.AddWithValue("@CallerAddr", _CallerAddr);
            sqlCommand.Parameters.AddWithValue("@Floor", _Floor);
            sqlCommand.Parameters.AddWithValue("@Notes", _Notes);
            sqlCommand.Parameters.AddWithValue("@AckOperator", _AckOperator);
            sqlCommand.Parameters.AddWithValue("@OrigAddress", _OrigAddress);
            sqlCommand.Parameters.AddWithValue("@NotifiedBy", _NotifiedBy);
            sqlCommand.Parameters.AddWithValue("@VoiceLoggerRef", _VoiceLoggerRef);
            sqlCommand.Parameters.AddWithValue("@ServiceTrip", _ServiceTrip);
            sqlCommand.Parameters.AddWithValue("@NoserviceTripReason", _NoserviceTripReason);
            sqlCommand.Parameters.AddWithValue("@OutOfArea", _OutOfArea);
            sqlCommand.Parameters.AddWithValue("@Reopen", _Reopen);
            sqlCommand.Parameters.AddWithValue("@OtherCallnum", _OtherCallnum);
            sqlCommand.Parameters.AddWithValue("@OsiUrl", _OsiUrl);
            sqlCommand.Parameters.AddWithValue("@DupCall", _DupCall);
            sqlCommand.Parameters.AddWithValue("@DesignatedArea", _DesignatedArea);
            sqlCommand.Parameters.Add(new SqlParameter("@OrigDateTime", SqlDbType.DateTime));
            if (_Pickupdatetime.Equals(DateTime.MinValue))
            {
                sqlCommand.Parameters["@OrigDateTime"].Value = System.Data.SqlTypes.SqlDateTime.Null;
            }
            else
            {
                sqlCommand.Parameters["@OrigDateTime"].Value = _Pickupdatetime;
            }

            sqlCommand.Parameters.Add(new SqlParameter("@Appointdatetime", SqlDbType.DateTime));
            if (_Appointdatetime.Equals(DateTime.MinValue))
            {
                sqlCommand.Parameters["@Appointdatetime"].Value = System.Data.SqlTypes.SqlDateTime.Null;
            }
            else
            {
                sqlCommand.Parameters["@Appointdatetime"].Value = _Appointdatetime;
            }

            sqlCommand.Parameters.Add(new SqlParameter("@Pickupdatetime", SqlDbType.DateTime));
            if (_Pickupdatetime.Equals(DateTime.MinValue))
            {
                sqlCommand.Parameters["@Pickupdatetime"].Value = System.Data.SqlTypes.SqlDateTime.Null;
            }
            else
            {
                sqlCommand.Parameters["@Pickupdatetime"].Value = _Pickupdatetime;
            }

            sqlCommand.Parameters.AddWithValue("@IhtFlag", _IhtFlag);
            sqlCommand.Parameters.AddWithValue("@LocationTelto", _LocationTelto);
            sqlCommand.Parameters.AddWithValue("@LongitudeTo", _LongitudeTo);
            sqlCommand.Parameters.AddWithValue("@LatitudeTo", _LatitudeTo);
            sqlCommand.Parameters.AddWithValue("@ComplexTo", _ComplexTo);
            sqlCommand.Parameters.AddWithValue("@BookedCall", _BookedCall);
            sqlCommand.Parameters.AddWithValue("@CallerTel2", _CallerTel2);
            sqlCommand.Parameters.AddWithValue("@LatecallFlag", _LatecallFlag);
            sqlCommand.Parameters.AddWithValue("@LatecallDate", _LatecallDate);
            sqlCommand.Parameters.AddWithValue("@IncCommander", _IncCommander);
            sqlCommand.Parameters.AddWithValue("@LocationNumber", _LocationNumber);
            sqlCommand.Parameters.AddWithValue("@LocationNumberto", _LocationNumberto);
            sqlCommand.Parameters.AddWithValue("@ReportOfficer", _ReportOfficer);
            sqlCommand.Parameters.AddWithValue("@Vehicles", _Vehicles);
            sqlCommand.Parameters.AddWithValue("@WardArea", _WardArea);
            sqlCommand.Parameters.AddWithValue("@RecoveryFlag", _RecoveryFlag);
            sqlCommand.Parameters.AddWithValue("@EscortAt", _EscortAt);
            sqlCommand.Parameters.AddWithValue("@LocationId", _LocationId);
            sqlCommand.Parameters.AddWithValue("@StationAreaId", _StationAreaId);
            sqlCommand.Parameters.AddWithValue("@StationId", _StationId);
            sqlCommand.Parameters.AddWithValue("@MethodId", _MethodId);
            sqlCommand.Parameters.AddWithValue("@PriorityId", _PriorityId);
            sqlCommand.Parameters.AddWithValue("@OrigPriorityId", _OrigPriorityId);
            sqlCommand.Parameters.AddWithValue("@ResponsibleOfficer", _ResponsibleOfficer);
            sqlCommand.Parameters.AddWithValue("@ShiftId", _ShiftId);
            sqlCommand.Parameters.AddWithValue("@RimmsFlag", _RimmsFlag);
            sqlCommand.Parameters.AddWithValue("@RouteNumberId", _RouteNumberId);
            sqlCommand.Parameters.AddWithValue("@UserId", _UserID);
            sqlCommand.Parameters.AddWithValue("@MasterFlag", _MasterFlag);
            sqlCommand.Parameters.AddWithValue("@MasterCallNum", _MasterCallNum);
            sqlCommand.Parameters.AddWithValue("@MasterCallName", _MasterCallName);
            sqlCommand.Parameters.AddWithValue("@Xroad2", _Xroad2);
            sqlCommand.Parameters.AddWithValue("@OsiChecklist", _OsiChecklist);
            sqlCommand.Parameters.AddWithValue("@FlightComments", _FlightComments);
            sqlCommand.Parameters.AddWithValue("@FlightTerrainId", _FlightTerrainId);
            sqlCommand.Parameters.AddWithValue("@FlightLightingId", _FlightLightingId);
            sqlCommand.Parameters.AddWithValue("@FlightHazardId", _FlightHazardId);
            sqlCommand.Parameters.AddWithValue("@What3Words", _What3Words);
            sqlCommand.Parameters.AddWithValue("@DisasterFlag", _DisasterFlag);
            sqlCommand.Parameters.AddWithValue("@MajorIncidentFlag", _MajorIncidentFlag);
            sqlCommand.Parameters.AddWithValue("@SuggestedArea", _SuggestedArea);
            sqlCommand.Parameters.AddWithValue("@MpdStation", _MpdStation);
            sqlCommand.Parameters.AddWithValue("@Station", _Station);
            sqlCommand.Parameters.AddWithValue("@DelayedFlag", _DelayedFlag);
            sqlCommand.Parameters.AddWithValue("@DelayedReason", _DelayedReason);
            sqlCommand.Parameters.AddWithValue("@Resolution", _Resolution);
            
            foreach (SqlParameter _SqlParameter in sqlCommand.Parameters)
            {
                if (_SqlParameter.Value is null)
                {
                    _SqlParameter.Value = DBNull.Value;
                }
            }
        }
        public void Delete(string strCallNum)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@CallNum", strCallNum);
            sqlCommand.CommandText = "DELETE FROM Calls WHERE call_num = @CallNum";
            sqlCommand.ExecuteNonQuery();
        }

        public string CheckListCallTaking(string callNum)
        {
            string strTemp = "";
            SqlDataReader Myreader;
            sqlCommand.CommandText = "SELECT * FROM CALL_CHECKLISTS WHERE call_num = '" + callNum + "' and type = 'calls'";
            Myreader = sqlCommand.ExecuteReader();
            while (Myreader.Read())
                strTemp += Myreader["Question"].ToString() + "=" + Myreader["answer"].ToString() + Constants.vbCrLf;
            Myreader.Close();
            return strTemp;
        }

        public string CheckListDespatch(string callNum)
        {
            string strTemp = "";
            SqlDataReader Myreader;
            sqlCommand.CommandText = "SELECT * FROM CALL_CHECKLISTS WHERE call_num = '" + callNum + "' and type = 'despatch'";
            Myreader = sqlCommand.ExecuteReader();
            while (Myreader.Read())
                strTemp += Myreader["Question"].ToString() + "=" + Myreader["answer"].ToString() + Constants.vbCrLf;
            Myreader.Close();
            return strTemp;
        }

        public void AcknowledgeOsiCall(string strCallNum, string strNewCallNum)
        {
            sqlCommand.CommandText = "UPDATE CALLS SET call_num = '" + strNewCallNum + "' WHERE call_num = '" + strCallNum + "'";
            sqlCommand.ExecuteNonQuery();
        }

        public List<clsServiceCallsList.VehicleList> GetVehiclesList(string IncNum)
        {
            var Vehicles = new List<clsServiceCallsList.VehicleList>();
            SqlDataReader myReader;
            sqlCommand.CommandText = "SELECT distinct(Reference) FROM CALL_VEHICLES " + "INNER JOIN VEHICLES ON VEHICLES.ID = CALL_VEHICLES.Vehicle_id WHERE Call_Num = '" + IncNum + "'";
            myReader = sqlCommand.ExecuteReader();
            while (myReader.Read())
            {
                var item = new clsServiceCallsList.VehicleList();
                item.Reference = myReader["reference"].ToString();
                Vehicles.Add(item);
            }

            myReader.Close();
            return Vehicles;
        }
    }
}