using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05
{
    public interface IAssetGroupAppService_05
    {
        void CreateOrEditAssetGroup(AssetGroupDto_05 assetGroupInput);
        AssetGroupOutput_05 GetAssetGroupEdit(string id);
        AssetGroupInput_05 GetAssetGroupForEdit(string id);
        void DeleteAssetGroup(string id);
        PagedResultDto<AssetGroupDto_05> GetAssetGroups(AssetGroupFilter_05 input);
        AssetGroupForViewDto_05 GetAssetGroupForView(string id);
    }
}
