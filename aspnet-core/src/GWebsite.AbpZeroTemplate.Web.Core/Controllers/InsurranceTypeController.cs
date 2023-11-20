using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.InsurranceTypes;
using GWebsite.AbpZeroTemplate.Application.Share.InsurranceTypes.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class InsurranceTypeController : GWebsiteControllerBase
    {
        private readonly IInsurranceTypeAppService insurrancetypeAppService;

        public InsurranceTypeController(IInsurranceTypeAppService insurrancetypeAppService)
        {
            this.insurrancetypeAppService = insurrancetypeAppService;
        }

        [HttpGet]
        public PagedResultDto<InsurranceTypeDto> GetInsurranceTypesByFilter(InsurranceTypeFilter insurrancetypeFilter)
        {
            return insurrancetypeAppService.GetInsurranceTypes(insurrancetypeFilter);
        }

        [HttpGet]
        public InsurranceTypeInput GetInsurranceTypeForEdit(int id)
        {
            return insurrancetypeAppService.GetInsurranceTypeForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditInsurranceType([FromBody] InsurranceTypeInput input)
        {
            insurrancetypeAppService.CreateOrEditInsurranceType(input);
        }

        [HttpDelete("{id}")]
        public void DeleteInsurranceType(int id)
        {
            insurrancetypeAppService.DeleteInsurranceType(id);
        }

        [HttpGet]
        public InsurranceTypeForViewDto GetInsurranceTypeForView(int id)
        {
            return insurrancetypeAppService.GetInsurranceTypeForView(id);
        }
    }
}
