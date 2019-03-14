using System;

namespace Mono.Models.Common
{
    public interface IVehicleMake
    {
        string Abrv { get; set; }
        string Name { get; set; }
        Guid Id { get; set; }
    }
}