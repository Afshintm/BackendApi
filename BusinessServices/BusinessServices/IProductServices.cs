using System.Linq;
using System.Threading.Tasks;
using SalesModel;

namespace BusinessServices
{
	public interface IProductServices
	{
		IQueryable<Product> GetProducts();
		Task<IQueryable<Product>> GetProductAsync();
	}
}
