using Newtonsoft.Json;
using ProductsApi.Infrastructure;
using SalesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProductsApi.Controllers
{
    [RoutePrefix("test")]
    [EnableCors("*", "*", "*")]
    public class TestController : BaseApiController
    {
        private Func<string, IClass1> _class1Factory;
        public TestController(Func<string, IClass1> class1Facory) {
            _class1Factory = class1Facory;
        }
        [Route("name")]
        [HttpGet]
        public IHttpActionResult GetName() {
            IClass1 c1 = _class1Factory("afshin");
            
            return Ok( c1.Name);
        }
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAlls()
        {
            //var caller = User as ClaimsPrincipal;
            var claimsPrincipal = User as ClaimsPrincipal;
            var returnJson = String.Empty;

            //var subjectClaim = caller.FindFirst("sub");
            //if (subjectClaim != null)
            //{
            //    return Json(new
            //    {
            //        message = "OK user",
            //        client = caller.FindFirst("client_id").Value,
            //        subject = subjectClaim.Value
            //    });
            //}
            //else
            //{
            //    return Json(new
            //    {
            //        message = "OK computer",
            //        client = caller.FindFirst("client_id").Value
            //    });
            //}
            //simply returning jsonObject claimsPrincipal if there is any
            if (claimsPrincipal != null)
                returnJson = JsonConvert.SerializeObject(claimsPrincipal, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            return Ok(returnJson);
        }

    }
}
