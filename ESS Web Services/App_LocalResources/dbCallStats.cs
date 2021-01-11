using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ESS_Web_Services
{
    public class dbCallStats : IDisposable
    {
        private SqlConnection cn = new SqlConnection();
        private SqlCommand sqlCommand = new SqlCommand();
        private string _CallNum = string.Empty;
        private int _NumVehicles = 0;
        private string _Station = string.Empty;
        private string _Yymm = string.Empty;
        private string _TakenBy = string.Empty;
        private DateTime _CallTaken = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _CallAnswered = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _CallTransferred = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _CallAcknowledged = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _CallDespatched = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _VehArrived = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _LastVehLeft = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _CallClosed = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _VehMobile = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _AtHospital = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _MobHospital = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _StopStatus = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _DampingDown = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _MakingUp = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _GettingTowork = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private DateTime _CancelledIncident = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;
        private bool _Booked = false;
        private string _DespatchOperator = string.Empty;
        private double _Latitude = 0d;
        private double _Longitude = 0d;
        private string _VehDespatchedRef = string.Empty;
        private string _VeharrivedRef = string.Empty;
        private string _VehmobileRef = string.Empty;
        private string _VehleftRef = string.Empty;
        private string _VehathospitalRef = string.Empty;
        private string _VehmobhospitalRef = string.Empty;
        private string _VehstopRef = string.Empty;
        private string _VehmakingupRef = string.Empty;
        private string _TransportedTo = string.Empty;
        private DateTime _CallAckStart = (DateTime)System.Data.SqlTypes.SqlDateTime.Null;

        public virtual void Dispose()
        {
            cn.Close();
            sqlCommand.Dispose();
        }

        public dbCallStats()
        {
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["essConnectionString"].ToString();
            cn.Open();
            sqlCommand.Connection = cn;
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

        public DateTime CallTaken
        {
            get
            {
                return _CallTaken;
            }

            set
            {
                _CallTaken = value;
            }
        }

        public DateTime CallAnswered
        {
            get
            {
                return _CallAnswered;
            }

            set
            {
                _CallAnswered = value;
            }
        }

        public DateTime CallTransferred
        {
            get
            {
                return _CallTransferred;
            }

            set
            {
                _CallTransferred = value;
            }
        }

        public DateTime CallAcknowledged
        {
            get
            {
                return _CallAcknowledged;
            }

            set
            {
                _CallAcknowledged = value;
            }
        }

        public DateTime CallDespatched
        {
            get
            {
                return _CallDespatched;
            }

            set
            {
                _CallDespatched = value;
            }
        }

        public DateTime VehArrived
        {
            get
            {
                return _VehArrived;
            }

            set
            {
                _VehArrived = value;
            }
        }

        public DateTime LastVehLeft
        {
            get
            {
                return _LastVehLeft;
            }

            set
            {
                _LastVehLeft = value;
            }
        }

        public DateTime CallClosed
        {
            get
            {
                return _CallClosed;
            }

            set
            {
                _CallClosed = value;
            }
        }

        public string Yymm
        {
            get
            {
                return _Yymm;
            }

            set
            {
                _Yymm = value;
            }
        }

        public DateTime VehMobile
        {
            get
            {
                return _VehMobile;
            }

            set
            {
                _VehMobile = value;
            }
        }

        public int NumVehicles
        {
            get
            {
                return _NumVehicles;
            }

            set
            {
                _NumVehicles = value;
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

        public DateTime AtHospital
        {
            get
            {
                return _AtHospital;
            }

            set
            {
                _AtHospital = value;
            }
        }

        public string TakenBy
        {
            get
            {
                return _TakenBy;
            }

            set
            {
                _TakenBy = value;
            }
        }

        public DateTime MobHospital
        {
            get
            {
                return _MobHospital;
            }

            set
            {
                _MobHospital = value;
            }
        }

        public DateTime StopStatus
        {
            get
            {
                return _StopStatus;
            }

            set
            {
                _StopStatus = value;
            }
        }

        public DateTime DampingDown
        {
            get
            {
                return _DampingDown;
            }

            set
            {
                _DampingDown = value;
            }
        }

        public DateTime MakingUp
        {
            get
            {
                return _MakingUp;
            }

            set
            {
                _MakingUp = value;
            }
        }

        public bool Booked
        {
            get
            {
                return _Booked;
            }

            set
            {
                _Booked = value;
            }
        }

        public string DespatchOperator
        {
            get
            {
                return _DespatchOperator;
            }

            set
            {
                _DespatchOperator = value;
            }
        }

        public DateTime GettingTowork
        {
            get
            {
                return _GettingTowork;
            }

            set
            {
                _GettingTowork = value;
            }
        }

        public DateTime CancelledIncident
        {
            get
            {
                return _CancelledIncident;
            }

            set
            {
                _CancelledIncident = value;
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

        public string VeharrivedRef
        {
            get
            {
                return _VeharrivedRef;
            }

            set
            {
                _VeharrivedRef = value;
            }
        }

        public string VehDespatchedRef
        {
            get
            {
                return _VehDespatchedRef;
            }

            set
            {
                _VehDespatchedRef = value;
            }
        }

        public string VehmobileRef
        {
            get
            {
                return _VehmobileRef;
            }

            set
            {
                _VehmobileRef = value;
            }
        }

        public string VehleftRef
        {
            get
            {
                return _VehleftRef;
            }

            set
            {
                _VehleftRef = value;
            }
        }

        public string VehathospitalRef
        {
            get
            {
                return _VehathospitalRef;
            }

            set
            {
                _VehathospitalRef = value;
            }
        }

        public string VehmobhospitalRef
        {
            get
            {
                return _VehmobhospitalRef;
            }

            set
            {
                _VehmobhospitalRef = value;
            }
        }

        public string VehstopRef
        {
            get
            {
                return _VehstopRef;
            }

            set
            {
                _VehstopRef = value;
            }
        }

        public string VehmakingupRef
        {
            get
            {
                return _VehmakingupRef;
            }

            set
            {
                _VehmakingupRef = value;
            }
        }

        public string TransportedTo
        {
            get
            {
                return _TransportedTo;
            }

            set
            {
                _TransportedTo = value;
            }
        }

        public DateTime CallAckStart
        {
            get
            {
                return _CallAckStart;
            }

            set
            {
                _CallAckStart = value;
            }
        }

        public string GetItem(string CallNum)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@CallNum", CallNum);
            sqlCommand.CommandText = "SELECT * FROM callstats WHERE Call_Num = @CallNum";
            return ReadItem();
        }

        public string ReadItem()
        {
            SqlDataReader myReader;
            myReader = sqlCommand.ExecuteReader();
            myReader.Read();
            try
            {
                if (myReader.HasRows)
                {
                    _CallNum = myReader["Call_Num"].ToString();
                    if (!Information.IsDBNull(myReader["Call_Taken"]))
                        _CallTaken = Conversions.ToDate(myReader["Call_Taken"]);
                    if (!Information.IsDBNull(myReader["Call_Answered"]))
                        _CallAnswered = Conversions.ToDate(myReader["Call_Answered"]);
                    if (!Information.IsDBNull(myReader["Call_Transferred"]))
                        _CallTransferred = Conversions.ToDate(myReader["Call_Transferred"]);
                    if (!Information.IsDBNull(myReader["Call_Acknowledged"]))
                        _CallAcknowledged = Conversions.ToDate(myReader["Call_Acknowledged"]);
                    if (!Information.IsDBNull(myReader["Call_Ack_Start"]))
                        _CallAckStart = Conversions.ToDate(myReader["Call_Ack_Start"]);
                    if (!Information.IsDBNull(myReader["Call_Despatched"]))
                        _CallDespatched = Conversions.ToDate(myReader["Call_Despatched"]);
                    if (!Information.IsDBNull(myReader["Veh_Arrived"]))
                        _VehArrived = Conversions.ToDate(myReader["Veh_Arrived"]);
                    if (!Information.IsDBNull(myReader["Last_Veh_left"]))
                        _LastVehLeft = Conversions.ToDate(myReader["Last_Veh_left"]);
                    if (!Information.IsDBNull(myReader["Call_Closed"]))
                        _CallClosed = Conversions.ToDate(myReader["Call_Closed"]);
                    if (!Information.IsDBNull(myReader["Veh_Mobile"]))
                        _VehMobile = Conversions.ToDate(myReader["Veh_Mobile"]);
                    if (!Information.IsDBNull(myReader["At_Hospital"]))
                        _AtHospital = Conversions.ToDate(myReader["At_Hospital"]);
                    if (!Information.IsDBNull(myReader["mob_hospital"]))
                        _MobHospital = Conversions.ToDate(myReader["mob_hospital"]);
                    if (!Information.IsDBNull(myReader["Stop"]))
                        _StopStatus = Conversions.ToDate(myReader["Stop"]);
                    if (!Information.IsDBNull(myReader["Damping_Down"]))
                        _DampingDown = Conversions.ToDate(myReader["Damping_Down"]);
                    if (!Information.IsDBNull(myReader["Making_Up"]))
                        _MakingUp = Conversions.ToDate(myReader["Making_Up"]);
                    if (!Information.IsDBNull(myReader["Getting_ToWork"]))
                        _GettingTowork = Conversions.ToDate(myReader["Getting_ToWork"]);
                    if (!Information.IsDBNull(myReader["Cancelled_Incident"]))
                        _CancelledIncident = Conversions.ToDate(myReader["Cancelled_Incident"]);
                    _Yymm = myReader["YYMM"].ToString();
                    _NumVehicles = Conversions.ToInteger(myReader["Num_Vehicles"]);
                    _Station = myReader["Station"].ToString();
                    _TakenBy = myReader["taken_by"].ToString();
                    _Booked = Conversions.ToBoolean(myReader["booked"]);
                    _DespatchOperator = myReader["despatch_operator"].ToString();
                    _Latitude = Conversions.ToDouble(myReader["latitude"]);
                    _Longitude = Conversions.ToDouble(myReader["longitude"]);
                    _VeharrivedRef = myReader["VehArrived_Ref"].ToString();
                    _VehmobileRef = myReader["VehMobile_Ref"].ToString();
                    _VehleftRef = myReader["VehLeft_Ref"].ToString();
                    _VehathospitalRef = myReader["VehAtHospital_Ref"].ToString();
                    _VehmobhospitalRef = myReader["VehMobHospital_Ref"].ToString();
                    _VehstopRef = myReader["VehStop_Ref"].ToString();
                    _VehmakingupRef = myReader["VehMakingUp_Ref"].ToString();
                    _VehDespatchedRef = myReader["VehDespatched_Ref"].ToString();
                    _TransportedTo = myReader["transported_to"].ToString();
                }
            }
            catch (Exception ex)
            {
                if (!myReader.IsClosed)
                    myReader.Close();
                //var rmclass = new RMClass();
                //rmclass.LogError("dbcallstats", "getitem", ex, sqlCommand.CommandText);
                //rmclass.Dispose();
                return ex.Message;
            }

            myReader.Close();
            return "";
        }

        public string Save(string CallNum)
        {
            SqlDataReader myReader;
            bool isItemFound = false;
            if (string.IsNullOrEmpty(CallNum))
            {
                return Insert();
            }

            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@CallNum", CallNum);
            sqlCommand.CommandText = "SELECT ID FROM callstats WHERE Call_Num = @CallNum";
            myReader = sqlCommand.ExecuteReader();
            myReader.Read();
            if (myReader.HasRows)
                isItemFound = true;
            myReader.Close();
            if (isItemFound)
            {
                return Update(CallNum);
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
                sqlCommand.CommandText = "INSERT INTO callstats (Call_Num,Call_Taken,Call_Transferred,Call_Acknowledged,Call_Despatched,Veh_Arrived,Last_Veh_left,Call_Closed,YYMM,Veh_Mobile,Num_Vehicles,Station,At_Hospital,taken_by,mob_hospital,Stop,Damping_Down,Making_Up,booked,despatch_operator,Getting_ToWork,latitude,longitude,VehArrived_Ref,VehMobile_Ref,VehLeft_Ref,VehAtHospital_Ref,VehMobHospital_Ref,VehStop_Ref,VehMakingUp_Ref,VehDespatched_Ref,call_answered,Cancelled_Incident,transported_to,Call_Ack_Start) VALUES (" + "@CallNum,@CallTaken,@CallTransferred,@CallAcknowledged,@CallDespatched,@VehArrived,@LastVehLeft,@CallClosed,@Yymm,@VehMobile,@NumVehicles,@Station,@AtHospital,@TakenBy,@MobHospital,@Stop,@DampingDown,@MakingUp,@Booked,@DespatchOperator,@GettingTowork,@Latitude,@Longitude,@VeharrivedRef,@VehmobileRef,@VehleftRef,@VehathospitalRef,@VehmobhospitalRef,@VehstopRef,@VehmakingupRef,@VehDespatchedRef,@CallAnswered,@CancelledIncident,@TransportedTo,@CallAckStart)";
                SetParameters();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               //var rmclass = new RMClass();
               // rmclass.LogError("dbcallstats", "insert", ex, sqlCommand.CommandText + " " + ex.StackTrace);
                //rmclass.Dispose();
                return ex.Message;
            }

            return "";
        }

        private string Update(string CallNum)
        {
            try
            {
                sqlCommand.CommandText = "UPDATE callstats SET " + "Call_Num = @CallNum," + "Call_Taken = @CallTaken," + "Call_Answered = @CallAnswered," + "Call_Transferred = @CallTransferred," + "Call_Acknowledged = @CallAcknowledged," + "Call_Ack_Start = @CallAckStart," + "Call_Despatched = @CallDespatched," + "Veh_Arrived = @VehArrived," + "Last_Veh_left = @LastVehLeft," + "Call_Closed = @CallClosed," + "YYMM = @Yymm," + "Veh_Mobile = @VehMobile," + "Num_Vehicles = @NumVehicles," + "Station = @Station," + "At_Hospital = @AtHospital," + "taken_by = @TakenBy," + "mob_hospital = @MobHospital," + "Stop = @Stop," + "Damping_Down = @DampingDown," + "Making_Up = @MakingUp," + "booked = @Booked," + "despatch_operator = @DespatchOperator," + "Getting_ToWork = @GettingTowork," + "Cancelled_Incident = @CancelledIncident," + "latitude = @Latitude," + "longitude = @Longitude," + "VehDespatched_Ref = @VehDespatchedRef," + "VehArrived_Ref = @VeharrivedRef," + "VehMobile_Ref = @VehmobileRef," + "VehLeft_Ref = @VehleftRef," + "VehAtHospital_Ref = @VehathospitalRef," + "VehMobHospital_Ref = @VehmobhospitalRef," + "VehStop_Ref = @VehstopRef," + "VehMakingUp_Ref = @VehmakingupRef," + "transported_to = @TransportedTo " + "WHERE Call_Num = @CallNum";

                SetParameters();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //var rmclass = new RMClass();
                //rmclass.LogError("dbcallstats", "update", ex, sqlCommand.CommandText);
                //rmclass.Dispose();
                return ex.Message;
            }

            return "";
        }

        public void Delete(int intId)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", intId);
            sqlCommand.CommandText = "DELETE FROM callstats WHERE ID = @ID";
            sqlCommand.ExecuteNonQuery();
        }

        public int GetLastid()
        {
            SqlDataReader Myreader;
            int Newid;
            sqlCommand.CommandText = "SELECT @@IDENTITY as Newid";
            Myreader = sqlCommand.ExecuteReader();
            Myreader.Read();
            Newid = Conversions.ToInteger(Myreader["NewID"]);
            Myreader.Close();
            return Newid;
        }

        public void ReOpenCall(string strCallnum)
        {
            sqlCommand.CommandText = "UPDATE CALLSTATS SET Call_num = '" + strCallnum + "/1' WHERE call_num = '" + strCallnum + "'";
            sqlCommand.ExecuteNonQuery();
        }

        private void SetParameters()
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@CallNum", _CallNum);
            sqlCommand.Parameters.AddWithValue("@VehDespatchedRef", _VehDespatchedRef);
            sqlCommand.Parameters.AddWithValue("@VehArrivedRef", _VeharrivedRef);
            sqlCommand.Parameters.AddWithValue("@VehMobileRef", _VehmobileRef);
            sqlCommand.Parameters.AddWithValue("@VehStopRef", _VehstopRef);
            sqlCommand.Parameters.AddWithValue("@VehAtHospitalRef", _VehathospitalRef);
            sqlCommand.Parameters.AddWithValue("@VehMobHospitalRef", _VehmobhospitalRef);
            sqlCommand.Parameters.AddWithValue("@VehMakingUpRef", _VehmakingupRef);
            sqlCommand.Parameters.AddWithValue("@VehLeftRef", _VehleftRef);
            sqlCommand.Parameters.AddWithValue("@Yymm", _Yymm);
            sqlCommand.Parameters.AddWithValue("@NumVehicles", _NumVehicles);
            sqlCommand.Parameters.AddWithValue("@Station", _Station);
            sqlCommand.Parameters.AddWithValue("@TakenBy", _TakenBy);
            sqlCommand.Parameters.AddWithValue("@Booked", _Booked);
            sqlCommand.Parameters.AddWithValue("@DespatchOperator", _DespatchOperator);
            sqlCommand.Parameters.AddWithValue("@Latitude", _Latitude);
            sqlCommand.Parameters.AddWithValue("@Longitude", _Longitude);
            sqlCommand.Parameters.AddWithValue("@TransportedTo", _TransportedTo);
            sqlCommand.Parameters.AddWithValue("@CallTaken", _CallTaken);
            sqlCommand.Parameters.AddWithValue("@CallAnswered", _CallAnswered);
            sqlCommand.Parameters.AddWithValue("@CallTransferred", _CallTransferred);
            sqlCommand.Parameters.AddWithValue("@CallAcknowledged", _CallAcknowledged);
            sqlCommand.Parameters.AddWithValue("@CallAckStart", _CallAckStart);
            sqlCommand.Parameters.AddWithValue("@CallDespatched", _CallDespatched);
            sqlCommand.Parameters.AddWithValue("@VehArrived", _VehArrived);
            sqlCommand.Parameters.AddWithValue("@LastVehLeft", _LastVehLeft);
            sqlCommand.Parameters.AddWithValue("@CallClosed", _CallClosed);
            sqlCommand.Parameters.AddWithValue("@VehMobile", _VehMobile);
            sqlCommand.Parameters.AddWithValue("@AtHospital", _AtHospital);
            sqlCommand.Parameters.AddWithValue("@MobHospital", _MobHospital);
            sqlCommand.Parameters.AddWithValue("@Stop", _StopStatus);
            sqlCommand.Parameters.AddWithValue("@DampingDown", _DampingDown);
            sqlCommand.Parameters.AddWithValue("@MakingUp", _MakingUp);
            sqlCommand.Parameters.AddWithValue("@GettingTowork", _GettingTowork);
            sqlCommand.Parameters.AddWithValue("@CancelledIncident", _CancelledIncident);
                       
        }

    }
}