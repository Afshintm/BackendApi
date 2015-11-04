using Autofac.Features.OwnedInstances;
using DataAccess;
using DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesModel;
namespace BusinessServices
{
    public class NewProductServices : IProductServices
    {
        Func<Owned<IBoundedUnitOfWork<SalesBoundedContext>>> _unitOfWorkFactory ;
        public NewProductServices(Func<Owned<IBoundedUnitOfWork<SalesBoundedContext>>> unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory ;
        }
        public IQueryable<Product> GetProducts()
        {
            IQueryable<Product> result = null ;
            IEnumerable<Product> resultItems = null;
            using (var unitofwork = _unitOfWorkFactory().Value)
            {
                result = unitofwork.Repository<Product>().Query().Get();
                resultItems = result.AsEnumerable();
            }
            return (result = resultItems.AsQueryable());
        }

        public async Task<IQueryable<Product>> GetProductAsync()
        {
            var awaitableResult = Task.Run<IQueryable<Product>>(() => {
                IQueryable<Product> result = null;
                using (var unitofwork = _unitOfWorkFactory().Value)
                {
                    result = unitofwork.Repository<Product>().Query().Get();
                }
                return result;
            });

            return await awaitableResult;
        }


        public IEnumerable<Product> GetAllEnumerated()
        {
            IEnumerable<Product> resultItems = null;
            List<Product> l = null;
            using (var unitofwork = _unitOfWorkFactory().Value)
            {
                resultItems = unitofwork.Repository<Product>().Query().Get(i=>i.Id == 1).AsEnumerable();
                l = new List<Product>();
                l = resultItems.ToList();
            }
            return (l);
        }

        public IEnumerable<ProductDto> ToProductDto(IEnumerable<Product> products)
        {
            foreach (var item in products)
	        {
		        var productDto = new ProductDto{Id = item.Id, Barcode = item.Barcode, Name = item.Name , Price = item.Price} ;
                yield return productDto ;
	        }
            yield break;
        }
        public IEnumerable<ProductDto> GetAll()
        {
            List<ProductDto> result = null ;
            using (var uow = _unitOfWorkFactory().Value)
            {
                var query = uow.Repository<Product>().Query().Get();
                if (query != null) {
                    result = ToProductDto(query.AsEnumerable()).ToList() ;
                }
            }
            return result;
        }
    }
}
