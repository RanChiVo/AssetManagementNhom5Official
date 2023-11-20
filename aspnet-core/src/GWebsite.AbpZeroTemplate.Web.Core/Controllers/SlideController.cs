using Abp.Application.Services.Dto;
using Abp.Runtime.Caching;
using GWebsite.AbpZeroTemplate.Application.Share.Templates;
using GWebsite.AbpZeroTemplate.Application.Share.Templates.Slider.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SlideController : GWebsiteControllerBase
    {
        private readonly ICacheManager _cacheManager;
        private readonly ISlidesAppService _slidesAppService;

        public SlideController(ICacheManager cacheManager, ISlidesAppService slidesAppService)
        {
            _cacheManager = cacheManager;
            _slidesAppService = slidesAppService;
        }

        [HttpGet]
        public async Task<PagedResultDto<SlideDto>> GetSlidesPaging(GetSlidesPagingInput input)
        {
            return await _slidesAppService.GetSlidesPaging(input);
        }

        [HttpGet]
        public async Task<ListResultDto<SlideDto>> GetAllSlides(string filter)
        {
            return await _slidesAppService.GetSlidesAsync(new GetSlidesInput() { Keyword = filter });
        }

        [HttpGet("{id}")]
        public async Task<SlideDto> GetById(int id)
        {
            return await _slidesAppService.GetByIdAsync(new EntityDto<int>() { Id = id });
        }

        [HttpPost]
        public async Task<SlideDto> AddSlide([FromBody] CreateSlideInput createSlideInput)
        {
            return await _slidesAppService.CreateSlideAsync(createSlideInput);
        }

        [HttpPut]
        public async Task<SlideDto> UpdateSlide([FromBody] UpdateSlideInput updateSlideInput)
        {
            return await _slidesAppService.UpdateSlideAsync(updateSlideInput);
        }

        [HttpDelete("{id}")]
        public async Task DeleteSlide(int id)
        {
            await _slidesAppService.DeleteSlideAsync(new EntityDto<int>() { Id = id });
        }
    }
}
