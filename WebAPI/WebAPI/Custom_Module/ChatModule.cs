using System;
using System.Web;

namespace WebAPI.Custom_Module
{
    public class ChatModule : IHttpModule
    {
        DateTime beginrequestTime;
        public ChatModule()
        {

        }

        public String ModuleName
        {
            get { return "This is ChatModule"; }
        }

        // If this module requires cleanup
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication application)
        {
            // Register for events created by the pipeline
            application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
            application.EndRequest += (new EventHandler(this.Application_EndRequest));
        }

        public void Application_BeginRequest(Object source, EventArgs e)
        {
            // Obtain the time of the current request
            beginrequestTime = DateTime.Now;

            // Create HttpApplication and HttpContext objects to access request and response properties.
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;

            string filePath = context.Request.FilePath;
            string fileExtension =
                VirtualPathUtility.GetExtension(filePath);
            if (fileExtension.Equals(".aspx"))
            {
                context.Response.Write("<h1><font color=red>" +
                    "ChatModule: Beginning of Request" +
                    "</font></h1><hr>");
            }
        }

        private void Application_EndRequest(Object source, EventArgs e)
        {
            // Get the time elapsed for the request
            TimeSpan elapsedtime = DateTime.Now - beginrequestTime;

            // Get access to application object and context object
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;


            string filePath = context.Request.FilePath;
            string fileExtension =
                VirtualPathUtility.GetExtension(filePath);
            if (fileExtension.Equals(".aspx"))
            {
                context.Response.Write("<hr><h1><font color=red>" +
                    "ChatModule: End of Request</font></h1>");
            }
        }
    }
}