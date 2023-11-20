using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructionCategories;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructionCategories.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.Videos.VideoInstructionCategories
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_VideoInstructionCategory)]
    public class VideoInstructionCategoryAppService : GWebsiteAppServiceBase, IVideoInstructionCategoryAppService
    {
        private readonly IRepository<VideoInstructionCategory, int> _videoInstructionRepository;

        public VideoInstructionCategoryAppService(IRepository<VideoInstructionCategory, int> videoInstructionRepository)
        {
            _videoInstructionRepository = videoInstructionRepository;
        }

        public async Task<ListResultDto<VideoInstructionCategoryDto>> GetVideoInstructionCategoriesAsync()
        {
            var items = await _videoInstructionRepository.GetAllListAsync();

            return new ListResultDto<VideoInstructionCategoryDto>(
                items.Select(item => ObjectMapper.Map<VideoInstructionCategoryDto>(item)).ToList());
        }

        public async Task<PagedResultDto<VideoInstructionCategoryListDto>> GetVideoInstructionCategoriesAsync(GetVideoInstructionCategoryInput input)
        {
            var query = _videoInstructionRepository.GetAll()
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), m => m.Name.Contains(input.Name));

            var totalCount = await query.CountAsync();
            var items = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            return new PagedResultDto<VideoInstructionCategoryListDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<VideoInstructionCategoryListDto>(item)).ToList());
        }

        public async Task<VideoInstructionCategoryDto> GetVideoInstructionCategoryByIdAsync(EntityDto<int> input)
        {
            var entity = await _videoInstructionRepository.GetAsync(input.Id);
            return ObjectMapper.Map<VideoInstructionCategoryDto>(entity);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_VideoInstructionCategory_Create)]
        public async Task<VideoInstructionCategoryDto> CreateVideoInstructionCategoryAsync(CreateVideoInstructionCategoryInput input)
        {
            var entity = ObjectMapper.Map<VideoInstructionCategory>(input);
            entity = await _videoInstructionRepository.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<VideoInstructionCategoryDto>(entity);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_VideoInstructionCategory_Edit)]
        public async Task<VideoInstructionCategoryDto> UpdateVideoInstructionCategoryAsync(UpdateVideoInstructionCategoryInput input)
        {
            var entity = await _videoInstructionRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, entity);
            entity = await _videoInstructionRepository.UpdateAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<VideoInstructionCategoryDto>(entity);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_VideoInstructionCategory_Delete)]
        public async Task DeleteVideoInstructionCategoryAsync(EntityDto<int> input)
        {
            var entity = await _videoInstructionRepository.GetAsync(input.Id);
            await _videoInstructionRepository.DeleteAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}
