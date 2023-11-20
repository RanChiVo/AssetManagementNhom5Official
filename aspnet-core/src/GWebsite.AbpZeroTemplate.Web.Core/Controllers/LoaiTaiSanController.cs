using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiTaiSan;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiTaiSan.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LoaiTaiSanController : GWebsiteControllerBase
    {
        private readonly IPropertyTypeAppService propertyTypeAppService;

        public LoaiTaiSanController(IPropertyTypeAppService propertyTypeAppService)
        {
            this.propertyTypeAppService = propertyTypeAppService;
        }

        [HttpGet]
        public PagedResultDto<LoaiTaiSanDto> GetLoaiTaiSansByFilter(LoaiTaiSanFilter propertyTypeFilter)
        {
            return propertyTypeAppService.GetPropertyTypes(propertyTypeFilter);
        }

        [HttpGet]
        public LoaiTaiSanInput GetPropertyTypeForEdit(int id)
        {
            return propertyTypeAppService.GetPropertyTypeForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditPropertyType([FromBody] LoaiTaiSanInput input)
        {
            propertyTypeAppService.CreateOrEditPropertyType(input);
        }

        [HttpDelete("{id}")]
        public void DeletePropertyType(int id)
        {
            propertyTypeAppService.DeletePropertyType(id);
        }

        [HttpGet]
        public LoaiTaiSanForViewDto GePropertyTypeForView(int id)
        {
            return propertyTypeAppService.GetPropertyTypeForView(id);
        }
    }
}
