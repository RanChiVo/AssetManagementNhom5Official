using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiTaiSan.DTO;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiTaiSan
{
    public interface IPropertyTypeAppService
    {
        void CreateOrEditPropertyType(LoaiTaiSanInput loaiTaiSanInput);
        LoaiTaiSanInput GetPropertyTypeForEdit(int id);
        void DeletePropertyType(int id);
        PagedResultDto<LoaiTaiSanDto> GetPropertyTypes(LoaiTaiSanFilter input);
        LoaiTaiSanForViewDto GetPropertyTypeForView(int id);
    }
}
