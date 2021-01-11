using System;
using System.Collections.Generic;

namespace ESS_Web_Services
{
    public class clsServiceCalls
    {
        public IncidentList ESSIncident { get; set; }

        public class IncidentList
        {
            public string IncidentNumber { get; set; } 
            public DateTime Datetime { get; set; }
            public string Priority { get; set; } 
            public string Category { get; set; } 
            public string SubCategory { get; set; } 
            public string Location { get; set; } 
            public string LocationNumber { get; set; } 
            public string Floor { get; set; } 
            public string LocationTelelephone { get; set; } 
            public string Complex { get; set; } 
            public string Poi { get; set; }
            public string Street { get; set; } 
            public string StreetNumber { get; set; } 
            public string Suburb { get; set; } 
            public string Town { get; set; } 
            public string Xroad { get; set; } 
            public string Province { get; set; } 
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string Station { get; set; } 
            public string Status { get; set; } 
            public string ErrorDescription { get; set; } 
            public List<VehicleList> Vehicles { get; set; }
            public StatsList Statistics { get; set; }
        }

        public class VehicleList
        {
            public string Reference { get; set; }
        }

        public class StatsList
        {
            public DateTime CallTaken { get; set; }
            public DateTime CallAnswered { get; set; }
            public DateTime CallTransferred { get; set; }
            public DateTime CallAcknowledged { get; set; }
            public DateTime CallDespatched { get; set; }
            public DateTime VehArrived { get; set; }
            public DateTime LastVehLeft { get; set; }
            public DateTime CallClosed { get; set; }
        }
    }
}