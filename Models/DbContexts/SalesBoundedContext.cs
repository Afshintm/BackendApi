using System.Data.Entity;
using DataAccess;
using SalesModel.Mapping;

namespace DbContexts
{
	public class SalesBoundedContext : BoundDbContext<SalesBoundedContext>
	{
		public SalesBoundedContext()
			: base("name=Sales")
		{
			
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);
			modelBuilder.Configurations.Add(new ProductMap());
			modelBuilder.Configurations.Add(new CategoryMap());
			modelBuilder.Configurations.Add(new ProductCategoryMap());
		}
	}
}
