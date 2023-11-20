using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructions;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructions.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class VideoInstructionController : GWebsiteControllerBase
    {
        private readonly IVideoInstructionAppService _videoInstructionService;

        public VideoInstructionController(IVideoInstructionAppService videoInstructionService)
        {
            _videoInstructionService = videoInstructionService;
        }

        [HttpGet]
        public async Task<ListResultDto<VideoInstructionDto>> GetVideoInstructions()
        {
            return await _videoInstructionService.GetVideoInstructionsAsync();
        }

        [HttpGet]
        public async Task<PagedResultDto<VideoInstructionListDto>> GetVideoInstructionsByFilter(string name, string sorting, int skipCount = 0, int maxResultCount = 1)
        {
            return await _videoInstructionService.GetVideoInstructionsAsync(new GetVideoInstructionInput() { Title = name, Sorting = sorting, SkipCount = skipCount, MaxResultCount = maxResultCount });
        }

        [HttpGet("{id}")]
        public async Task<VideoInstructionDto> GetVideoInstructionById(int id)
        {
            return await _videoInstructionService.GetVideoInstructionByIdAsync(new EntityDto<int>() { Id = id });
        }

        [HttpPost]
        public async Task<VideoInstructionDto> CreateVideoInstruction([FromBody] CreateVideoInstructionInput input)
        {
            return await _videoInstructionService.CreateVideoInstructionAsync(input);
        }

        [HttpPut]
        public async Task<VideoInstructionDto> UpdateVideoInstruction([FromBody] UpdateVideoInstructionInput input)
        {
            return await _videoInstructionService.UpdateVideoInstructionAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteVideoInstruction(int id)
        {
            await _videoInstructionService.DeleteVideoInstructionAsync(new EntityDto<int>() { Id = id });
        }
    }
}
