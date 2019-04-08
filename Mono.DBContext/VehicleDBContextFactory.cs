using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Mono.DAL
{
    /// <summary>
    /// Public class that inherits IDesignTimeDbContextFactory from EntityFrameworkCore.Design and takes as type VehicleDBContext class
    /// </summary>
    public class VehicleDBContextFactory : IDesignTimeDbContextFactory<VehicleDBContext>
    {
        /// <summary>
        /// Metod that takes string series as parameter and return instance of DbContext
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public VehicleDBContext CreateDbContext(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<VehicleDBContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString, o => o.MigrationsHistoryTable(VehicleDBContext.MIGRATION_HISTORY, VehicleDBContext.SCHEMA));
            return new VehicleDBContext(builder.Options);
        }
    }
}
