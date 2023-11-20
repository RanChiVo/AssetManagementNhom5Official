using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssetActivityController : GWebsiteControllerBase
    {
        private readonly IAssetActivityAppService customerAppService;

        public AssetActivityController(IAssetActivityAppService customerAppService)
        {
            this.customerAppService = customerAppService;
        }

        [HttpGet]
        public PagedResultDto<AssetActivityDto> GetAssetActivitiesByFilter(AssetActivityFilter customerFilter)
        {
            return customerAppService.GetAssetActivities(customerFilter);
        }

        [HttpGet]
        public AssetActivityInput GetAssetActivityForEdit(int id)
        {
            return customerAppService.GetAssetActivityForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditAssetActivity([FromBody] AssetActivityInput input)
        {
            customerAppService.CreateOrEditAssetActivity(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAssetActivity(int id)
        {
            customerAppService.DeleteAssetActivity(id);
        }

        [HttpGet]
        public AssetActivityForViewDto GetAssetActivityForView(int id)
        {
            return customerAppService.GetAssetActivityForView(id);
        }
    }
}
