using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OrareProMe.Domain;

namespace OrareProMe.Infrastructure.Database
{
    public class MySQLContextFactory : IDesignTimeDbContextFactory<MysqlContext>
    {
        public MysqlContext CreateDbContext(string[] args)
        {
            string connectionString = "Server=localhost;Port=3306;database=rosary;user=gomes;password=rosary";

            var bus = new Bus();
            var messageBus = new MessageBus(bus);
            var eventDispatcher = new EventDispatcher(messageBus);

            return new MysqlContext(connectionString, true, eventDispatcher);
        }
    }
}