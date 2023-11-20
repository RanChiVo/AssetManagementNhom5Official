using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlans.Dto;
namespace GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlans
{
    public interface IConstructionPlanAppService
    {
        void CreateOrEditConstructionPlan(ConstructionPlanInput customerInput);
        ConstructionPlanInput GetConstructionPlanForEdit(int id);
        void DeleteConstructionPlan(int id);
        PagedResultDto<ConstructionPlanDto> GetConstructionPlans(ConstructionPlanFilter input);
        ConstructionPlanForViewDto GetConstructionPlanForView(int id);
    }
}
