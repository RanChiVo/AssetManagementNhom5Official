using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructionCategories;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructionCategories.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class VideoInstructionCategoryController : GWebsiteControllerBase
    {
        private readonly IVideoInstructionCategoryAppService _videoInstructionCategoryAppService;

        public VideoInstructionCategoryController(IVideoInstructionCategoryAppService videoInstructionCategoryAppService)
        {
            _videoInstructionCategoryAppService = videoInstructionCategoryAppService;
        }

        [HttpGet]
        public async Task<ListResultDto<VideoInstructionCategoryDto>> GetVideoInstructionCategorys()
        {
            return await _videoInstructionCategoryAppService.GetVideoInstructionCategoriesAsync();
        }

        [HttpGet]
        public async Task<PagedResultDto<VideoInstructionCategoryListDto>> GetVideoInstructionCategorysByFilter(string name, string sorting, int skipCount = 0, int maxResultCount = 1)
        {
            return await _videoInstructionCategoryAppService.GetVideoInstructionCategoriesAsync(new GetVideoInstructionCategoryInput() { Name = name, Sorting = sorting, SkipCount = skipCount, MaxResultCount = maxResultCount });
        }

        [HttpGet("{id}")]
        public async Task<VideoInstructionCategoryDto> GetVideoInstructionCategoryById(int id)
        {
            return await _videoInstructionCategoryAppService.GetVideoInstructionCategoryByIdAsync(new EntityDto<int>() { Id = id });
        }

        [HttpPost]
        public async Task<VideoInstructionCategoryDto> CreateVideoInstructionCategory([FromBody] CreateVideoInstructionCategoryInput input)
        {
            return await _videoInstructionCategoryAppService.CreateVideoInstructionCategoryAsync(input);
        }

        [HttpPut]
        public async Task<VideoInstructionCategoryDto> UpdateVideoInstructionCategory([FromBody] UpdateVideoInstructionCategoryInput input)
        {
            return await _videoInstructionCategoryAppService.UpdateVideoInstructionCategoryAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteVideoInstructionCategory(int id)
        {
            await _videoInstructionCategoryAppService.DeleteVideoInstructionCategoryAsync(new EntityDto<int>() { Id = id });
        }
    }
}
