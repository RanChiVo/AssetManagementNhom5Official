using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes_05;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes_05.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssetTypeControler_05 : GWebsiteControllerBase
    {
        private readonly IAssetTypeAppService_05 assetTypeAppService;

        public AssetTypeControler_05(IAssetTypeAppService_05 assetTypeAppService)
        {
            this.assetTypeAppService = assetTypeAppService;
        }

        [HttpGet]
        public PagedResultDto<AssetTypeDto_05> GetAssetTypes()
        {
            return assetTypeAppService.GetAssetTypes();
        }

        [HttpGet]
        public AssetTypeViewDto_05 GetAssetTypeForView(int id)
        {
            return assetTypeAppService.GetAssetTypeForView(id);
        }
    }
}
