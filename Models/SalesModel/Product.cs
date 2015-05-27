using System.Collections.Generic;

namespace SalesModel
{
	public class Product : EntityBase
	{
		public Product()
		{
			ProductCategories = new List<ProductCategory>();
		}
		public string Barcode { get; set; }
		public decimal? Price { get; set; }

		public virtual ICollection<ProductCategory> ProductCategories { get; set; }
	}
}