using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData.Extensions;


namespace ProductsApi
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register(HttpConfiguration Config)
        {
            // Web API configuration and services
            // var config = new HttpConfiguration();
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API configuration and services

            // Web API routes
           
            Config.MapHttpAttributeRoutes();

			Config.EnableCors(new EnableCorsAttribute("http://localhost:21575, http://localhost:37045, http://localhost:37046", "accept, authorization", "GET", "WWW-Authenticate"));
            //Config.EnableCors(new EnableCorsAttribute("*", "*", "*", "WWW-Authenticate")) ;

            Config.AddODataQueryFilter();

            //Config.MessageHandlers.Add(BearerAuthenticationTokenHandler);
            //Config.MessageHandlers.Add(BasicAuthenticationHandler); 

            Config.Filters.Add(new AuthorizeAttribute());

            return Config;
        }
    }



}
