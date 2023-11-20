using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RoadFeeVehicles;
using GWebsite.AbpZeroTemplate.Application.Share.RoadFeeVehicles.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RoadFeeVehicleController : GWebsiteControllerBase
    {
        private readonly IRoadFeeVehicleAppService roadfeeVehicleAppService;

        public RoadFeeVehicleController(IRoadFeeVehicleAppService roadfeeVehicleAppService)
        {
            this.roadfeeVehicleAppService = roadfeeVehicleAppService;
        }

        [HttpGet]
        public PagedResultDto<RoadFeeVehicleDto> GetRoadFeeVehiclesByFilter(RoadFeeVehicleFilter roadfeeVehicleFilter)
        {
            return roadfeeVehicleAppService.GetRoadFeeVehicles(roadfeeVehicleFilter);
        }

        [HttpGet]
        public RoadFeeVehicleInput GetRoadFeeVehicleForEdit(int id)
        {
            return roadfeeVehicleAppService.GetRoadFeeVehicleForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditRoadFeeVehicle([FromBody] RoadFeeVehicleInput input)
        {
            roadfeeVehicleAppService.CreateOrEditRoadFeeVehicle(input);
        }

        [HttpDelete("{id}")]
        public void DeleteRoadFeeVehicle(int id)
        {
            roadfeeVehicleAppService.DeleteRoadFeeVehicle(id);
        }

        [HttpGet]
        public RoadFeeVehicleForViewDto GetRoadFeeVehicleForView(int id)
        {
            return roadfeeVehicleAppService.GetRoadFeeVehicleForView(id);
        }
    }
}