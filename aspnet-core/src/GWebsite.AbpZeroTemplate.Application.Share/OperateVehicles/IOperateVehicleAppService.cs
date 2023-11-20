using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.OperateVehicles.Dto;
namespace GWebsite.AbpZeroTemplate.Application.Share.OperateVehicles
{
    public interface IOperateVehicleAppService
    {
        void CreateOrEditOperateVehicle(OperateVehicleInput operatevehicleInput);
        OperateVehicleInput GetOperateVehicleForEdit(int id);
        void DeleteOperateVehicle(int id);
        PagedResultDto<OperateVehicleDto> GetOperateVehicles(OperateVehicleFilter input);
        OperateVehicleForViewDto GetOperateVehicleForView(int id);
    }
}
