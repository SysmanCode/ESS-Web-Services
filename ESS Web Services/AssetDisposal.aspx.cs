using System;
using System.IO;
using System.Web;
using System.Web.UI;
using log4net;
using Newtonsoft.Json;

namespace ESS_Web_Services
{
    public partial class AssetDisposal : Page
    {
        public AssetDisposal()
        {
            this.Load += Page_Load;
        }

        private ILog logger = LogManager.GetLogger("");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    string strResponse = "";
                    var reader = new StreamReader(HttpContext.Current.Request.InputStream);
                    string content = reader.ReadToEnd();
                    logger.Info(content);
                    var clsSams29 = new clsSams29();
                    clsSams29 = JsonConvert.DeserializeObject<clsSams29>(content);
                    var clsVehicleDb = new clsVehiclesDB();
                    int VehID = 0;
                    string argassetNo = clsSams29.SolarERP.Payload.AssetNo;
                    clsVehicleDb.GetItemByAssetNo(ref argassetNo);
                    clsSams29.SolarERP.Payload.AssetNo = argassetNo;
                    VehID = clsVehicleDb.ID;
                    clsVehicleDb.Dispose();
                    if (VehID > 0)
                    {
                        // found in vehicles db

                        var clsDbAssetDisposal = new DBAsset_Disposal();
                        clsDbAssetDisposal.Assetno = clsSams29.SolarERP.Payload.AssetNo;
                        clsDbAssetDisposal.Returnedsoldind = clsSams29.SolarERP.Payload.ReturnedSoldInd;
                        clsDbAssetDisposal.Finperiod = clsSams29.SolarERP.Payload.FinPeriod;
                        clsDbAssetDisposal.Sellingprice = clsSams29.SolarERP.Payload.SellingPrice;
                        clsDbAssetDisposal.User = clsSams29.SolarERP.Payload.User;
                        clsDbAssetDisposal.Save(0);
                        clsDbAssetDisposal.Dispose();
                        clsSams29.SolarERP.Header.ReceipientID = "SAMS";
                        clsSams29.SolarERP.Header.SenderID = "DEMS";
                        clsSams29.SolarERP.Header.Action = "update";
                        clsSams29.SolarERP.Header.Result.Status = "SUCCESS";
                        strResponse = JsonConvert.SerializeObject(clsSams29);
                    }
                    else
                    {
                        var clsSams29Error = new clsSams29_Error();
                        clsSams29Error = JsonConvert.DeserializeObject<clsSams29_Error>(content);
                        clsSams29Error.SolarERP.Header.ReceipientID = "SAMS";
                        clsSams29Error.SolarERP.Header.SenderID = "DEMS";
                        clsSams29Error.SolarERP.Header.Action = "update";
                        clsSams29Error.SolarERP.Header.Result.Status = "FAILURE";
                        var ErrorMsg = new[] { "Asset number is not found on the system" };
                        clsSams29Error.SolarERP.Payload.StatusMessages = ErrorMsg;
                        strResponse = JsonConvert.SerializeObject(clsSams29Error);
                    }

                    Response.Clear();
                    Response.ContentType = "application/json";
                    Response.Write(strResponse);
                    Response.Flush();
                    Response.SuppressContent = true;
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                    Context.Response.Write(ex.Message);
                    logger.Error("CoeServices.asmx,AssetDisposal," + ex.ToString());
                }
            }
        }
    }
}