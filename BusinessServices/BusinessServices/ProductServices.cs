
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using SalesModel;

namespace BusinessServices
{
	public class ProductServices: ServiceBase, IProductServices
	{
		public ProductServices(IConfig config, ILogger logger , IExceptionHandler exceptionHandler , ISecurityProvider securityProvider):base(config,logger,exceptionHandler,securityProvider)
		{

		}

		public IQueryable<Product> GetProducts()
		{
			return new List<Product>().AsQueryable();
		}

		public async Task<IQueryable<Product>> GetProductAsync()
		{
			return await Task.Run(()=> new List<Product>().AsQueryable());
		}

        public IEnumerable<Product> GetAllEnumerated() 
        {
            return new List<Product>();
        }


        public IEnumerable<ProductDto> GetAll()
        {
            return new List<ProductDto>();
        }
    }
}