using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalPlans.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.DisposalPlans
{
    public interface IDisposalPlanAppService
    {
        void CreateOrEditDisposalPlan(DisposalPlanInput customerInput);
        DisposalPlanInput GetDisposalPlanForEdit(int id);
        void DeleteDisposalPlan(int id);
        PagedResultDto<DisposalPlanDto> GetDisposalPlans(DisposalPlanFilter input);
        DisposalPlanForViewDto GetDisposalPlanForView(int id);
    }
}
