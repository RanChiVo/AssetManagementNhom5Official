using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ExportingUsedAssets;

namespace GWebsite.AbpZeroTemplate.Application.Share.ExportingUsedAssets
{
    public interface IExportingUsedAssetAppService
    {
        void CreateOrEditExportingUsedAsset(ExportingUsedAssetInput ExportingUsedAssetInput);
        ExportingUsedAssetInput GetExportingUsedAssetForEdit(int id);
        void DeleteExportingUsedAsset(int id);
        PagedResultDto<ExportingUsedAssetDto> GetExportingUsedAssets(ExportingUsedAssetFilter input);
        //
        //List<ExportingUsedAssetDto> GetExportingUsedAssets (ExportingUsedAssetFilter input);
        ExportingUsedAssetForViewDto GetExportingUsedAssetForView(int id);
        //
    }
}