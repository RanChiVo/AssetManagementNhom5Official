using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ModelVehicles.Dto;
namespace GWebsite.AbpZeroTemplate.Application.Share.ModelVehicles
{
    public interface IModelVehicleAppService
    {
        void CreateOrEditModelVehicle(ModelVehicleInput modelvehicleInput);
        ModelVehicleInput GetModelVehicleForEdit(int id);
        void DeleteModelVehicle(int id);
        PagedResultDto<ModelVehicleDto> GetModelVehicles(ModelVehicleFilter input);
        ModelVehicleForViewDto GetModelVehicleForView(int id);
    }
}
