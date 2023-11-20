using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ExportingUsedAssets;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ExportingUsedAssetController : GWebsiteControllerBase
    {
        private readonly IExportingUsedAssetAppService ExportingUsedAssetAppService;

        public ExportingUsedAssetController(IExportingUsedAssetAppService ExportingUsedAssetAppService)
        {
            this.ExportingUsedAssetAppService = ExportingUsedAssetAppService;
        }

        [HttpGet]
        public PagedResultDto<ExportingUsedAssetDto> GetExportingUsedAssetsByFilter(ExportingUsedAssetFilter ExportingUsedAssetFilter)
        {
            return ExportingUsedAssetAppService.GetExportingUsedAssets(ExportingUsedAssetFilter);
        }

        [HttpGet]
        public ExportingUsedAssetInput GetExportingUsedAssetForEdit(int id)
        {
            return ExportingUsedAssetAppService.GetExportingUsedAssetForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditExportingUsedAsset([FromBody] ExportingUsedAssetInput input)
        {
            ExportingUsedAssetAppService.CreateOrEditExportingUsedAsset(input);
        }

        [HttpDelete("{id}")]
        public void DeleteExportingUsedAsset(int id)
        {
            ExportingUsedAssetAppService.DeleteExportingUsedAsset(id);
        }

        [HttpGet]
        public ExportingUsedAssetForViewDto GetExportingUsedAssetForView(int id)
        {
            return ExportingUsedAssetAppService.GetExportingUsedAssetForView(id);
        }
    }
}