using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DR.Services.WebAPI
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Clear the support for XML
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //Indent the Json results
            config.Formatters.JsonFormatter
                  .SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            //Camel case Json results
            config.Formatters.JsonFormatter
                  .SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        }
    }
}
