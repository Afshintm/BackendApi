using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesModel
{
	public class Category:EntityBase
	{
		public Category()
		{
			ProductsCategory = new List<ProductCategory>();
		}

		public string Code { get; set; }
		public string Desc { get; set; }

		public virtual ICollection<ProductCategory> ProductsCategory { get; set; }
	}
}
