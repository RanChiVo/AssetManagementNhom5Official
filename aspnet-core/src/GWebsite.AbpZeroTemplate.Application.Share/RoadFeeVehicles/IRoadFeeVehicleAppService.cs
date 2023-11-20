using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RoadFeeVehicles.Dto;
namespace GWebsite.AbpZeroTemplate.Application.Share.RoadFeeVehicles
{
    public interface IRoadFeeVehicleAppService
    {
        void CreateOrEditRoadFeeVehicle(RoadFeeVehicleInput roadfeevehicleInput);
        RoadFeeVehicleInput GetRoadFeeVehicleForEdit(int id);
        void DeleteRoadFeeVehicle(int id);
        PagedResultDto<RoadFeeVehicleDto> GetRoadFeeVehicles(RoadFeeVehicleFilter input);
        RoadFeeVehicleForViewDto GetRoadFeeVehicleForView(int id);
    }
}
