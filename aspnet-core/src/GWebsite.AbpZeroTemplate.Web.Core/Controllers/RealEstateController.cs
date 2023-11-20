using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstates;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstates.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RealEstateController : GWebsiteControllerBase
    {
        private readonly IRealEstateAppService RealEstateAppService;

        public RealEstateController(IRealEstateAppService RealEstateAppService)
        {
            this.RealEstateAppService = RealEstateAppService;
        }

        [HttpGet]
        public PagedResultDto<RealEstateDto_9> GetRealEstatesByFilter(RealEstateFilter_9 RealEstateFilter)
        {
            return RealEstateAppService.GetRealEstates(RealEstateFilter);
        }

        [HttpGet]
        public RealEstateInput_9 GetRealEstateForEdit(int id)
        {
            return RealEstateAppService.GetRealEstateForEdit(id);
        }

        [HttpGet]
        public RealEstateInput_9 GetRealEstateForEditWithMTS(string mts)
        {
            return RealEstateAppService.GetRealEstateForEditWithMTS(mts);
        }

        [HttpPost]
        public void CreateOrEditRealEstate([FromBody] RealEstateInput_9 input)
        {
            this.RealEstateAppService.CreateOrEditRealEstate(input);
        }

        [HttpDelete("{id}")]
        public void DeleteRealEstate(int id)
        {
            this.RealEstateAppService.DeleteRealEstate(id);
        }

        [HttpGet]
        public RealEstateForViewDto_9 GetRealEstateForView(int id)
        {
            return RealEstateAppService.GetRealEstateForView(id);
        }
    }
}
