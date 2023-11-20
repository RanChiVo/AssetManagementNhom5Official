using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.OperateVehicles;
using GWebsite.AbpZeroTemplate.Application.Share.OperateVehicles.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OperateVehicleController : GWebsiteControllerBase
    {
        private readonly IOperateVehicleAppService operateVehicleAppService;

        public OperateVehicleController(IOperateVehicleAppService operateVehicleAppService)
        {
            this.operateVehicleAppService = operateVehicleAppService;
        }

        [HttpGet]
        public PagedResultDto<OperateVehicleDto> GetOperateVehiclesByFilter(OperateVehicleFilter operateVehicleFilter)
        {
            return operateVehicleAppService.GetOperateVehicles(operateVehicleFilter);
        }

        [HttpGet]
        public OperateVehicleInput GetOperateVehicleForEdit(int id)
        {
            return operateVehicleAppService.GetOperateVehicleForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditOperateVehicle([FromBody] OperateVehicleInput input)
        {
            operateVehicleAppService.CreateOrEditOperateVehicle(input);
        }

        [HttpDelete("{id}")]
        public void DeleteBrandVehicle(int id)
        {
            operateVehicleAppService.DeleteOperateVehicle(id);
        }

        [HttpGet]
        public OperateVehicleForViewDto GetOperateVehicleForView(int id)
        {
            return operateVehicleAppService.GetOperateVehicleForView(id);
        }
    }
}