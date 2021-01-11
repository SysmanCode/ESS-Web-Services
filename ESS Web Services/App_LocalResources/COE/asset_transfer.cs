using System;
using System.Configuration;
using log4net;
using Microsoft.VisualBasic.CompilerServices;

namespace ESS_Web_Services
{
    public class DBAsset_Transfer : IDisposable
    {
        private ILog logger = LogManager.GetLogger("");
        private System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection();
        private System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
        private string _Assetno = string.Empty;
        private string _Roomno = string.Empty;
        private string _Responsiblepersoncode = string.Empty;
        private string _Fromcostcentre = string.Empty;
        private string _Tocostcentre = string.Empty;
        private string _User = string.Empty;

        public virtual void Dispose()
        {
            cn.Close();
            sqlCommand.Dispose();
        }

        public DBAsset_Transfer()
        {
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["commsConnectionString"].ToString();
            cn.Open();
            sqlCommand.Connection = cn;
        }

        public string Assetno
        {
            get
            {
                return _Assetno;
            }

            set
            {
                _Assetno = value;
            }
        }

        public string Roomno
        {
            get
            {
                return _Roomno;
            }

            set
            {
                _Roomno = value;
            }
        }

        public string Responsiblepersoncode
        {
            get
            {
                return _Responsiblepersoncode;
            }

            set
            {
                _Responsiblepersoncode = value;
            }
        }

        public string Fromcostcentre
        {
            get
            {
                return _Fromcostcentre;
            }

            set
            {
                _Fromcostcentre = value;
            }
        }

        public string Tocostcentre
        {
            get
            {
                return _Tocostcentre;
            }

            set
            {
                _Tocostcentre = value;
            }
        }

        public string User
        {
            get
            {
                return _User;
            }

            set
            {
                _User = value;
            }
        }

        public string GetItem(int intId)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", intId);
            sqlCommand.CommandText = "SELECT * FROM asset_transfer WHERE id = @id";
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
                    _Assetno = myReader["AssetNo"].ToString();
                    _Roomno = myReader["RoomNo"].ToString();
                    _Responsiblepersoncode = myReader["ResponsiblePersonCode"].ToString();
                    _Fromcostcentre = myReader["FromCostCentre"].ToString();
                    _Tocostcentre = myReader["ToCostCentre"].ToString();
                    _User = myReader["User"].ToString();
                }
            }
            catch (Exception ex)
            {
                if (!myReader.IsClosed)
                    myReader.Close();
                logger.Error("dbasset_transfer,getitem," + ex.ToString());
                return ex.Message;
            }

            myReader.Close();
            return "";
        }

        public string Save(int intId)
        {
            System.Data.SqlClient.SqlDataReader myReader;
            bool isItemFound = false;
            if (intId == 0)
            {
                return Insert();
            }

            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", intId);
            sqlCommand.CommandText = "SELECT ID FROM asset_transfer WHERE id = @id";
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
                sqlCommand.CommandText = "INSERT INTO asset_transfer (AssetNo,RoomNo,ResponsiblePersonCode,FromCostCentre,ToCostCentre,[User],Date_Created) VALUES (" + "@Assetno,@Roomno,@Responsiblepersoncode,@Fromcostcentre,@Tocostcentre,@User,getdate())";
                this.SetParameters();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Error("dbasset_transfer,insert," + ex.ToString());
                return ex.Message;
            }

            return "";
        }

        private string Update(int intId)
        {
            try
            {
                sqlCommand.CommandText = "UPDATE asset_transfer SET " + "AssetNo = @Assetno," + "RoomNo = @Roomno," + "ResponsiblePersonCode = @Responsiblepersoncode," + "FromCostCentre = @Fromcostcentre," + "ToCostCentre = @Tocostcentre," + "[User] = @User " + "WHERE id = @id";






                this.SetParameters();
                sqlCommand.Parameters.AddWithValue("@ID", intId);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Error("dbasset_transfer,update," + ex.ToString());
                return ex.Message;
            }

            return "";
        }

        public void Delete(int intId)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", intId);
            sqlCommand.CommandText = "DELETE FROM asset_transfer WHERE ID = @ID";
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
            sqlCommand.Parameters.AddWithValue("@Assetno", _Assetno);
            sqlCommand.Parameters.AddWithValue("@Roomno", _Roomno);
            sqlCommand.Parameters.AddWithValue("@Responsiblepersoncode", _Responsiblepersoncode);
            sqlCommand.Parameters.AddWithValue("@Fromcostcentre", _Fromcostcentre);
            sqlCommand.Parameters.AddWithValue("@Tocostcentre", _Tocostcentre);
            sqlCommand.Parameters.AddWithValue("@User", _User);
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