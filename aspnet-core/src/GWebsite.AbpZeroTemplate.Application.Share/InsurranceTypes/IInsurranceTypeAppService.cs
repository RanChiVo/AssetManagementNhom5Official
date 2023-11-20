using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.InsurranceTypes.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.InsurranceTypes
{
    public interface IInsurranceTypeAppService
    {
        void CreateOrEditInsurranceType(InsurranceTypeInput insurrancetypeInput);
        InsurranceTypeInput GetInsurranceTypeForEdit(int id);
        void DeleteInsurranceType(int id);
        PagedResultDto<InsurranceTypeDto> GetInsurranceTypes(InsurranceTypeFilter input);
        InsurranceTypeForViewDto GetInsurranceTypeForView(int id);
    }
}
