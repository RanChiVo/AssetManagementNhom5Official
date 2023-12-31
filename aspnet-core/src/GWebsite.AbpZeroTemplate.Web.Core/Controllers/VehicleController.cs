﻿using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Vehicles;
using GWebsite.AbpZeroTemplate.Application.Share.Vehicles.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class VehicleController : GWebsiteControllerBase
    {
        private readonly IVehicleAppService vehicleAppService;

        public VehicleController(IVehicleAppService vehicleAppService)
        {
            this.vehicleAppService = vehicleAppService;
        }

        [HttpGet]
        public PagedResultDto<VehicleDto> GetVehiclesByFilter(VehicleFilter vehicleFilter)
        {
            return vehicleAppService.GetVehicles(vehicleFilter);
        }

        [HttpGet]
        public VehicleInput GetVehicleForEdit(int id)
        {
            return vehicleAppService.GetVehicleForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditVehicle([FromBody] VehicleInput input,int selectedTS)
        {
            vehicleAppService.CreateOrEditVehicle(input, selectedTS);
        }

        [HttpDelete("{id}")]
        public void DeleteVehicle(int id)
        {
            vehicleAppService.DeleteVehicle(id);
        }

        [HttpGet]
        public VehicleForViewDto GetVehicleForView(int id)
        {
            return vehicleAppService.GetVehicleForView(id);
        }
    }
}
