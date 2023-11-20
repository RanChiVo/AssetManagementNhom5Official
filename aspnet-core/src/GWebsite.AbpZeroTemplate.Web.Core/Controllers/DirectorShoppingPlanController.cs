using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DirectorShoppingPlans;
using GWebsite.AbpZeroTemplate.Application.Share.DirectorShoppingPlans.Dto;
using Microsoft.AspNetCore.Mvc;


namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DirectorShoppingPlanController: GWebsiteControllerBase
    {
        private readonly IDirectorShoppingPlanAppService directorShoppingPlanAppService;

        public DirectorShoppingPlanController(IDirectorShoppingPlanAppService directorShoppingPlanAppService)
        {
            this.directorShoppingPlanAppService = directorShoppingPlanAppService;
        }

        [HttpGet]
        public PagedResultDto<DirectorShoppingPlanDto> GetDirectorShoppingPlansByFilter(DirectorShoppingPlanFilter shoppingPlanFilter)
        {
            return directorShoppingPlanAppService.GetDirectorShoppingPlans(shoppingPlanFilter);
        }

        [HttpGet]
        public DirectorShoppingPlanInput GetDirectorShoppingPlanForEdit(int id)
        {
            return directorShoppingPlanAppService.GetDirectorShoppingPlanForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditDirectorShoppingPlan([FromBody] DirectorShoppingPlanInput input)
        {
            directorShoppingPlanAppService.CreateOrEditDirectorShoppingPlan(input);
        }

        [HttpDelete("{id}")]
        public void DeleteDirectorShoppingPlan(int id)
        {
            directorShoppingPlanAppService.DeleteDirectorShoppingPlan(id);
        }

        [HttpGet]
        public DirectorShoppingPlanForViewDto GetDirectorShoppingPlanForView(int id)
        {
            return directorShoppingPlanAppService.GetDirectorShoppingPlanForView(id);
        }
    }
}
