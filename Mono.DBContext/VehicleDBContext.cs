using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Models;
using Microsoft.EntityFrameworkCore;
using Mono.DAL.DatabaseModels;

namespace Mono.DAL
{
    /// <summary>
    /// VehicleDbContext class that inherits EntityFramework DbContext.
    /// Has DbSets and OnConfiguring metods
    /// </summary>
    public class VehicleDBContext : DbContext
    {
        //column name in sql base with migration name
        public const string MIGRATION_HISTORY = "migrationName";
        //name of shema base in sql base for tables in that base. (Mono.VehicleMake table or Mono.Vehicles for VehicleModels)
        public const string SCHEMA = "Mono";

        #region Constructors
        public VehicleDBContext(DbContextOptions<VehicleDBContext> options): base(options)
        {
            
        }
        #endregion

        #region DBSets
        /// <summary>
        /// Definition of model VehicleMakes for database
        /// </summary>
        public DbSet<VehicleMakeModel> VehicleMakes { get; set; }

        /// <summary>
        /// Definition of model VehicleModels for database
        /// </summary>
        public DbSet<VehicleModelModel> Vehicles { get; set; }
        #endregion

        #region OnConfiguring 
        /// <summary>
        /// OnModelCreating metod that takes parameter of type ModelBuilder from EntityFrameworkCore
        /// and defines the shape of entities, the relationship between them and how they map to the database 
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(SCHEMA);
            base.OnModelCreating(builder);
            //defining OneToMany reletionship between VehicleMake and VehicleModel
            builder.Entity<VehicleModelModel>() 
                .HasOne(m => m.VehicleMakes)
                .WithMany(v => v.VehicleModels)
                .IsRequired();
        }
    }
        #endregion
}
