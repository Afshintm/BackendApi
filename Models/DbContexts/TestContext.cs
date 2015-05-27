using System.Data.Entity;
using DataAccess;
using SalesModel;

namespace DbContexts
{
    public class TestContext:BoundDbContext<TestContext>
    {
	    public IDbSet<Product> Products { get; set; }
	}
}
