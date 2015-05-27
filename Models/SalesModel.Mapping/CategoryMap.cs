
namespace SalesModel.Mapping
{
	public class CategoryMap : EntityBaseMap<Category>
	{
		public CategoryMap()
		{
			Property(t => t.Code)
					.HasMaxLength(20);

			// Table & Column Mappings
			ToTable("Categories");
			Property(t => t.Code).HasColumnName("Code");
		}
	}
}
