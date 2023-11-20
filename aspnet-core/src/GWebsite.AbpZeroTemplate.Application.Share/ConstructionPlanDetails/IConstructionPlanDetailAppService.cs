using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlanDetails.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlanDetails
{
    public interface IConstructionPlanDetailAppService
    {
        void CreateOrEditConstructionPlanDetail(ConstructionPlanDetailInput customerInput);
        ConstructionPlanDetailInput GetConstructionPlanDetailForEdit(int id);
        void DeleteConstructionPlanDetail(int id);
        PagedResultDto<ConstructionPlanDetailDto> GetConstructionPlanDetails(ConstructionPlanDetailFilter input);
    }
}
