using System.Linq;
using System.Threading.Tasks;
using SalesModel;
using System.Collections.Generic;

namespace BusinessServices
{
	public interface IProductServices
	{
		IQueryable<Product> GetProducts();
		Task<IQueryable<Product>> GetProductAsync();
        IEnumerable<Product> GetAllEnumerated();
        IEnumerable<ProductDto> GetAll();
	}
}
