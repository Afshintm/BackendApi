using DataAccess;

namespace DbContexts
{
	public class SimpleContext: DbContextBase<SimpleContext>
	{
		public SimpleContext(string nameOrConnectionString) :
			base(nameOrConnectionString)
		{
			
		}
	}
}
