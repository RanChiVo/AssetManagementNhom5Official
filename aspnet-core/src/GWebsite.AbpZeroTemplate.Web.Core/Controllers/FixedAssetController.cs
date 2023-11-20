using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.FixedAssets;
using GWebsite.AbpZeroTemplate.Application.Share.FixedAssets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FixedAssetController : GWebsiteControllerBase
    {
        private readonly IFixedAssetAppService fixedAssetAppService;

        public FixedAssetController(IFixedAssetAppService fixedAssetAppService)
        {
            this.fixedAssetAppService = fixedAssetAppService;
        }

        [HttpGet]
        public PagedResultDto<FixedAssetDto> GetFixedAssetsByFilter(FixedAssetFilter fixedAssetFilter)
        {
            return fixedAssetAppService.GetFixedAssets(fixedAssetFilter);
        }

        [HttpGet]
        public FixedAssetInput GetFixedAssetForEdit(int id)
        {
            return fixedAssetAppService.GetFixedAssetForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditFixedAsset([FromBody] FixedAssetInput input)
        {
            fixedAssetAppService.CreateOrEditFixedAsset(input);
        }

        [HttpDelete("{id}")]
        public void DeleteFixedAsset(int id)
        {
            fixedAssetAppService.DeleteFixedAsset(id);
        }

        [HttpGet]
        public FixedAssetForViewDto GetFixedAssetForView(int id)
        {
            return fixedAssetAppService.GetFixedAssetForView(id);
        }
    }
}

