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
        private readonly string _connectionString;
        private readonly bool _useConsoleLogger;

        public DbSet<Domain.Rosary> Rosaries { get; set; }
        public DbSet<Domain.Intention> Intentions { get; set; }
        public DbSet<Domain.User> Users { get; set; }
        public DbSet<Domain.Prayer> Prayers { get; set; }

        public MysqlContext(string connectionString, bool useConsoleLogger)
        {
            _connectionString = connectionString;
            _useConsoleLogger = useConsoleLogger;
        }

        protected MysqlContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                    .AddConsole();
            });

            optionsBuilder.UseMySQL(_connectionString);

            if (_useConsoleLogger)
            {
                optionsBuilder
                    .UseLoggerFactory(loggerFactory)
                    .EnableSensitiveDataLogging();
            }
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Intention>(x =>
        //     {
        //         x.ToTable("Intention").HasKey(k => k.Id);
        //         x.Property(p => p.Id);
        //         x.Property(p => p.Description);
        //         x.HasOne(p => p.Owner).WithMany();
        //         x.HasMany<Rosary>(p => p.)
        //     });
        //     modelBuilder.Entity<Course>(x =>
        //     {
        //         x.ToTable("Course").HasKey(k => k.Id);
        //         x.Property(p => p.Id).HasColumnName("CourseID");
        //         x.Property(p => p.Name);
        //     });
        // }

    }
}