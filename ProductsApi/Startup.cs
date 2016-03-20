using Microsoft.Owin;
using Owin;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;
using System.Web.Http.OData.Extensions;
using Ioc.Core.Infrastructure;
using Autofac.Integration.WebApi;
using System.IdentityModel.Tokens;

[assembly: OwinStartup(typeof(ProductsApi.Startup))]

namespace ProductsApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();

            // accept access tokens from identityserver and require a scope of 'api1'
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44333/core",
                ValidationMode = ValidationMode.ValidationEndpoint,

                RequiredScopes = new[] { "api1" }
            });


            

            //app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            //{
            //    Authority = "https://localhost:44333/core",
            //    RequiredScopes = new[] { "write" },

            //    // client credentials for the introspection endpoint
            //    ClientId = "write",
            //    ClientSecret = "secret"
            //});



            //http://docs.autofac.org/en/latest/integration/webapi.html#owin-integration
            // STANDARD WEB API SETUP:

            // Get your HttpConfiguration. In OWIN, you'll create one
            // rather than using GlobalConfiguration.Here getting result of calling Register method of WebApiConfig
            var config = WebApiConfig.Register();

            // Register your Web API controllers.

            // Run other optional steps, like registering filters,
            // per-controller-type services, etc., then set the dependency resolver
            // to be Autofac.
            EngineContext.Initialize(false);

            //set dependency resolver for webApi
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(EngineContext.Current.ContainerManager.Container);

            // OWIN WEB API SETUP:

            // Register the Autofac middleware FIRST, then the Autofac Web API middleware,
            // and finally the standard Web API middleware.
            app.UseAutofacMiddleware(EngineContext.Current.ContainerManager.Container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);

        }
    }
}