using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BusinessServices;
using BusinessServices.Dtos;
using Common;
using DbContexts;
using ProductsApi.Infrastructure;
using SalesModel;
using DataAccess;

namespace ProductsApi.Controllers
{
	[RoutePrefix("api/Products")]
	[EnableCors("*","*","*")]
    public class ProductsController : BaseApiController
	{
		private readonly IProductServices _productsService;
		public ProductsController(IProductServices productService)
		{
			_productsService = productService;
		}

		private Category[] categories =
		{
			new Category { Code = "Books", Desc = "Books Category", Name = "Books"},
			new Category { Code = "Vegtables", Desc = "Vegtables Category", Name = "Vegtables"},
			new Category { Code = "Stationary", Desc = "Stationary Category", Name = "Stationary"},
		};
		Product[] Products =
	    {
		    new Product{Name="Eternity" ,Price= 24.5m} ,
		    new Product{Name="C# for dummies"  ,Price= 14.5m} ,
		    new Product{Name="Tommato" ,Price= 8.5m} ,
		    new Product{Name="Pen" ,Price= 24.5m} ,
		    new Product{Name="Pencil" ,Price= 24.5m} 
	    };

		private Product[] fakeProducts =
		{
			new Product {Id = 1, Name = "Eternity", Price = 24.5m},
			new Product {Id = 2, Name = "C# for dummies", Price = 14.5m},
			new Product {Id = 3, Name = "Tommato", Price = 8.5m},
			new Product {Id = 4, Name = "Pen", Price = 24.5m},
			new Product {Id = 5, Name = "Pencil", Price = 24.5m}

		};
		
			/// <summary>
		/// Returns a list of products
		/// </summary>
		/// <returns>Returns a CLR type which is getting serialised based on Accept values of the request </returns>
		/// Content negotiation is happening to find out what content is acceptable for the request. default is json.
		 
		[Route("")]
		[HttpGet]
	    public IQueryable<ProductDto> GetProducts()
	    {
		    return fakeProducts.AsQueryable().RemoveObjectState();
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
		    var p = fakeProducts.FirstOrDefault(i => i.Id == id).ToProductDto();
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
			var p = fakeProducts.FirstOrDefault(item => item.Id == id).ToProductDto();

			if (p != null)
				return Ok(p);

			return NotFound();
		}

		[Route("~/api/InitDatabase")]
		[HttpGet]
		public IHttpActionResult InitDatabase()
		{
			try
			{
				using (var uow = new BoundedUnitOfWork<SalesBoundedContext>())
				{
					foreach (var c in categories)
						uow.Repository<Category>().Insert(c);
					uow.Save();
				}

				using (var uow1 = new BoundedUnitOfWork<SalesBoundedContext>())
				{
					var bookCategory = uow1.Repository<Category>().Query().Get(c => c.Code == "Books").FirstOrDefault();
					var vegCategory = uow1.Repository<Category>().Query().Get(c => c.Code == "Vegtables").FirstOrDefault();
					var stationaryCategory = uow1.Repository<Category>().Query().Get(c => c.Code == "Stationary").FirstOrDefault();
					foreach (var p in Products)
					{
						if (p.Id <= 2)
							p.ProductCategories.Add(new ProductCategory() { Category = bookCategory, ObjectState = ObjectState.Added });
						else if (p.Id == 3)
							p.ProductCategories.Add(new ProductCategory() { Category = vegCategory, ObjectState = ObjectState.Added });
						else
						{
							p.ProductCategories.Add(new ProductCategory() { Category = stationaryCategory, ObjectState = ObjectState.Added });
						}
						uow1.Repository<Product>().Insert(p);
					}

					uow1.Commit();
				}

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return Ok();


		}
	}
}
