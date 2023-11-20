using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Insurrances.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Insurrances
{
    public interface IInsurranceAppService
    {
        void CreateOrEditInsurrance(InsurranceInput insurranceInput);
        InsurranceInput GetInsurranceForEdit(int id);
        void DeleteInsurrance(int id);
        PagedResultDto<InsurranceDto> GetInsurrances(InsurranceFilter input);
        InsurranceForViewDto GetInsurranceForView(int id);
    }
}
