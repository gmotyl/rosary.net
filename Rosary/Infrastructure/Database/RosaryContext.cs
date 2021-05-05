using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Rosary.Domain;

namespace Rosary.Infrastructure.Database
{
    public class RosaryContext : DbContext
    {
        public DbSet<Domain.Rosary> Rosaries { get; set; }
        public DbSet<Domain.Intention> Intentions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Port=3306;database=rosary;user=gomes;password=rosary");
        }
    }
}