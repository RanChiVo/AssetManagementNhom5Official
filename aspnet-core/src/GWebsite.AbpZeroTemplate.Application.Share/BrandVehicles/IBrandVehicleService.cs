using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.BrandVehicles.Dto;
namespace GWebsite.AbpZeroTemplate.Application.Share.BrandVehicles
{
    public interface IBrandVehicleAppService
    {
        void CreateOrEditBrandVehicle(BrandVehicleInput brandvehicleInput);
        BrandVehicleInput GetBrandVehicleForEdit(int id);
        void DeleteBrandVehicle(int id);
        PagedResultDto<BrandVehicleDto> GetBrandVehicles(BrandVehicleFilter input);
        BrandVehicleForViewDto GetBrandVehicleForView(int id);
    }
}
