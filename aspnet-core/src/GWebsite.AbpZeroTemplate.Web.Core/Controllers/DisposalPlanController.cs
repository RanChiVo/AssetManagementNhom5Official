using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalPlans;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalPlans.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DisposalPlanController: GWebsiteAppServiceBase
    {
        private readonly IDisposalPlanAppService disposalPlanAppService;

        public DisposalPlanController(IDisposalPlanAppService disposalPlanAppService)
        {
            this.disposalPlanAppService = disposalPlanAppService;
        }

        [HttpGet]
        public PagedResultDto<DisposalPlanDto> GetDisposalPlansByFilter(DisposalPlanFilter disposalPlanFilter)
        {
            return disposalPlanAppService.GetDisposalPlans(disposalPlanFilter);
        }

        [HttpGet]
        public DisposalPlanInput GetDisposalPlanForEdit(int id)
        {
            return disposalPlanAppService.GetDisposalPlanForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditDisposalPlan([FromBody] DisposalPlanInput input)
        {
            disposalPlanAppService.CreateOrEditDisposalPlan(input);
        }

        [HttpDelete("{id}")]
        public void DeleteDisposalPlan(int id)
        {
            disposalPlanAppService.DeleteDisposalPlan(id);
        }

        [HttpGet]
        public DisposalPlanForViewDto GetDisposalPlanForView(int id)
        {
            return disposalPlanAppService.GetDisposalPlanForView(id);
        }
    }
}
