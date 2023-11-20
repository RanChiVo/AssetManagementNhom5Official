using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DirectorShoppingPlans.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.DirectorShoppingPlans
{
    public interface IDirectorShoppingPlanAppService
    {
        void CreateOrEditDirectorShoppingPlan(DirectorShoppingPlanInput directorInput);
        DirectorShoppingPlanInput GetDirectorShoppingPlanForEdit(int id);
        void DeleteDirectorShoppingPlan(int id);
        PagedResultDto<DirectorShoppingPlanDto> GetDirectorShoppingPlans(DirectorShoppingPlanFilter input);
        DirectorShoppingPlanForViewDto GetDirectorShoppingPlanForView(int id);
    }
}
