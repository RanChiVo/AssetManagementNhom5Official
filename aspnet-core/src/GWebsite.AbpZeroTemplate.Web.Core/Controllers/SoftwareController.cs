using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Softwares;
using GWebsite.AbpZeroTemplate.Application.Share.Softwares.Dto;
using Microsoft.AspNetCore.Mvc;
namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SoftwareController : GWebsiteControllerBase
    {
        private readonly ISoftwareAppService softwareAppService;

        public SoftwareController(ISoftwareAppService softwareAppService)
        {
           this.softwareAppService = softwareAppService;
        }
        [HttpGet]
        public PagedResultDto<SoftwareDto> GetSoftwaresByFilter(SoftwareFilter customerFilter)
        {
            return softwareAppService.GetSoftwares(customerFilter);
        }

        [HttpGet]
        public SoftwareInput GetSoftwareForEdit(int id)
        {
            return softwareAppService.GetSoftwareForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditSoftware([FromBody] SoftwareInput input)
        {
            softwareAppService.CreateOrEditSoftware(input);
        }

        [HttpDelete("{id}")]
        public void DeleteSoftware(int id)
        {
            softwareAppService.DeleteSoftware(id);
        }

        [HttpGet]
        public SoftwareForViewDto GetSoftwareForView(int id)
        {
            return softwareAppService.GetSoftwareForView(id);
        }
    }
}

