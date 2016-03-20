using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Extensions;


namespace ProductsApi
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {

            // Web API configuration and services
            var config = new HttpConfiguration();
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableCors();
            config.AddODataQueryFilter();
            config.Filters.Add(new AuthorizeAttribute());

            return config;
        }
    }



}
