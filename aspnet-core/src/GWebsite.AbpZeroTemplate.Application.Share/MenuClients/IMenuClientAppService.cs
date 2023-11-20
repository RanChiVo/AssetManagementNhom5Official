using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using System.Threading.Tasks;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.MenuClients
{
    public interface IMenuClientAppService
    {
        Task<ListResultDto<MenuClientDto>> GetMenuClientsAsync();

        Task<PagedResultDto<MenuClientListDto>> GetMenuClientsAsync(GetMenuClientInput input);//for filter

        Task<GetMenuClientOutput> GetMenuClientForEditAsync(NullableIdDto input);

        Task<MenuClientDto> UpdateMenuClientAsync(UpdateMenuClientInput input);

        Task<MenuClientDto> CreateMenuClientAsync(CreateMenuClientInput input);

        Task DeleteMenuClientAsync(EntityDto<int> input);
    }
}
