using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.NhomTaiSan.DTO;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.NhomTaiSan
{
    public interface IPropertyGroupAppService
    {
        void CreateOrEditPropertyGroup(NhomTaiSanInput NhomTaiSanInput);
        NhomTaiSanInput GetPropertyGroupForEdit(int id);
        void DeletePropertyGroup(int id);
        PagedResultDto<NhomTaiSanDto> GetPropertyGroups(NhomTaiSanFilter input);
        NhomTaiSanForViewDto GetPropertyGroupForView(int id);
    }
}
