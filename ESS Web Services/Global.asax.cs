using System;
using System.Web;

namespace ESS_Web_Services
{
    public class Global_asax : HttpApplication
    {
        public void Application_Start(object sender, EventArgs e)
        {
            // Fires when the application is started
            log4net.Config.XmlConfigurator.Configure();
        }

        public void Session_Start(object sender, EventArgs e)
        {
            // Fires when the session is started
        }

        public void Application_BeginRequest(object sender, EventArgs e)
        {
            // Fires at the beginning of each request
        }

        public void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // Fires upon attempting to authenticate the use
        }

        public void Application_Error(object sender, EventArgs e)
        {
            // Fires when an error occurs
        }

        public void Session_End(object sender, EventArgs e)
        {
            // Fires when the session ends
        }

        public void Application_End(object sender, EventArgs e)
        {
            // Fires when the application ends
        }
    }
}