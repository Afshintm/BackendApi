using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Newtonsoft.Json;

namespace ProductsApi.Controllers
{
	[Authorize]
    [Route("test")]
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            var claimsPrincipal = User as ClaimsPrincipal;
            var returnJson = String.Empty;

            //simply returning jsonObject claimsPrincipal if there is any
            if (claimsPrincipal!=null)
                returnJson = JsonConvert.SerializeObject(claimsPrincipal, Formatting.Indented, 
                    new JsonSerializerSettings {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            return Ok(returnJson);
        }
    }
}

  