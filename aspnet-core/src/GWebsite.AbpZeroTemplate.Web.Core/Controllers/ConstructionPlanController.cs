using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlans;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlans.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ConstructionPlanController : GWebsiteControllerBase
    {
        private readonly IConstructionPlanAppService constructionPlanAppService;

        public ConstructionPlanController(IConstructionPlanAppService constructionPlanAppService)
        {
            this.constructionPlanAppService = constructionPlanAppService;
        }

        [HttpGet]
        public PagedResultDto<ConstructionPlanDto> GetConstructionPlansByFilter(ConstructionPlanFilter constructionPlanFilter)
        {
            return constructionPlanAppService.GetConstructionPlans(constructionPlanFilter);
        }

        [HttpGet]
        public ConstructionPlanInput GetConstructionPlanForEdit(int id)
        {
            return constructionPlanAppService.GetConstructionPlanForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditConstructionPlan([FromBody] ConstructionPlanInput input)
        {
            constructionPlanAppService.CreateOrEditConstructionPlan(input);
        }

        [HttpDelete("{id}")]
        public void DeleteConstructionPlan(int id)
        {
            constructionPlanAppService.DeleteConstructionPlan(id);
        }

        [HttpGet]
        public ConstructionPlanForViewDto GetConstructionPlanForView(int id)
        {
            return constructionPlanAppService.GetConstructionPlanForView(id);
        }
    }
}
