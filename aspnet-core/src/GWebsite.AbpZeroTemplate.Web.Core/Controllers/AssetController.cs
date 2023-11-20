using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssetController : GWebsiteControllerBase
    {
        private readonly IAssetAppService AssetAppService;

        public AssetController(IAssetAppService AssetAppService)
        {
            this.AssetAppService = AssetAppService;
        }

        [HttpGet]
        public PagedResultDto<AssetDto_9> GetAssetsByFilter(AssetFilter_9 AssetFilter)
        {
            return AssetAppService.GetAssets(AssetFilter);
        }

        [HttpGet]
        public AssetInput_9 GetAssetForEdit(int id)
        {
            return AssetAppService.GetAssetForEdit(id);
        }

        [HttpGet]
        public AssetInput_9 GetAssetForEditWithMTS(string maTaiSan)
        {
            return AssetAppService.GetAssetForEditWithMTS(maTaiSan);
        }

        [HttpPost]
        public void CreateOrEditAsset([FromBody] AssetInput_9 input)
        {
            AssetAppService.CreateOrEditAsset(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAsset(int id)
        {
            AssetAppService.DeleteAsset(id);
        }

        [HttpGet]
        public AssetForViewDto_9 GetAssetForView(int id)
        {
            return AssetAppService.GetAssetForView(id);
        }
    }
}
