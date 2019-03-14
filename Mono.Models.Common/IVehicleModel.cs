using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.Models.Common
{
    public interface IVehicleModel
    {
        Guid Id { get; set; }
        Guid MakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
