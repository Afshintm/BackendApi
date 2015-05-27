using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesModel.Mapping
{
	public class ProductMap : EntityBaseMap<Product>
	{
		public ProductMap()
		{
			Property(t => t.Barcode)
					.HasMaxLength(100);

			// Table & Column Mappings
			ToTable("Products");
			Property(t => t.Barcode).HasColumnName("Barcode");
			Property(t => t.Price).HasColumnName("Price");
		}
	}
}
