using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlans;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlans.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ShoppingPlanController : GWebsiteControllerBase
    {
        private readonly IShoppingPlanAppService shoppingPlanAppService;

        public ShoppingPlanController(IShoppingPlanAppService shoppingPlanAppService)
        {
            this.shoppingPlanAppService = shoppingPlanAppService;
        }

        [HttpGet]
        public PagedResultDto<ShoppingPlanDto> GetShoppingPlansByFilter(ShoppingPlanFilter shoppingPlanFilter)
        {
            return shoppingPlanAppService.GetShoppingPlans(shoppingPlanFilter);
        }

        [HttpGet]
        public ShoppingPlanInput GetShoppingPlanForEdit(int id)
        {
            return shoppingPlanAppService.GetShoppingPlanForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditShoppingPlan([FromBody] ShoppingPlanInput input)
        {
            shoppingPlanAppService.CreateOrEditShoppingPlan(input);
        }

        [HttpDelete("{id}")]
        public void DeleteShoppingPlan(int id)
        {
            shoppingPlanAppService.DeleteShoppingPlan(id);
        }

        [HttpGet]
        public ShoppingPlanForViewDto GetShoppingPlanForView(int id)
        {
            return shoppingPlanAppService.GetShoppingPlanForView(id);
        }
    }
}
