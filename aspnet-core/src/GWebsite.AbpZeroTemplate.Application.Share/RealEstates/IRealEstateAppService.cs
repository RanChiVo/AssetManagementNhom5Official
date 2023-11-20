using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstates.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstates
{
    public interface IRealEstateAppService
    {
        //RealEstateDto_9 CreateOrEditRealEstate(RealEstateInput_9 realEstateInput);
        void CreateOrEditRealEstate(RealEstateInput_9 realEstateInput);
        RealEstateInput_9 GetRealEstateForEdit(int id);
        RealEstateInput_9 GetRealEstateForEditWithMTS(string mts);
        void DeleteRealEstate(int id);
        PagedResultDto<RealEstateDto_9> GetRealEstates(RealEstateFilter_9 input);
        RealEstateForViewDto_9 GetRealEstateForView(int id);
    }
}
