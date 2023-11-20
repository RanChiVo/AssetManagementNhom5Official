using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstateTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstateTypes
{
    public interface IRealEstateTypeAppService
    {
        void CreateOrEditRealEstateType(RealEstateTypeInput_9 RealEstateTypeInput);
        RealEstateTypeInput_9 GetRealEstateTypeForEdit(int id);
        void DeleteRealEstateType(int id);
        PagedResultDto<RealEstateTypeDto_9> GetRealEstateTypes(RealEstateTypeFilter_9 input);
        RealEstateTypeForViewDto_9 GetRealEstateTypeForView(int id);
    }
}
