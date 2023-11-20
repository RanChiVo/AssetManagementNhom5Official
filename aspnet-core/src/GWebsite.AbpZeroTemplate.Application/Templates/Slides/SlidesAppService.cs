using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Templates;
using GWebsite.AbpZeroTemplate.Application.Share.Templates.Slider.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.Templates.Slides
{
    public class SlidesAppService : GWebsiteAppServiceBase, ISlidesAppService
    {
        private readonly IRepository<Slide, int> _slideRepository;

        public SlidesAppService(IRepository<Slide, int> slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public async Task<SlideDto> CreateSlideAsync(CreateSlideInput input)
        {
            try
            {
                var slide = input.MapTo<Slide>();
                slide = await _slideRepository.InsertAsync(slide);
                return slide.MapTo<SlideDto>();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<SlideDto> UpdateSlideAsync(UpdateSlideInput input)
        {
            var slide = input.MapTo<Slide>();
            slide = await _slideRepository.UpdateAsync(slide);
            return slide.MapTo<SlideDto>();
        }

        public async Task DeleteSlideAsync(EntityDto<int> input)
        {
            await _slideRepository.DeleteAsync(input.Id);
        }

        protected IQueryable<Slide> GetSlidesQuery(GetSlidesInput input)
        {
            return _slideRepository.GetAll().Where(x =>
               string.IsNullOrEmpty(input.Keyword)
               || x.Content.Contains(input.Keyword)
               || x.Name.Contains(input.Keyword));
        }

        public async Task<ListResultDto<SlideDto>> GetSlidesAsync(GetSlidesInput input)
        {
            var query = GetSlidesQuery(input);

            var items = await query.ToListAsync();

            var list = new ListResultDto<SlideDto>(
                items.Select(item =>
                {
                    var dto = ObjectMapper.Map<SlideDto>(item);
                    return dto;
                }).ToList());
            return list;
        }

        public async Task<SlideDto> GetByIdAsync(EntityDto<int> input)
        {
            var slide = await _slideRepository.GetAsync(input.Id);
            return slide.MapTo<SlideDto>();
        }

        public async Task<PagedResultDto<SlideDto>> GetSlidesPaging(GetSlidesPagingInput input)
        {
            var query = GetSlidesQuery(input);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToListAsync();

            var list = items.Select(item =>
            {
                var dto = ObjectMapper.Map<SlideDto>(item);
                return dto;
            }).ToList();

            return new PagedResultDto<SlideDto>(
                totalCount,
                list
            );
        }
    }
}
