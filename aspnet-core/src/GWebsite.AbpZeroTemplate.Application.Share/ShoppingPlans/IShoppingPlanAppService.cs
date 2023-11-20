using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlans.Dto;
namespace GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlans
{
    public interface IShoppingPlanAppService
    {
        void CreateOrEditShoppingPlan(ShoppingPlanInput customerInput);
        ShoppingPlanInput GetShoppingPlanForEdit(int id);
        void DeleteShoppingPlan(int id);
        PagedResultDto<ShoppingPlanDto> GetShoppingPlans(ShoppingPlanFilter input);
        ShoppingPlanForViewDto GetShoppingPlanForView(int id);
    }
}
