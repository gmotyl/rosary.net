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
        private readonly EventDispatcher _eventDispatcher;

        public DbSet<Rosary> Rosaries { get; set; }
        public DbSet<Intention> Intentions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Prayer> Prayers { get; set; }

        public MysqlContext(string connectionString, bool useConsoleLogger, EventDispatcher eventDispatcher)
        {
            _connectionString = connectionString;
            _useConsoleLogger = useConsoleLogger;
            _eventDispatcher = eventDispatcher;
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

            optionsBuilder
                .UseMySQL(_connectionString)
                .UseLazyLoadingProxies();

            if (_useConsoleLogger)
            {
                optionsBuilder
                    .UseLoggerFactory(loggerFactory)
                    .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Intention>()
                .HasIndex(_ => _.ExternalId);
            modelBuilder.Entity<Rosary>()
                .HasIndex(_ => _.ExternalId);
            modelBuilder.Entity<Prayer>()
                .HasIndex(_ => _.ExternalId);
            modelBuilder.Entity<User>()
                .HasIndex(_ => _.ExternalId);
        }

        public override int SaveChanges()
        {

            List<AggregateRoot> entities = ChangeTracker
                .Entries()
                .Where(x => x.Entity is AggregateRoot)
                .Select(x => (AggregateRoot)x.Entity)
                .ToList();

            entities.ForEach(aggregate =>
            {
                _eventDispatcher.Dispatch(aggregate.DomainEvents);
                aggregate.ClearDomainEvents();
            });

            return base.SaveChanges();
        }
    }

}