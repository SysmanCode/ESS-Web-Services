using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Services;
using log4net;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RestSharp;

namespace ESS_Web_Services
{

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // <System.Web.Script.Services.ScriptService()> _
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class PagingService : WebService
    {
        private ILog logger = LogManager.GetLogger("");

        [WebMethod()]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod()]
        public void SendPagerMessage(string PagerList)
        {
            
            foreach (var Pager in PList)
            {
                switch (Pager.PagerType.ToUpper() ?? "")
                {
                    case "GRAPEVINE":
                        {
                            SendGrapevineSMS(Pager.PagerNumber, Pager.PagerMessage, Pager.Reference);
                            break;
                        }

                    case "SYSMAN":
                        {
                            SendSysmanSMS(Pager.PagerNumber, Pager.PagerMessage, Pager.Reference);
                            break;
                        }

                    case "SOLAR":
                        {
                            SendSolarSMS(Pager.PagerNumber, Pager.PagerMessage, Pager.Reference);
                            break;
                        }
                }
            }
        }

        private void SendGrapevineSMS(string PagerNumber, string PagerMessage, string Reference)
        {
            PagerMessage += " (" + Strings.FormatDateTime(DateAndTime.Now, Constants.vbShortTime) + ")";
            try
            {
                string dt = Strings.Format(DateAndTime.Now, "yyyy-mm-ddTHH:mm:ss");
                string xmlText = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<gviSmsMessage xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" + "<originator>" + My.MySettingsProperty.Settings.GrapeVineAffiliate + "</originator>" + "<affiliateCode>" + My.MySettingsProperty.Settings.GrapeVineAffiliate + "</affiliateCode>" + "<authenticationCode>" + My.MySettingsProperty.Settings.GrapeVineAuthentication + "</authenticationCode>" + "<submitDateTime>" + dt + "</submitDateTime>" + "<messageType>Text</messageType>" + "<recipientList>" + "<message>" + PagerMessage + "</message>" + "<recipient>" + "<msisdn>" + PagerNumber + "</msisdn>" + "<customData>" + "<myRef>" + Reference + "</myRef>" + "</customData>" + "</recipient>" + "</recipientList>" + "</gviSmsMessage>";

                HttpWebRequest HttpWReq;
                HttpWebResponse HttpWResp;
                byte[] bytes;
                bytes = Encoding.ASCII.GetBytes(xmlText);
                string GUrl = My.MySettingsProperty.Settings.GrapeVineUrl.ToString();
                HttpWReq = (HttpWebRequest)WebRequest.Create(GUrl);
                HttpWReq.Method = "POST";
                HttpWReq.ContentType = "application/x-www-form-urlencoded";
                HttpWReq.ContentLength = bytes.Length;
                var myWriter = new StreamWriter(HttpWReq.GetRequestStream());
                myWriter.Write(xmlText);
                myWriter.Close();
                HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
                var myreader = new StreamReader(HttpWResp.GetResponseStream());
                string Retstring = myreader.ReadToEnd();
                myreader.Close();
                HttpWResp.Close();
            }
            catch (Exception ex)
            {
                logger.Error("sendgrapevinesms" + ex.ToString() + " " + PagerNumber + " " + Reference);
            }
        }

        private void SendSysmanSMS(string PagerMessage, string PagerNumber, string Reference)
        {
            PagerMessage += " (" + Strings.FormatDateTime(DateAndTime.Now, Constants.vbShortTime) + ")";
            logger.Info(PagerMessage);
            return;
            try
            {
                var rclient = new RestClient();
                string Apikey = My.MySettingsProperty.Settings.SysmanSmsID;
                string ApiSecret = My.MySettingsProperty.Settings.SysmanSmsKey;
                string ApiCredentials = $"{Apikey}:{ApiSecret}";
                var plainTextBytes = Encoding.UTF8.GetBytes(ApiCredentials);
                string base64Credentials = Convert.ToBase64String(plainTextBytes);
                rclient.BaseUrl = new Uri("https://rest.smsportal.com");
                var request = new RestRequest("/v1/Authentication", Method.GET);
                request.AddHeader("Authorization", "Basic " + base64Credentials);
                var response = rclient.Execute(request);
                string AuthToken = "";
                // log.Info(response.Content)
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string jsonresponse = response.Content;
                    var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonresponse);
                    AuthToken = values["token"];
                }
                else
                {
                    logger.Error("SendSysmanSms " + ((int)response.StatusCode).ToString() + " " + response.Content);
                }
                // 
                var SendRequest = new RestRequest("/v1/bulkmessages", Method.POST);
                SendRequest.AddHeader("Authorization", "Bearer " + AuthToken);
                var Message = new SysmanPagerMessage();
                var Message1 = new List<SysmanPagerMessage.MessageList>();
                Message1.Add(new SysmanPagerMessage.MessageList() { Content = PagerMessage, Destination = PagerNumber });
                Message.Messages = Message1;
                SendRequest.AddJsonBody(Message);
                response = rclient.Execute(SendRequest);
                // log.Info(response.Content)
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    logger.Error("SendSysmanSms " + ((int)response.StatusCode).ToString() + " " + response.Content);
                }
            }
            catch (Exception ex)
            {
                logger.Error("SendSysmanSms " + ex.ToString());
            }
        }

        private void SendSolarSMS(string PagerMessage, string PagerNumber, string Reference)
        {
            try
            {
                var rclient = new RestClient();
                var smsMsg = new SolarSmsMessage();
                smsMsg.message = PagerMessage;
                smsMsg.recipientNumber = PagerNumber;
                rclient.BaseUrl = new Uri("https://zoomconnect.com/app");
                var request = new RestRequest("/api/rest/v1/sms/send.json", Method.POST);
                request.AddHeader("email", My.MySettingsProperty.Settings.ZoomConnectUserName);
                request.AddHeader("token", My.MySettingsProperty.Settings.ZoomConnectToken);
                // Software@sysman.co.za
                // 397031f6-3894-4a51-9ffb-40a3648e0d92
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(smsMsg);
                RestResponse response = (RestResponse)rclient.Execute(request);
                string jsonresponse = ((int)response.StatusCode).ToString();
            }

            // LogError("SendSolarSMS", "Status = " & jsonresponse)
            catch (Exception ex)
            {
                logger.Error("SendSolarSMS" + ex.ToString() + " " + PagerNumber + " " + Reference);
            }
        }

        public class SolarSmsMessage
        {
            public string message { get; set; }
            public string recipientNumber { get; set; }
        }

        public class SysmanPagerMessage
        {
            public List<MessageList> Messages { get; set; }

            public class MessageList
            {
                public string Content { get; set; } = "";
                public string Destination { get; set; } = "";
            }
        }

        public class PagerList
        {
            public string PagerMessage { get; set; }
            public string PagerNumber { get; set; }
            public string PagerType { get; set; }
            public string Reference { get; set; }            
        }
    }
}