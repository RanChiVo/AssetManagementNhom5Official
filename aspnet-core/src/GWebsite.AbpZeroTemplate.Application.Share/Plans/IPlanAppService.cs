using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Plans.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GWebsite.AbpZeroTemplate.Application.Share.Plans
{
    public interface IPlanAppService
    {
        void CreateOrEditPlan(PlanInput PlangInput);
        PlanInput GetPlanForEdit(int id);
        void DeletePlan(int id);
        PagedResultDto<PlanDto> GetPlans(PlanFilter input);
        PlanForViewDto GetPlanForView(int id);
    }
}
