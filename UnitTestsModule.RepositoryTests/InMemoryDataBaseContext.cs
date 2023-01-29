using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using UnitTestsModule.Repository.Configs;

namespace UnitTestsModule.RepositoryTests
{
    public class InMemoryDataBaseContext : UnitTestsDbContext
    {
        private static readonly ILoggerFactory loggerDebugFactory = LoggerFactory.Create(builder => { builder.AddDebug(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(loggerDebugFactory)
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
        }
    }
}
