using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Templates.Slider.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Templates
{
    public interface ISlidesAppService : IApplicationService
    {
        Task<SlideDto> CreateSlideAsync(CreateSlideInput input);

        Task<SlideDto> UpdateSlideAsync(UpdateSlideInput update);

        Task DeleteSlideAsync(EntityDto<int> input);

        Task<ListResultDto<SlideDto>> GetSlidesAsync(GetSlidesInput input);
        Task<PagedResultDto<SlideDto>> GetSlidesPaging(GetSlidesPagingInput input);

        Task<SlideDto> GetByIdAsync(EntityDto<int> input);
    }
}
