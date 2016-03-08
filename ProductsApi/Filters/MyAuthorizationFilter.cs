using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ProductsApi.Filters
{
    public class MyAuthorizationFilter : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var identity = Thread.CurrentPrincipal.Identity;
            if (identity == null && HttpContext.Current != null)
                identity = HttpContext.Current.User.Identity;

            if (identity != null && identity.IsAuthenticated)
            {
                var basicAuth = identity as BasicAuthenticationIdentity;

                // do your business validation as needed
                var user = new UserServices();
                if (user.Authenticate(basicAuth.Name, basicAuth.Password)>0)
                    return true;
            }

            return false;
        }
    }
}
