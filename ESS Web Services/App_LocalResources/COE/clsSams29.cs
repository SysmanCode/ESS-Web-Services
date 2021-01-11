using System;
using System.Collections.Generic;

namespace ESS_Web_Services
{
    public class clsSams29
    {
        // SAMS29 Asset Disposal
        public SolarErplist SolarERP { get; set; }

        public class SolarErplist
        {
            public HeaderList Header { get; set; }
            public PayloadList Payload { get; set; }
        }

        public class Message
        {
            public string Name { get; set; } = "Disposal Approval";
            public string Type { get; set; } = "Response";
        }

        public class Result
        {
            public string Status { get; set; } = "SUCCESS";
            public string ErrorCode { get; set; }
            public string ErrorDescription { get; set; }
        }

        public class ContextList1
        {
            public ContextList Property { get; set; }
        }

        public class ContextList
        {
            public string Name { get; set; } = "Entity";
            public string Value { get; set; } = "CoE";
        }

        public class HeaderList
        {
            public string TimeStamp { get; set; } = DateTime.Now.ToString("o");
            public string CorrelationID { get; set; } = Guid.NewGuid().ToString();
            public string TransactionID { get; set; } = Guid.NewGuid().ToString();
            public string MessageID { get; set; } = Guid.NewGuid().ToString();
            public string SenderID { get; set; } = "DEMS";
            public string ReceipientID { get; set; } = "SAMS";
            public string Action { get; set; } = "update";
            public string SolarUser { get; set; } = "ESS";
            public Message Message { get; set; }
            public Result Result { get; set; }
            public List<ContextList1> Context { get; set; }
        }

        public class PayloadList
        {
            public string AssetNo { get; set; }
            public string ReturnedSoldInd { get; set; }
            public string SellingPrice { get; set; }
            public string FinPeriod { get; set; }
            public string User { get; set; }
            public string StatusMessages { get; set; } = "Success";
        }
    }
}