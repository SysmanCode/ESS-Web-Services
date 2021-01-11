using System;
using System.Configuration;
using log4net;
using Microsoft.VisualBasic.CompilerServices;

namespace ESS_Web_Services
{
    public class DBAsset_Disposal : IDisposable
    {
        private ILog logger = LogManager.GetLogger("");
        private System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection();
        private System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
        private string _Assetno = string.Empty;
        private string _Returnedsoldind = string.Empty;
        private string _Sellingprice = string.Empty;
        private string _Finperiod = string.Empty;
        private string _User = string.Empty;

        public virtual void Dispose()
        {
            cn.Close();
            sqlCommand.Dispose();
        }

        public DBAsset_Disposal()
        {
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["commsconnectionString"].ToString();
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

        public string Returnedsoldind
        {
            get
            {
                return _Returnedsoldind;
            }

            set
            {
                _Returnedsoldind = value;
            }
        }

        public string Sellingprice
        {
            get
            {
                return _Sellingprice;
            }

            set
            {
                _Sellingprice = value;
            }
        }

        public string Finperiod
        {
            get
            {
                return _Finperiod;
            }

            set
            {
                _Finperiod = value;
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
            sqlCommand.CommandText = "SELECT * FROM asset_disposal WHERE id = @id";
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
                    _Returnedsoldind = myReader["ReturnedSoldInd"].ToString();
                    _Sellingprice = myReader["SellingPrice"].ToString();
                    _Finperiod = myReader["FinPeriod"].ToString();
                    _User = myReader["User"].ToString();
                }
            }
            catch (Exception ex)
            {
                if (!myReader.IsClosed)
                    myReader.Close();
                logger.Error("dbasset_disposal,getitem" + ex.ToString());
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
            sqlCommand.CommandText = "SELECT ID FROM asset_disposal WHERE id = @id";
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
                sqlCommand.CommandText = "INSERT INTO asset_disposal (AssetNo,ReturnedSoldInd,SellingPrice,FinPeriod,[User],Date_Created) VALUES (" + "@Assetno,@Returnedsoldind,@Sellingprice,@Finperiod,@User,getdate())";
                this.SetParameters();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Error("dbasset_disposal,insert," + ex.ToString());
                return ex.Message;
            }

            return "";
        }

        private string Update(int intId)
        {
            try
            {
                sqlCommand.CommandText = "UPDATE asset_disposal SET " + "AssetNo = @Assetno," + "ReturnedSoldInd = @Returnedsoldind," + "SellingPrice = @Sellingprice," + "FinPeriod = @Finperiod," + "[User] = @User " + "WHERE id = @id";





                this.SetParameters();
                sqlCommand.Parameters.AddWithValue("@ID", intId);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Error("dbasset_disposal,update," + ex.ToString());
                return ex.Message;
            }

            return "";
        }

        public void Delete(int intId)
        {
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@ID", intId);
            sqlCommand.CommandText = "DELETE FROM asset_disposal WHERE ID = @ID";
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
            sqlCommand.Parameters.AddWithValue("@Returnedsoldind", _Returnedsoldind);
            sqlCommand.Parameters.AddWithValue("@Sellingprice", _Sellingprice);
            sqlCommand.Parameters.AddWithValue("@Finperiod", _Finperiod);
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