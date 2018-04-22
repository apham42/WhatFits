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
            // Web API routes
            config.MapHttpAttributeRoutes();


            // Enables cors in entire application
            config.EnableCors();

            // Creates routing for the application
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "v1/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: null,
                handler: HttpClientFactory.CreatePipeline(
                        new HttpControllerDispatcher(config),
                        new DelegatingHandler[] { new AuthenticateHandler() })
            );
        }
    }
}
