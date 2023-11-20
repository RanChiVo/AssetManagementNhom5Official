using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Vehicles.Dto;
namespace GWebsite.AbpZeroTemplate.Application.Share.Vehicles
{
    public interface IVehicleAppService
    {
        void CreateOrEditVehicle(VehicleInput vehicleInput,int selectedTS=0);
        VehicleInput GetVehicleForEdit(int id);
        void DeleteVehicle(int id);
        PagedResultDto<VehicleDto> GetVehicles(VehicleFilter input);
        VehicleForViewDto GetVehicleForView(int id);
    }
}
