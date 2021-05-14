using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OrareProMe.Infrastructure.Database
{
    public class MySQLContextFactory : IDesignTimeDbContextFactory<MysqlContext>
    {
        public MysqlContext CreateDbContext(string[] args)
        {
            string connectionString = "Server=localhost;Port=3306;database=rosary;user=gomes;password=rosary";

            return new MysqlContext(connectionString, true);
        }
    }
}