using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlanDetails;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlanDetails.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ShoppingPlanDetailController : GWebsiteControllerBase
    {
        private readonly IShoppingPlanDetailAppService shoppingPlanAppService;

        public ShoppingPlanDetailController(IShoppingPlanDetailAppService shoppingPlanAppService)
        {
            this.shoppingPlanAppService = shoppingPlanAppService;
        }

        [HttpGet]
        public PagedResultDto<ShoppingPlanDetailDto> GetShoppingPlansByFilter(ShoppingPlanDetailFilter shoppingPlanFilter)
        {
            return shoppingPlanAppService.GetShoppingPlanDetails(shoppingPlanFilter);
        }

        [HttpGet]
        public ShoppingPlanDetailInput GetShoppingPlanDetailForEdit(int id)
        {
            return shoppingPlanAppService.GetShoppingPlanDetailForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditShoppingPlanDetail([FromBody] ShoppingPlanDetailInput input)
        {
            shoppingPlanAppService.CreateOrEditShoppingPlanDetail(input);
        }

        [HttpDelete("{id}")]
        public void DeleteShoppingPlanDetail(int id)
        {
            shoppingPlanAppService.DeleteShoppingPlanDetail(id);
        }
    }
}
