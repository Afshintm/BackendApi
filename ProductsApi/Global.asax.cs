using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac.Integration.WebApi;
using Ioc.Core.Infrastructure;

namespace ProductsApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

			// initialize engine context using the Ninja.Core
			// Running the Build method on the container
			// finding instances of IDependencyRegistrar and running its register method 

			EngineContext.Initialize(false);

			//set dependency resolver for webApi
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(EngineContext.Current.ContainerManager.Container);

			// set DependencyResolver for MVC 
			//DependencyResolver.SetResolver(new AutofacDependencyResolver(EngineContext.Current.ContainerManager.Container);


			GlobalConfiguration.Configure(WebApiConfig.Register);

        }
    }
}
