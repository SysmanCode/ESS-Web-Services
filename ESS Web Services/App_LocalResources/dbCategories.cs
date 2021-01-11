using System;
using System.Configuration;
using Microsoft.VisualBasic.CompilerServices;

namespace ESS_Web_Services
{
    public class dbCategories : IDisposable
    {
        private System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection();
        private System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
        private int _ID = 0;
        private string _Category = string.Empty;
        private bool _NoDespatch = false;
        private bool _BookedCall = false;
        private bool _Deleted = false;
        private string _BellCode = string.Empty;
        private int _CallnumberId = 0;
        private bool _NoaddressFlag = false;

        public virtual void Dispose()
        {
            cn.Close();
            sqlCommand.Dispose();
        }

        public dbCategories()
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

        public bool NoDespatch
        {
            get
            {
                return _NoDespatch;
            }

            set
            {
                _NoDespatch = value;
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

        public int CallnumberId
        {
            get
            {
                return _CallnumberId;
            }

            set
            {
                _CallnumberId = value;
            }
        }

        public bool NoaddressFlag
        {
            get
            {
                return _NoaddressFlag;
            }

            set
            {
                _NoaddressFlag = value;
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
                    _ID = Conversions.ToInteger(myReader["ID"]);
                    _Category = myReader["Category"].ToString();
                    _NoDespatch = Conversions.ToBoolean(myReader["No_Despatch"]);
                    _BookedCall = Conversions.ToBoolean(myReader["booked_call"]);
                    _Deleted = Conversions.ToBoolean(myReader["deleted"]);
                    _BellCode = myReader["bell_code"].ToString();
                    _CallnumberId = Conversions.ToInteger(myReader["callnumber_id"]);
                    _NoaddressFlag = Conversions.ToBoolean(myReader["NoAddress_Flag"]);
                }
            }
            catch (Exception ex)
            {
                if (!myReader.IsClosed)
                    myReader.Close();
                // Dim rmclass As New RMClass
                // rmclass.LogError("dbCategories", "getitem",ex, sqlCommand.CommandText)
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
            sqlCommand.CommandText = "SELECT * FROM Categories WHERE id = @id";
            return ReadItem();
        }

        public string GetItemByName(ref string Category)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@Category", Category);
            sqlCommand.CommandText = "SELECT * FROM Categories WHERE Category = @Category";
            return ReadItem();
        }

        public string GetItemEmergency()
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.CommandText = "SELECT * FROM CATEGORIES WHERE category = 'Emergency' AND deleted <> 1";
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
            sqlCommand.CommandText = "SELECT ID FROM Categories WHERE id = @id";
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
                sqlCommand.CommandText = "INSERT INTO Categories (Category,No_Despatch,booked_call,deleted,bell_code,callnumber_id,NoAddress_Flag) VALUES (" + "@Category,@NoDespatch,@BookedCall,@Deleted,@BellCode,@CallnumberId,@NoaddressFlag)";
                this.SetParameters();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Dim rmclass As New RMClass
                // rmclass.LogError("dbCategories", "insert",ex, sqlCommand.CommandText)
                // rmclass.dispose()
                return ex.Message;
            }

            return "";
        }

        private string Update(long id)
        {
            try
            {
                sqlCommand.CommandText = "UPDATE Categories SET " + "Category = @Category," + "No_Despatch = @NoDespatch," + "booked_call = @BookedCall," + "deleted = @Deleted," + "bell_code = @BellCode," + "callnumber_id = @CallnumberId," + "NoAddress_Flag = @NoaddressFlag " + "WHERE id = @id";







                this.SetParameters();
                sqlCommand.Parameters.AddWithValue("@ID", id);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Dim rmclass As New RMClass
                // rmclass.LogError("dbCategories", "update",ex, sqlCommand.CommandText)
                // rmclass.dispose()
                return ex.Message;
            }

            return "";
        }

        public void Delete(long id)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlCommand.CommandText = "UPDATE Categories SET DELETED = 1 WHERE ID = @ID";
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
            sqlCommand.Parameters.AddWithValue("@Category", _Category);
            sqlCommand.Parameters.AddWithValue("@NoDespatch", _NoDespatch);
            sqlCommand.Parameters.AddWithValue("@BookedCall", _BookedCall);
            sqlCommand.Parameters.AddWithValue("@Deleted", _Deleted);
            sqlCommand.Parameters.AddWithValue("@BellCode", _BellCode);
            sqlCommand.Parameters.AddWithValue("@CallnumberId", _CallnumberId);
            sqlCommand.Parameters.AddWithValue("@NoaddressFlag", _NoaddressFlag);

                foreach (System.Data.SqlClient.SqlParameter _SqlParameter in sqlCommand.Parameters)
            {
                if (_SqlParameter.Value is null)
                {
                    _SqlParameter.Value = DBNull.Value;
                }
            }
        }
    }
}