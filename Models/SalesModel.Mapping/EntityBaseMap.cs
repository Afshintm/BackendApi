using System.Data.Entity.ModelConfiguration;

namespace SalesModel.Mapping
{

	public class EntityBaseMap<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : EntityBase
	{
		public EntityBaseMap()
		{
			// Primary Key
			HasKey(t => t.Id);

			// Properties
			Property(t => t.Name)
				.HasMaxLength(250);

			Property(t => t.Id).HasColumnName("Id");
			Property(t => t.Name).HasColumnName("Name");
			Ignore(t => t.ObjectState);
		}
	}
}
