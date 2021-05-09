using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrareProMe.Domain;

namespace OrareProMe.Infrastructure.Database
{
    public class MysqlContext : DbContext, IApplicationDbContext
    {
        public DbSet<Domain.Rosary> Rosaries { get; set; }
        public DbSet<Domain.Intention> Intentions { get; set; }
        public DbSet<Domain.User> Users { get; set; }
        public DbSet<Domain.Prayer> Prayers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySQL("Server=localhost;Port=3306;database=rosary;user=gomes;password=rosary")
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
    }
}