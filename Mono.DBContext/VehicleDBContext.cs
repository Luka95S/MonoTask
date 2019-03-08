using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Models;
using Microsoft.EntityFrameworkCore;

namespace Mono.DBContext
{
    public class VehicleDBContext : DbContext
    {
        public const string MIGRATION_HISTORY = "migrationName";
        public const string SCHEMA = "Mono";

        #region Constructors
        public VehicleDBContext(DbContextOptions<VehicleDBContext> options): base(options)
        {
            
        }
        #endregion
        #region DBSets
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        #endregion

       

        #region OnConfiguring 
        // protected override void OnConfiguring(DbCon)
        #endregion
    }
}
