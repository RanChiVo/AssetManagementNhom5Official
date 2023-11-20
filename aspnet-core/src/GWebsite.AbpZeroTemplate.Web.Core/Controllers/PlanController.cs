using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Plans;
using GWebsite.AbpZeroTemplate.Application.Share.Plans.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PlanController : GWebsiteControllerBase
    {
        private readonly IPlanAppService PlanAppService;

        public PlanController(IPlanAppService PlanAppService)
        {
            this.PlanAppService = PlanAppService;
        }

        [HttpGet]
        public PagedResultDto<PlanDto> GetPlansByFilter(PlanFilter PlanFilter)
        {
            return PlanAppService.GetPlans(PlanFilter);
        }

        [HttpGet]
        public PlanInput GetPlanForEdit(int id)
        {
            return PlanAppService.GetPlanForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditPlan([FromBody] PlanInput input)
        {
            PlanAppService.CreateOrEditPlan(input);
        }

        [HttpDelete("{id}")]
        public void DeletePlan(int id)
        {
            PlanAppService.DeletePlan(id);
        }

        [HttpGet]
        public PlanForViewDto GetPlanForView(int id)
        {
            return PlanAppService.GetPlanForView(id);
        }
    }
}
