using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Mono.Models;

namespace Mono.DBContext
{
    [Serializable]
    public class VehicleDBContext : DbContext
    {
        #region Constructors
        public VehicleDBContext()
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
