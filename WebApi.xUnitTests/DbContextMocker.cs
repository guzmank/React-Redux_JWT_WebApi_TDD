using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.xUnitTests
{
    public static class DbContextMocker
    {
        private static readonly string connectionString = "Server=SERVER_NAME; Database=DATABASE_NAME_DB; User Id=USERNAME; Password=PASSWORD; MultipleActiveResultSets=True; Connection Timeout=500";

        public static HomeDBContext GetHomeDBContext()
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<HomeDBContext>()
                .UseInMemoryDatabase(databaseName: connectionString)
                .Options;
            
            // Create instance of DbContext
            var dbContext = new HomeDBContext(options);
            
            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}
