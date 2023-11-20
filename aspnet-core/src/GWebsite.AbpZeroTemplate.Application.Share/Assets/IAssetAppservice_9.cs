using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets
{
    public interface IAssetAppService_9
    {
        void CreateOrEditAsset(AssetInput_9 assetInput);
        AssetInput_9 GetAssetForEdit(int id);
        AssetInput_9 GetAssetForEditWithMTS(string maTaiSan);
        void DeleteAsset(int id);
        PagedResultDto<AssetDto_9> GetAssets(AssetFilter_9 input);
        AssetForViewDto_9 GetAssetForView(int id);
    }
}
