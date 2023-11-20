using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Insurrances;
using GWebsite.AbpZeroTemplate.Application.Share.Insurrances.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class InsurranceController : GWebsiteControllerBase
    {
        private readonly IInsurranceAppService insurranceAppService;

        public InsurranceController(IInsurranceAppService insurranceAppService)
        {
            this.insurranceAppService = insurranceAppService;
        }

        [HttpGet]
        public PagedResultDto<InsurranceDto> GetInsurrancesByFilter(InsurranceFilter insurranceFilter)
        {
            return insurranceAppService.GetInsurrances(insurranceFilter);
        }

        [HttpGet]
        public InsurranceInput GetInsurranceForEdit(int id)
        {
            return insurranceAppService.GetInsurranceForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditInsurrance([FromBody] InsurranceInput input)
        {
            insurranceAppService.CreateOrEditInsurrance(input);
        }

        [HttpDelete("{id}")]
        public void DeleteInsurrance(int id)
        {
            insurranceAppService.DeleteInsurrance(id);
        }

        [HttpGet]
        public InsurranceForViewDto GetInsurranceForView(int id)
        {
            return insurranceAppService.GetInsurranceForView(id);
        }
    }
}
