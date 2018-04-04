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

            //
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
                // Commented out for ignoring tokens during develpment - Rob
                /*,
                constraints: null,
                handler:
                    HttpClientFactory.CreatePipeline(
                        new HttpControllerDispatcher(config),
                        new DelegatingHandler[] { new AuthenticateHttpMessageHandler() })
                //*/
            );

            // Enables cors in entire application
            config.EnableCors();
        }
    }
}
