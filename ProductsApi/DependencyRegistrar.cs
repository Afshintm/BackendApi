using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using DataAccess;
using Infrastructure;
using Ioc.Core.Infrastructure;
using Ioc.Core.Infrastructure.DependencyManagement;
using BusinessServices;
using SalesModel;
using System;

namespace ProductsApi
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order
        {
            get { return 0; }
        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //HTTP context and other related stuff
            builder.Register(c => new HttpContextWrapper(HttpContext.Current) as HttpContextBase)
                .As<HttpContextBase>()
                .InstancePerRequest();

            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerRequest();

            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerRequest();

            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerRequest();

            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerRequest();

            //We need one configuration throughout the application
            builder.RegisterType<Config>().As<IConfig>().SingleInstance();

            //We need one ExceptionHandller for each request
            builder.RegisterType<ExceptionHandler>().As<IExceptionHandler>().InstancePerRequest();

            // sharing a Logger component for all dependents in each lifetime scope which is effectively HttpRequest
            builder.RegisterType<Logger>().As<ILogger>().InstancePerLifetimeScope();


            // securityProvider component is registered for each request in which the session is unique 
            builder.RegisterType<SecurityProvider>().As<ISecurityProvider>().InstancePerRequest();

            builder.RegisterType<ClassA>().As<IClassA>().InstancePerDependency();


            //Note that:
            // One instance per each owned instance created in a owned lifetime scope
            // Due to InstancePerOwned we have to inject IClassB using Owned<IClassB> and we cannot use IClassB as a injecting parameter 
            // because instantiating ClassB should be from lifetimescope which is called TestApi.Models.IClassB.
            //So effectively if we pass IClassB as a parameter injection, at the time of resolving because of the following statement 
            //Autofac will look for a lifetimescope tagged with "TestApi.Models.IClassB" in which an instance of ClassB shoule be instantiated.
            //and we will get following exception:

            //No scope with a Tag matching 'TestApi.Models.IClassB' is visible from the scope in which the instance was requested.

            builder.RegisterType<ClassB>().As<IClassB>().InstancePerOwned<IClassB>();

			builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>)).InstancePerDependency();
			builder.RegisterGeneric(typeof(BoundedUnitOfWork<>)).As(typeof(IBoundedUnitOfWork<>)).InstancePerDependency();



            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();

            builder.RegisterType<Service1>().As<IService1>().InstancePerDependency();

            builder.RegisterType<Service2>().As<IService2>().InstancePerDependency();

			builder.RegisterType<NewProductServices>().As<IProductServices>().InstancePerDependency();

            builder.Register<Func<string, Class1>>(c => ((s) =>
            {
                return new Class1(s);
            })).As<Func<string, IClass1>>();

            //builder.Register<Func<string, int, IClassA>>(c => { return new ClassA(); });

            //controllers
            builder.RegisterApiControllers(typeFinder.GetAssemblies().ToArray());
	        

        }
    }
}