using System;
using System.Collections.Generic;

namespace ESS_Web_Services
{
    public class clsSams30_Error
    {
        // SAMS30 Asset transfer
        public SolarErplist SolarERP { get; set; }

        public class SolarErplist
        {
            public HeaderList Header { get; set; }
            public PayloadList Payload { get; set; }
        }

        public class Message
        {
            public string Name { get; set; } = "Room and Financial transfer";
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
            public string Version { get; set; } = "3.1";
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
            public string RoomNo { get; set; }
            public string ResponsiblePersonCode { get; set; }
            public string FromCostCentre { get; set; }
            public string ToCostCentre { get; set; }
            public string User { get; set; }
            public string[] StatusMessages { get; set; }
        }
    }
}