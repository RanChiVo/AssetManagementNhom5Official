using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Warranty_Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets_05
{
    public interface IAssetAppService_05
    {
        void CreateOrEditAsset(AssetDto_05 assetInput);
        AssetDto_05 GetAssetForEdit(string id);
        AssetOutput_05 GetAssetEdit(string id);
        void DeleteAsset(string id);
        PagedResultDto<AssetDto_05> GetAssets(AssetFilter_05 input);
        AssetForViewDto_05 GetAssetForView(string id);
        PagedResultDto<WarrantyDto> GetWarrantysForView(string assetId);
    }
}