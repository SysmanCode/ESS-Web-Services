using System;
using System.Configuration;
using Microsoft.VisualBasic.CompilerServices;

namespace ESS_Web_Services
{
    public class dbPriorities : IDisposable
    {
        private System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection();
        private System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
        private int _ID = 0;
        private string _Priority = string.Empty;
        private string _Colour = string.Empty;
        private string _Description = string.Empty;

        public virtual void Dispose()
        {
            cn.Close();
            sqlCommand.Dispose();
        }

        public dbPriorities()
        {
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["essConnectionString"].ToString();
            cn.Open();
            sqlCommand.Connection = cn;
        }

        public string Priority
        {
            get
            {
                return _Priority;
            }

            set
            {
                _Priority = value;
            }
        }

        public string Colour
        {
            get
            {
                return _Colour;
            }

            set
            {
                _Colour = value;
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }

            set
            {
                _Description = value;
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
                    _Priority = myReader["Priority"].ToString();
                    _Colour = myReader["Colour"].ToString();
                    _Description = myReader["description"].ToString();
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

        public string GetPriorityId(ref string priority)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@Priority", priority);
            sqlCommand.CommandText = "SELECT * FROM Priorities WHERE priority = @Priority";
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
            sqlCommand.CommandText = "SELECT ID FROM Priorities WHERE id = @id";
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
                sqlCommand.CommandText = "INSERT INTO Priorities (Priority,Colour,Description) VALUES (" + "@Priority,@Colour,@Description)";
                SetParameters();
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
                sqlCommand.CommandText = "UPDATE Priorities SET " + "Priority = @Priority," + "Colour = @Colour," + "Description = @Description " + "WHERE id = @id";



                SetParameters();
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
            sqlCommand.CommandText = "DELETE FROM Priorities WHERE ID = @ID";
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

        private void SetParameters()
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@Priority", _Priority);
            sqlCommand.Parameters.AddWithValue("@Colour", _Colour);
            sqlCommand.Parameters.AddWithValue("@Description", _Description);
            foreach (System.Data.SqlClient.SqlParameter _SqlParameter in sqlCommand.Parameters)
            {
                if (_SqlParameter.Value is null)
                {
                    _SqlParameter.Value = DBNull.Value;
                }
            }
        }

        public bool CanDelete(object id)
        {
            System.Data.SqlClient.SqlDataReader Myreader;
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlCommand.CommandText = "SELECT id FROM CALLS WHERE priority_id = @ID";
            Myreader = sqlCommand.ExecuteReader();
            Myreader.Read();
            if (Myreader.HasRows)
            {
                Myreader.Close();
                return false;
            }

            Myreader.Close();
            return true;
        }
    }
}