using System;
using System.Web.UI;
using System.Collections.Generic;

namespace ESS_Web_Services
{
    public partial class Test : Page
    {
        public Test()
        {
            this.Load += Page_Load;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<ServiceReferencePaging.PagerList> pagerList = new List<ServiceReferencePaging.PagerList>();
            ServiceReferencePaging.PagerList pagerDetails = new ServiceReferencePaging.PagerList();
            pagerDetails.PagerMessage = "test2";
            pagerDetails.PagerNumber= "12345";
            pagerDetails.PagerType= "Sysman";

            pagerList.Add(pagerDetails);

            ServiceReferencePaging.PagingService PService = new ServiceReferencePaging.PagingService();
                //PService.SendPagerMessageAsync(pagerList);

        }
    }
}