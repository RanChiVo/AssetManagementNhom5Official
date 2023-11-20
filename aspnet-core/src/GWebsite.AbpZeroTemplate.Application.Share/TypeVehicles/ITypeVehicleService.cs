using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeVehicles.Dto;
namespace GWebsite.AbpZeroTemplate.Application.Share.TypeVehicles
{
    public interface ITypeVehicleAppService
    {
        void CreateOrEditTypeVehicle(TypeVehicleInput typevehicleInput);
        TypeVehicleInput GetTypeVehicleForEdit(int id);
        void DeleteTypeVehicle(int id);
        PagedResultDto<TypeVehicleDto> GetTypeVehicles(TypeVehicleFilter input);
        TypeVehicleForViewDto GetTypeVehicleForView(int id);

     

    }
}
