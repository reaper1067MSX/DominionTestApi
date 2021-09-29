using Dominion.Test.Infrastructure.Reposiroty.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Dominion.Test.Infrastructure
{
    public class DominionContextFactory : IDesignTimeDbContextFactory<DominionContext>
    {
        DominionContext IDesignTimeDbContextFactory<DominionContext>.CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            Console.WriteLine(environmentName);

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var dbServer = configuration.GetConnectionString("External");
            if (string.IsNullOrEmpty(dbServer))
            {
                dbServer = configuration.GetConnectionString("Local"); ;
            }
            connectionString = string.Format(connectionString, dbServer);

            var optionsBuilder = new DbContextOptionsBuilder<DominionContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DominionContext(optionsBuilder.Options);
        }
    }
}
