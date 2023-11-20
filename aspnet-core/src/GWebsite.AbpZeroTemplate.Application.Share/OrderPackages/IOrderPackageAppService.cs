using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.OrderPackages.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.OrderPackages
{
    public interface IOrderPackagesAppService : IApplicationService
    {
        Task<ListResultDto<OrderPackageDto>> GetOrderPackagesAsync();

        Task<PagedResultDto<OrderPackageDto>> GetOrderPackagesAsync(GetOrderPackageInput input);

        Task<OrderPackageDto> GetOrderPackageByIdAsync(EntityDto<int> input);

        Task<OrderPackageDto> CreateOrderPackageAsync(CreateOrderPackageInput input);

        Task<OrderPackageDto> UpdateOrderPackageAsync(UpdateOrderPackageInput input);

        Task DeleteOrderPackageAsync(EntityDto<int> input);
    }
}
