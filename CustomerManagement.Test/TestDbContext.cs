using CustomerManagement.DataAccess.Context;

using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Test
{
    public class TestDbContext : CustomerDbContext
    {
        public TestDbContext(DbContextOptions<CustomerDbContext> options)
           : base(options)
        {

        }

    }
    public static class DbContextHelper
    {
        public static CustomerDbContext GetTestDbContext()
        {
            DbContextOptions<CustomerDbContext> options = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            TestDbContext dbContext = new(options);

            return dbContext;
        }
    }
}
