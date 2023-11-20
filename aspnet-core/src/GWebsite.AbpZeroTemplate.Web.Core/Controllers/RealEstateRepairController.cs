using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstateRepairs;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstateRepairs.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RealEstateRepairController : GWebsiteControllerBase
    {
        private readonly IRealEstateRepairAppService RealEstateRepairAppService;

        public RealEstateRepairController(IRealEstateRepairAppService RealEstateRepairAppService)
        {
            this.RealEstateRepairAppService = RealEstateRepairAppService;
        }

        [HttpGet]
        public PagedResultDto<RealEstateRepairDto_9> GetRealEstateRepairsByFilter(RealEstateRepairFilter_9 RealEstateRepairFilter)
        {
            return RealEstateRepairAppService.GetRealEstateRepairs(RealEstateRepairFilter);
        }

        [HttpGet]
        public RealEstateRepairInput_9 GetRealEstateRepairForEdit(int id)
        {
            return RealEstateRepairAppService.GetRealEstateRepairForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditRealEstateRepair([FromBody] RealEstateRepairInput_9 input)
        {
            this.RealEstateRepairAppService.CreateOrEditRealEstateRepair(input);
        }

        [HttpDelete("{id}")]
        public void DeleteRealEstateRepair(int id)
        {
            this.RealEstateRepairAppService.DeleteRealEstateRepair(id);
        }

        [HttpGet]
        public RealEstateRepairForViewDto_9 GetRealEstateRepairForView(int id)
        {
            return RealEstateRepairAppService.GetRealEstateRepairForView(id);
        }
    }
}
