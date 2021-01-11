using System;
using System.Configuration;
using Microsoft.VisualBasic.CompilerServices;

namespace ESS_Web_Services
{
    public class dbServiceSites : IDisposable
    {
        private System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection();
        private System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
        private int _ID = 0;
        private string _Name = string.Empty;
        private string _PostUrl = string.Empty;
        private string _Key = string.Empty;

        public virtual void Dispose()
        {
            cn.Close();
            sqlCommand.Dispose();
        }

        public dbServiceSites()
        {
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["commsConnectionString"].ToString();
            cn.Open();
            sqlCommand.Connection = cn;
        }

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        public string PostUrl
        {
            get
            {
                return _PostUrl;
            }

            set
            {
                _PostUrl = value;
            }
        }

        public string Key
        {
            get
            {
                return _Key;
            }

            set
            {
                _Key = value;
            }
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
                    _Name = myReader["name"].ToString();
                    _PostUrl = myReader["Post_Url"].ToString();
                    _Key = myReader["Key"].ToString();
                }
            }
            catch (Exception ex)
            {
                if (!myReader.IsClosed)
                    myReader.Close();
                // Dim rmclass As New RMClass
                // rmclass.LogError("dbPriorities", "getitem", ex, sqlCommand.CommandText)
                // rmclass.Dispose()
                return ex.Message;
            }

            myReader.Close();
            return "";
        }

        public string GetItem(ref long id)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlCommand.CommandText = "SELECT * FROM Priorities WHERE id = @id";
            return ReadItem();
        }

        public string GetSitebyKey(ref string Key)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@Key", Key);
            sqlCommand.CommandText = "SELECT * FROM Service_Sites WHERE [key] = @Key";
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
            sqlCommand.CommandText = "SELECT ID FROM Service_Sites WHERE id = @id";
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
                sqlCommand.CommandText = "INSERT INTO SERVICE_SITES (name,Post_Url,[Key]) VALUES (" + "@Name,@PostUrl,@Key)";
                this.SetParameters();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Dim rmclass As New RMClass
                // rmclass.LogError("dbPriorities", "insert", ex, sqlCommand.CommandText)
                // rmclass.Dispose()
                return ex.Message;
            }

            return "";
        }

        private string Update(long id)
        {
            try
            {
                sqlCommand.CommandText = "UPDATE SERVICE_SITES SET " + "Name = @Name," + "post_url = @PostUrl," + "[key] = @Key" + "WHERE id = @id";



                this.SetParameters();
                sqlCommand.Parameters.AddWithValue("@ID", id);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Dim rmclass As New RMClass
                // rmclass.LogError("dbPriorities", "update", ex, sqlCommand.CommandText)
                // rmclass.Dispose()
                return ex.Message;
            }

            return "";
        }

        public void Delete(long id)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlCommand.CommandText = "DELETE FROM SERVICE_SITES WHERE ID = @ID";
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
            sqlCommand.Parameters.AddWithValue("@Name", _Name);
            sqlCommand.Parameters.AddWithValue("@PostUrl", _PostUrl);
            sqlCommand.Parameters.AddWithValue("@Key", _Key);

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