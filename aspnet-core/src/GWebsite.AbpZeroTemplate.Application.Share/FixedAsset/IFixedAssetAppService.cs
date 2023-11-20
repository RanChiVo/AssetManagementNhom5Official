using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.FixedAssets.Dto;
using System.Threading.Tasks;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.FixedAssets
{
    public interface IFixedAssetAppService
    {
        void CreateOrEditFixedAsset(FixedAssetInput fixedAssetInput);
        FixedAssetInput GetFixedAssetForEdit(int id);
        void DeleteFixedAsset(int id);
        PagedResultDto<FixedAssetDto> GetFixedAssets(FixedAssetFilter input);
        FixedAssetForViewDto GetFixedAssetForView(int id);
    }
}
