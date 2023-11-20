using Abp.Application.Services.Dto;
using Abp.Runtime.Caching;
using GWebsite.AbpZeroTemplate.Application.Share.OrderPackages;
using GWebsite.AbpZeroTemplate.Application.Share.OrderPackages.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OrderPackageController : GWebsiteControllerBase
    {
        private readonly ICacheManager _cacheManager;
        private readonly IOrderPackagesAppService _orderpackageAppService;

        public OrderPackageController(ICacheManager cacheManager, IOrderPackagesAppService orderpackageAppService)
        {
            _cacheManager = cacheManager;
            _orderpackageAppService = orderpackageAppService;
        }

        [HttpGet]
        public async Task<ListResultDto<OrderPackageDto>> GetOrderPackages()
        {
            return await _orderpackageAppService.GetOrderPackagesAsync();
        }

        [HttpGet]
        public async Task<PagedResultDto<OrderPackageDto>> GetOrderPackagesByFilter(string name, string sorting, int skipCount = 0, int maxResultCount = 1)
        {
            return await _orderpackageAppService.GetOrderPackagesAsync(new GetOrderPackageInput() { UserName = name, Sorting = sorting, SkipCount = skipCount, MaxResultCount = maxResultCount });
        }

        [HttpGet("{id}")]
        public async Task<OrderPackageDto> GetOrderPackageById(int id)
        {
            return await _orderpackageAppService.GetOrderPackageByIdAsync(new EntityDto<int>() { Id = id });
        }

        [HttpPost]
        public async Task<OrderPackageDto> CreateOrderPackage([FromBody] CreateOrderPackageInput input)
        {
            return await _orderpackageAppService.CreateOrderPackageAsync(input);
        }

        [HttpPut]
        public async Task<OrderPackageDto> UpdateOrderPackage([FromBody] UpdateOrderPackageInput input)
        {
            return await _orderpackageAppService.UpdateOrderPackageAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteOrderPackage(int id)
        {
            await _orderpackageAppService.DeleteOrderPackageAsync(new EntityDto<int>() { Id = id });
        }


    }
}
