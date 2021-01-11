using System;
using System.IO;
using System.Web;
using System.Web.UI;
using log4net;
using Newtonsoft.Json;

namespace ESS_Web_Services
{
    public partial class AssetTransfer : Page
    {
        public AssetTransfer()
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
                    var reader = new StreamReader(HttpContext.Current.Request.InputStream);
                    string content = reader.ReadToEnd();
                    string strResponse = "";
                    logger.Info(content);
                    var clsSams30 = new clsSams30();
                    clsSams30 = JsonConvert.DeserializeObject<clsSams30>(content);
                    var clsVehicleDb = new clsVehiclesDB();
                    int VehID = 0;
                    string argassetNo = clsSams30.SolarERP.Payload.AssetNo;
                    clsVehicleDb.GetItemByAssetNo(ref argassetNo);
                    clsSams30.SolarERP.Payload.AssetNo = argassetNo;
                    VehID = clsVehicleDb.ID;
                    clsVehicleDb.Dispose();
                    if (VehID > 0)
                    {
                        // found in vehicles db

                        var clsDbAssetTransfer = new DBAsset_Transfer();
                        clsDbAssetTransfer.Assetno = clsSams30.SolarERP.Payload.AssetNo;
                        clsDbAssetTransfer.Fromcostcentre = clsSams30.SolarERP.Payload.FromCostCentre;
                        clsDbAssetTransfer.Responsiblepersoncode = clsSams30.SolarERP.Payload.ResponsiblePersonCode;
                        clsDbAssetTransfer.Tocostcentre = clsSams30.SolarERP.Payload.ToCostCentre;
                        clsDbAssetTransfer.Roomno = clsSams30.SolarERP.Payload.RoomNo;
                        clsDbAssetTransfer.User = clsSams30.SolarERP.Payload.User;
                        clsDbAssetTransfer.Save(0);
                        clsDbAssetTransfer.Dispose();
                        clsSams30.SolarERP.Header.ReceipientID = "SAMS";
                        clsSams30.SolarERP.Header.SenderID = "DEMS";
                        clsSams30.SolarERP.Header.Action = "update";
                        clsSams30.SolarERP.Header.Result.Status = "SUCCESS";
                        strResponse = JsonConvert.SerializeObject(clsSams30);
                    }
                    else
                    {
                        var clsSams30Error = new clsSams30_Error();
                        clsSams30Error = JsonConvert.DeserializeObject<clsSams30_Error>(content);
                        clsSams30Error.SolarERP.Header.ReceipientID = "SAMS";
                        clsSams30Error.SolarERP.Header.SenderID = "DEMS";
                        clsSams30Error.SolarERP.Header.Action = "update";
                        clsSams30Error.SolarERP.Header.Result.Status = "FAILURE";
                        var ErrorMsg = new[] { "Asset number is not found on the system" };
                        clsSams30Error.SolarERP.Payload.StatusMessages = ErrorMsg;
                        strResponse = JsonConvert.SerializeObject(clsSams30Error);
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
                    logger.Error("CoeServices.asmx,AssetTransfer," + ex.ToString());
                }
            }
        }
    }
}