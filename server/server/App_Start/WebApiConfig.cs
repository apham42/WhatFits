using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Whatfits.UserAccessControl.Controller;

namespace server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }//,
                //constraints: null,
                /*
                handler:
                   HttpClientFactory.CreatePipeline(
                          new HttpControllerDispatcher(config),
                          new DelegatingHandler[] { new AuthenticateHttpMessageHandler() })
                          */
            );
        }
    }
}
