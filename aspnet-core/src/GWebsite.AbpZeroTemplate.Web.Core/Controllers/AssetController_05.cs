using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets_05;
using GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Warranty_Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssetController_05 : GWebsiteControllerBase
    {
        private readonly IAssetAppService_05 assetAppService;

        public AssetController_05(IAssetAppService_05 assetAppService)
        {
            this.assetAppService = assetAppService;
        }

        [HttpGet]
        public PagedResultDto<AssetDto_05> GetAssetsByFilter(AssetFilter_05 assetFilter)
        {
            return assetAppService.GetAssets(assetFilter);
        }

        [HttpGet]
        public AssetDto_05 GetAssetForEdit(string id)
        {
            return assetAppService.GetAssetForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditAsset([FromBody] AssetDto_05 input)
        {
            assetAppService.CreateOrEditAsset(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAsset(string id)
        {
            assetAppService.DeleteAsset(id);
        }

        [HttpGet]
        public AssetForViewDto_05 GetAssetForView(string id)
        {
            return assetAppService.GetAssetForView(id);
        }

        [HttpGet]
        public AssetOutput_05 GetAssetEdit(string id)
        {
            return assetAppService.GetAssetEdit(id);
        }

        [HttpGet]
        public PagedResultDto<WarrantyDto> GetWarrantysForView(string assetId)
        {
            return assetAppService.GetWarrantysForView(assetId);
        }

    }
}
