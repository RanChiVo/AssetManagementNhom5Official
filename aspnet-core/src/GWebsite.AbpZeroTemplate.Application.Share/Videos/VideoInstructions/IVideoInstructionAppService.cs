using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructions.Dto;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructions
{
    public interface IVideoInstructionAppService
    {
        Task<ListResultDto<VideoInstructionDto>> GetVideoInstructionsAsync();

        Task<PagedResultDto<VideoInstructionListDto>> GetVideoInstructionsAsync(GetVideoInstructionInput input);

        Task<VideoInstructionDto> GetVideoInstructionByIdAsync(EntityDto<int> input);

        Task<VideoInstructionDto> CreateVideoInstructionAsync(CreateVideoInstructionInput input);

        Task<VideoInstructionDto> UpdateVideoInstructionAsync(UpdateVideoInstructionInput input);

        Task DeleteVideoInstructionAsync(EntityDto<int> input);
    }
}
