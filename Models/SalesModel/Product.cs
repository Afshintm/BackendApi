using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

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