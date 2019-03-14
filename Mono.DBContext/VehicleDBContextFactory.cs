using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Mono.DBContext
{
    public class VehicleDBContextFactory : IDesignTimeDbContextFactory<VehicleDBContext>
    {

        public VehicleDBContext CreateDbContext(string[] args)
        {
          
            var builder = new DbContextOptionsBuilder<VehicleDBContext>();

            var connectionString = @"Data Source=DESKTOP-3D55173\SQLEXPRESS;Initial Catalog=MonoDataBase;Integrated Security=True";

            builder.UseSqlServer(connectionString, o => o.MigrationsHistoryTable(VehicleDBContext.MIGRATION_HISTORY, VehicleDBContext.SCHEMA));
            return new VehicleDBContext(builder.Options);
        }
    }
}
