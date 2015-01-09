using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProductsApi.Models ;
namespace ProductsApi.Controllers
{
	[RoutePrefix("api/Products")]
	[EnableCors("*","*","*")]
    public class ProductsController : ApiController
    {
		
	    Product[] Products =
	    {
		    new Product{Id=1 , Name="Eternity" ,Category="Book" ,Price= 24.5m} ,
		    new Product{Id=2 , Name="C# for dummies" ,Category="Book" ,Price= 14.5m} ,
		    new Product{Id=3 , Name="Tommato" ,Category="Groceries" ,Price= 8.5m} ,
		    new Product{Id=3 , Name="Pen" ,Category="Stationary" ,Price= 24.5m} ,
		    new Product{Id=3 , Name="Pencil" ,Category="Stationary" ,Price= 24.5m} 
	    };

		/// <summary>
		/// Returns a list of products
		/// </summary>
		/// <returns>Returns a CLR type which is getting serialised based on Accept values of the request </returns>
		/// Content negotiation is happening to find out what content is acceptable for the request. default is json.
		 
		[Route("")]
		[HttpGet]
	    public IQueryable<Product> GetProducts()
	    {
		    return Products.AsQueryable();
		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id">the id of the requsted product</param>
		/// <returns>Returns an HttpResponseMessage class containing the serialized product object </returns>
		/// This way we can have more control over the content returned as response.  
		[Route("{id:int}")]
		[HttpGet]
	    public HttpResponseMessage GetProduct(int id)
	    {
		    var p = Products.FirstOrDefault(i => i.Id == id);
		    if (p != null)
			    return Request.CreateResponse(HttpStatusCode.OK, p);
		    else
			    return Request.CreateResponse(HttpStatusCode.NotFound);
	    }
		
		/// <summary>
		/// returns IHttpActionResult which in turn calls the ExecuteAsync method to asyncronusely returning an HttpResponseMessage 
		/// </summary>
		/// <param name="id">the id of the requested product</param>
		/// <returns>returns an Async HttpResponseMessage</returns>
		/// using ~ in Route attribute, we override 
		[Route("~/api/Product/{id:int}")]
		[HttpGet]
		public IHttpActionResult Product(int id)
		{
			var p = Products.FirstOrDefault(item => item.Id == id);

			if (p != null)
				return Ok(p);

			return NotFound();
		}

    }
}
