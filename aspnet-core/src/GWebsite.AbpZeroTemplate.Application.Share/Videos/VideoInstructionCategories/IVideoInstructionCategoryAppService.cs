using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructionCategories.Dto;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructionCategories
{
    public interface IVideoInstructionCategoryAppService
    {
        Task<ListResultDto<VideoInstructionCategoryDto>> GetVideoInstructionCategoriesAsync();

        Task<PagedResultDto<VideoInstructionCategoryListDto>> GetVideoInstructionCategoriesAsync(GetVideoInstructionCategoryInput input);

        Task<VideoInstructionCategoryDto> GetVideoInstructionCategoryByIdAsync(EntityDto<int> input);

        Task<VideoInstructionCategoryDto> CreateVideoInstructionCategoryAsync(CreateVideoInstructionCategoryInput input);

        Task<VideoInstructionCategoryDto> UpdateVideoInstructionCategoryAsync(UpdateVideoInstructionCategoryInput input);

        Task DeleteVideoInstructionCategoryAsync(EntityDto<int> input);
    }
}
