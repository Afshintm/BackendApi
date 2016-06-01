using ProductsApi.Infrastructure;
using SalesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProductsApi.Controllers
{
    [RoutePrefix("api/Tests")]
    [EnableCors("*", "*", "*")]
    public class TestController : BaseApiController
    {
        private Func<string, IClass1> _class1Factory;
        public TestController(Func<string, IClass1> class1Facory) {
            _class1Factory = class1Facory;
        }
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllTest() {
            IClass1 c1 = _class1Factory("afshin");
            
            return Ok( c1.Name);
        }
    }
}
