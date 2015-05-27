
namespace SalesModel.Mapping
{
	public class ProductCategoryMap : EntityBaseMap<ProductCategory>
	{
		public ProductCategoryMap()
		{
			ToTable("ProductCategory");
			Property(t => t.CategoryId).HasColumnName("CategoryId");
			Property(t => t.ProductId).HasColumnName("ProductId");
			
			// Relationships
			HasOptional(t => t.Category)
				.WithMany(t => t.ProductsCategory)
				.HasForeignKey(d => d.CategoryId);

			HasOptional(t => t.Product)
				.WithMany(p => p.ProductCategories)
				.HasForeignKey(d => d.ProductId);

			
		}
	}
}
