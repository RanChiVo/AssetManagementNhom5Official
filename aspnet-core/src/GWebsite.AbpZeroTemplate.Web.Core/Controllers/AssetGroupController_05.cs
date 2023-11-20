using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssetGroupController_05 : GWebsiteControllerBase
    {
        private readonly IAssetGroupAppService_05 assetGroupAppService;

        public AssetGroupController_05(IAssetGroupAppService_05 assetGroupAppService)
        {
            this.assetGroupAppService = assetGroupAppService;
        }

        [HttpGet]
        public PagedResultDto<AssetGroupDto_05> GetAssetGroupByFilter(AssetGroupFilter_05 assetGroupFilter)
        {
            return assetGroupAppService.GetAssetGroups(assetGroupFilter);
        }

        [HttpGet]
        public AssetGroupInput_05 GetAssetGroupForEdit(string id)
        {
            return assetGroupAppService.GetAssetGroupForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditAssetGroup([FromBody] AssetGroupDto_05 input)
        {
            assetGroupAppService.CreateOrEditAssetGroup(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAssetGroup(string id)
        {
            assetGroupAppService.DeleteAssetGroup(id);
        }

        [HttpGet]
        public AssetGroupForViewDto_05 GetAssetGroupForView(string id)
        {
            return assetGroupAppService.GetAssetGroupForView(id);
        }

        [HttpGet]
        public AssetGroupOutput_05 GetAsseGroupEdit(string id)
        {
            return assetGroupAppService.GetAssetGroupEdit(id);
        }
    }
}
