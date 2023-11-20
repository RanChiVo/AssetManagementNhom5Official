using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.OrderPackages;
using GWebsite.AbpZeroTemplate.Application.Share.OrderPackages.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.OrderPackages
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_OrderPackage)]
    public class OrderPackagesAppService : GWebsiteAppServiceBase, IOrderPackagesAppService
    {
        private readonly IRepository<OrderPackage, int> _orderpackageRepository;

        public OrderPackagesAppService(IRepository<OrderPackage, int> orderpackageRepository)
        {
            _orderpackageRepository = orderpackageRepository;
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_OrderPackage_Create)]
        public async Task<OrderPackageDto> CreateOrderPackageAsync(CreateOrderPackageInput input)
        {
            
            var entity = ObjectMapper.Map<OrderPackage>(input);
            entity = await _orderpackageRepository.InsertAsync(entity);              
            return ObjectMapper.Map<OrderPackageDto>(entity);
           
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_OrderPackage_Delete)]
        public async Task DeleteOrderPackageAsync(EntityDto<int> input)
        {
            var entity = await _orderpackageRepository.GetAsync(input.Id);
            entity.RecordStatus = "0";
            await _orderpackageRepository.UpdateAsync(entity);
        }

        public async Task<OrderPackageDto> GetOrderPackageByIdAsync(EntityDto<int> input)
        {
            var entity = await _orderpackageRepository.GetAsync(input.Id);
            return ObjectMapper.Map<OrderPackageDto>(entity);
        }

        public async Task<ListResultDto<OrderPackageDto>> GetOrderPackagesAsync()
        {
            var items = await _orderpackageRepository.GetAllListAsync();
            return new ListResultDto<OrderPackageDto>(
                 items.Select(item => ObjectMapper.Map<OrderPackageDto>(item)).ToList());
        }

        public async Task<PagedResultDto<OrderPackageDto>> GetOrderPackagesAsync(GetOrderPackageInput input)
        {
            try
            {
                var query = _orderpackageRepository.GetAll()
               .WhereIf(!input.UserName.IsNullOrWhiteSpace(), m => m.UserName.Contains(input.UserName));

                var totalCount = query.Count();
                var items = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

                return new PagedResultDto<OrderPackageDto>(
                    totalCount,
                    items.Select(item => ObjectMapper.Map<OrderPackageDto>(item)).ToList());
            }catch(Exception e)
            {
                throw e;
            }
           
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_OrderPackage_Edit)]
        public async Task<OrderPackageDto> UpdateOrderPackageAsync(UpdateOrderPackageInput input)
        {
            var entity = ObjectMapper.Map<OrderPackage>(input);
            await _orderpackageRepository.UpdateAsync(entity);
            return ObjectMapper.Map<OrderPackageDto>(entity);
        }
    }
}
