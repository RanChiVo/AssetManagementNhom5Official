using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ModelVehicles;
using GWebsite.AbpZeroTemplate.Application.Share.ModelVehicles.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ModelVehicleController : GWebsiteControllerBase
    {
        private readonly IModelVehicleAppService modelVehicleAppService;

        public ModelVehicleController(IModelVehicleAppService modelVehicleAppService)
        {
            this.modelVehicleAppService = modelVehicleAppService;
        }

        [HttpGet]
        public PagedResultDto<ModelVehicleDto> GetModelVehiclesByFilter(ModelVehicleFilter modelVehicleFilter)
        {
            return modelVehicleAppService.GetModelVehicles(modelVehicleFilter);
        }

        [HttpGet]
        public ModelVehicleInput GetModelVehicleForEdit(int id)
        {
            return modelVehicleAppService.GetModelVehicleForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditModelVehicle([FromBody] ModelVehicleInput input)
        {
            modelVehicleAppService.CreateOrEditModelVehicle(input);
        }

        [HttpDelete("{id}")]
        public void DeleteModelVehicle(int id)
        {
            modelVehicleAppService.DeleteModelVehicle(id);
        }

        [HttpGet]
        public ModelVehicleForViewDto GetModelVehicleForView(int id)
        {
            return modelVehicleAppService.GetModelVehicleForView(id);
        }
    }
}