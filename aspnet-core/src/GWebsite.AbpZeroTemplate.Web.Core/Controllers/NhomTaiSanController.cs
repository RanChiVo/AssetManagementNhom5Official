using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.NhomTaiSan;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.NhomTaiSan.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class NhomTaiSanController : GWebsiteControllerBase
    {
        private readonly IPropertyGroupAppService propertyGroupAppService;

        public NhomTaiSanController(IPropertyGroupAppService propertyGroupAppService)
        {
            this.propertyGroupAppService = propertyGroupAppService;
        }

        [HttpGet]
        public PagedResultDto<NhomTaiSanDto> GetNhomTaiSansByFilter(NhomTaiSanFilter propertyGroupFilter)
        {
            return propertyGroupAppService.GetPropertyGroups(propertyGroupFilter);
        }

        [HttpGet]
        public NhomTaiSanInput GetPropertyGroupForEdit(int id)
        {
            return propertyGroupAppService.GetPropertyGroupForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditPropertyGroup([FromBody] NhomTaiSanInput input)
        {
            propertyGroupAppService.CreateOrEditPropertyGroup(input);
        }

        [HttpDelete("{id}")]
        public void DeletePropertyGroup(int id)
        {
            propertyGroupAppService.DeletePropertyGroup(id);
        }

        [HttpGet]
        public NhomTaiSanForViewDto GePropertyGroupForView(int id)
        {
            return propertyGroupAppService.GetPropertyGroupForView(id);
        }
    }
}
