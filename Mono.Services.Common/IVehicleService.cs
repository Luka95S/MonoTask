using Mono.Models.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mono.Services.Common
{
    public interface IVehicleService
    {
        Task<IEnumerable<IVehicle>> GetAllVehiclesAsync();

    }
}
