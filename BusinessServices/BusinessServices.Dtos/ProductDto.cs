
using System.Linq;
using SalesModel;

namespace BusinessServices.Dtos
{
    public class ProductDto
    {
	    public int Id { get; set; }
	    public string Name { get; set; }
		public string Barcode { get; set; }
		public decimal? Price { get; set; }

    }

	public static class ProductExtensions
	{
		public static IQueryable<ProductDto> RemoveObjectState(this IQueryable<Product> queryableProducts)
		{
			return queryableProducts.Select(product => new ProductDto { Id = product.Id, Name = product.Name, Barcode = product.Barcode, Price = product.Price });
		}

		public static ProductDto ToProductDto(this Product product)
		{
			return new ProductDto { Id = product.Id, Name = product.Name, Barcode = product.Barcode, Price = product.Price };
		}

	}

}
