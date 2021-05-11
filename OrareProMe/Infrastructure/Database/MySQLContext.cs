using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrareProMe.Domain;

namespace OrareProMe.Infrastructure.Database
{
    public class MysqlContext : DbContext, IApplicationDbContext
    {
        public DbSet<Domain.Rosary> Rosaries { get; set; }
        public DbSet<Domain.Intention> Intentions { get; set; }
        public DbSet<Domain.User> Users { get; set; }
        public DbSet<Domain.Prayer> Prayers { get; set; }

        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options)
        {

        }

    }
}