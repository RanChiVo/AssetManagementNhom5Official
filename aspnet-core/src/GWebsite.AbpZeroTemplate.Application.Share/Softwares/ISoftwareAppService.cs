using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Softwares.Dto;


namespace GWebsite.AbpZeroTemplate.Application.Share.Softwares
{
    public interface ISoftwareAppService
    {
        void CreateOrEditSoftware(SoftwareInput softwareInput);
        SoftwareInput GetSoftwareForEdit(int id);
        void DeleteSoftware(int id);
        PagedResultDto<SoftwareDto> GetSoftwares(SoftwareFilter input);
        SoftwareForViewDto GetSoftwareForView(int id);
    }
}
