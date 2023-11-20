using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalPlanDetails.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.DisposalPlanDetails
{
    public interface IDisposalPlanDetailAppService
    {
        void CreateOrEditDisposalPlanDetail(DisposalPlanDetailInput customerInput);
        DisposalPlanDetailInput GetDisposalPlanDetailForEdit(int id);
        void DeleteDisposalPlanDetail(int id);
        PagedResultDto<DisposalPlanDetailDto> GetDisposalPlanDetails(DisposalPlanDetailFilter input);
    }
}
