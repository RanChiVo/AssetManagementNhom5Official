using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlanDetails.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlanDetails
{
    public interface IShoppingPlanDetailAppService
    {
        void CreateOrEditShoppingPlanDetail(ShoppingPlanDetailInput customerInput);
        ShoppingPlanDetailInput GetShoppingPlanDetailForEdit(int id);
        void DeleteShoppingPlanDetail(int id);
        PagedResultDto<ShoppingPlanDetailDto> GetShoppingPlanDetails(ShoppingPlanDetailFilter input);
    }
}
