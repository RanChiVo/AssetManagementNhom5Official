using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TypeVehicles;
using GWebsite.AbpZeroTemplate.Application.Share.TypeVehicles.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TypeVehicleController : GWebsiteControllerBase
    {
        private readonly ITypeVehicleAppService typevehicleAppService;

        public TypeVehicleController(ITypeVehicleAppService typevehicleAppService)
        {
            this.typevehicleAppService = typevehicleAppService;
        }

        [HttpGet]
        public PagedResultDto<TypeVehicleDto> GetTypeVehiclesByFilter(TypeVehicleFilter typevehicleFilter)
        {
            return typevehicleAppService.GetTypeVehicles(typevehicleFilter);
        }
 
   

        [HttpGet]
        public TypeVehicleInput GetTypeVehicleForEdit(int id)
        {
            return typevehicleAppService.GetTypeVehicleForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditTypeVehicle([FromBody] TypeVehicleInput input)
        {
            typevehicleAppService.CreateOrEditTypeVehicle(input);
        }

        [HttpDelete("{id}")]
        public void DeleteTypeVehicle(int id)
        {
            typevehicleAppService.DeleteTypeVehicle(id);
        }

        [HttpGet]
        public TypeVehicleForViewDto GetTypeVehicleForView(int id)
        {
            return typevehicleAppService.GetTypeVehicleForView(id);
        }
    }
}
