using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Extensions;


namespace ProductsApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.EnableCors();
			config.AddODataQueryFilter();
	        
	        //config.Routes.MapHttpRoute(
	        //	name: "DefaultApi", 
	        //	routeTemplate: "api/{controller}/{action}/id", 
	        //	defaults: new {controller = "Products", action = "GetAll", id = RouteParameter.Optional});

	        //config.Routes.MapHttpRoute(
	        //	name: "DefaultApi",
	        //	routeTemplate: "api/{controller}/{id}",
	        //	defaults: new { id = RouteParameter.Optional}
	        //);
        }
    }
}
