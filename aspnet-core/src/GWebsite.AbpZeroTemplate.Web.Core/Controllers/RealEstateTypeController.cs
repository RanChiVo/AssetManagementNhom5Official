using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstateTypes;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstateTypes.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RealEstateTypeController : GWebsiteControllerBase
    {
        private readonly IRealEstateTypeAppService RealEstateTypeAppService;

        public RealEstateTypeController(IRealEstateTypeAppService RealEstateTypeAppService)
        {
            this.RealEstateTypeAppService = RealEstateTypeAppService;
        }

        [HttpGet]
        public PagedResultDto<RealEstateTypeDto_9> GetRealEstateTypesByFilter(RealEstateTypeFilter_9 RealEstateTypeFilter)
        {
            return RealEstateTypeAppService.GetRealEstateTypes(RealEstateTypeFilter);
        }

        [HttpGet]
        public RealEstateTypeInput_9 GetRealEstateTypeForEdit(int id)
        {
            return RealEstateTypeAppService.GetRealEstateTypeForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditRealEstateType([FromBody] RealEstateTypeInput_9 input)
        {
            this.RealEstateTypeAppService.CreateOrEditRealEstateType(input);
        }

        [HttpDelete("{id}")]
        public void DeleteRealEstateType(int id)
        {
            this.RealEstateTypeAppService.DeleteRealEstateType(id);
        }

        [HttpGet]
        public RealEstateTypeForViewDto_9 GetRealEstateTypeForView(int id)
        {
            return RealEstateTypeAppService.GetRealEstateTypeForView(id);
        }
    }
}
