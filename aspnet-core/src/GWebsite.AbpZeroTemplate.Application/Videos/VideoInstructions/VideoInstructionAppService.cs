using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructions;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructions.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.Videos.VideoInstructions
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_VideoInstruction)]
    public class VideoInstructionAppService : GWebsiteAppServiceBase, IVideoInstructionAppService
    {
        private readonly IRepository<VideoInstruction, int> _videoInstructionRepository;

        public VideoInstructionAppService(IRepository<VideoInstruction, int> videoInstructionRepository)
        {
            _videoInstructionRepository = videoInstructionRepository;
        }

        public async Task<ListResultDto<VideoInstructionDto>> GetVideoInstructionsAsync()
        {
            var items = await _videoInstructionRepository.GetAllListAsync();

            return new ListResultDto<VideoInstructionDto>(
                items.Select(item => ObjectMapper.Map<VideoInstructionDto>(item)).ToList());
        }

        public async Task<PagedResultDto<VideoInstructionListDto>> GetVideoInstructionsAsync(GetVideoInstructionInput input)
        {
            var query = _videoInstructionRepository.GetAll()
                .WhereIf(!input.Title.IsNullOrWhiteSpace(), m => m.Title.Contains(input.Title));

            var totalCount = await query.CountAsync();
            var items = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            return new PagedResultDto<VideoInstructionListDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<VideoInstructionListDto>(item)).ToList());
        }

        public async Task<VideoInstructionDto> GetVideoInstructionByIdAsync(EntityDto<int> input)
        {
            var entity = await _videoInstructionRepository.GetAsync(input.Id);
            return ObjectMapper.Map<VideoInstructionDto>(entity);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_VideoInstruction_Create)]
        public async Task<VideoInstructionDto> CreateVideoInstructionAsync(CreateVideoInstructionInput input)
        {
            var entity = ObjectMapper.Map<VideoInstruction>(input);
            entity = await _videoInstructionRepository.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<VideoInstructionDto>(entity);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_VideoInstruction_Edit)]
        public async Task<VideoInstructionDto> UpdateVideoInstructionAsync(UpdateVideoInstructionInput input)
        {
            var entity = await _videoInstructionRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, entity);
            entity = await _videoInstructionRepository.UpdateAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<VideoInstructionDto>(entity);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_VideoInstruction_Delete)]
        public async Task DeleteVideoInstructionAsync(EntityDto<int> input)
        {
            var entity = await _videoInstructionRepository.GetAsync(input.Id);
            await _videoInstructionRepository.DeleteAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}
