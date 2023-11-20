using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstateRepairs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstateRepairs
{
    public interface IRealEstateRepairAppService
    {
        void CreateOrEditRealEstateRepair(RealEstateRepairInput_9 RealEstateRepairInput);
        RealEstateRepairInput_9 GetRealEstateRepairForEdit(int id);

        void DeleteRealEstateRepair(int id);
        PagedResultDto<RealEstateRepairDto_9> GetRealEstateRepairs(RealEstateRepairFilter_9 input);
        RealEstateRepairForViewDto_9 GetRealEstateRepairForView(int id);
    }
}
