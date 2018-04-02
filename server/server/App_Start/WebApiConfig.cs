using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
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
                defaults: new { id = RouteParameter.Optional }
                //,
                //constraints: null,
                //handler:
                //   HttpClientFactory.CreatePipeline(
                //          new HttpControllerDispatcher(config),
                //          new DelegatingHandler[] { new AuthenticateHttpMessageHandler() })
            );
            // Ill be continuing cors from here - Rob
            /*
             * First Attribute is domain that is supported, have local host and our server's domain
             * Second Attribute are headers to support
             * Third is the what are supported in methods
             */
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            
        }
    }
}
