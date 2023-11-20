using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.BrandVehicles;
using GWebsite.AbpZeroTemplate.Application.Share.BrandVehicles.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BrandVehicleController : GWebsiteControllerBase
    {
        private readonly IBrandVehicleAppService brandVehicleAppService;

        public BrandVehicleController(IBrandVehicleAppService brandVehicleAppService)
        {
            this.brandVehicleAppService = brandVehicleAppService;
        }

        [HttpGet]
        public PagedResultDto<BrandVehicleDto> GetBrandVehiclesByFilter(BrandVehicleFilter brandVehicleFilter)
        {
            return brandVehicleAppService.GetBrandVehicles(brandVehicleFilter);
        }

        [HttpGet]
        public BrandVehicleInput GetBrandVehicleForEdit(int id)
        {
            return brandVehicleAppService.GetBrandVehicleForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditBrandVehicle([FromBody] BrandVehicleInput input)
        {
            brandVehicleAppService.CreateOrEditBrandVehicle(input);
        }

        [HttpDelete("{id}")]
        public void DeleteBrandVehicle(int id)
        {
            brandVehicleAppService.DeleteBrandVehicle(id);
        }

        [HttpGet]
        public BrandVehicleForViewDto GetBrandVehicleForView(int id)
        {
            return brandVehicleAppService.GetBrandVehicleForView(id);
        }
    }
}