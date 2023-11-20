using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.WarrantyGuarantees;
using GWebsite.AbpZeroTemplate.Application.Share.WarrantyGuarantees.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class WarrantyGuaranteeController : GWebsiteControllerBase
    {
        private readonly IWarrantyGuaranteeAppService WarrantyGuaranteeAppService;

        public WarrantyGuaranteeController(IWarrantyGuaranteeAppService WarrantyGuaranteeAppService)
        {
            this.WarrantyGuaranteeAppService = WarrantyGuaranteeAppService;
        }

        [HttpGet]
        public PagedResultDto<WarrantyGuaranteeDto> GetWarrantyGuaranteesByFilter(WarrantyGuaranteeFilter WarrantyGuaranteeFilter)
        {
            return WarrantyGuaranteeAppService.GetWarrantyGuarantees(WarrantyGuaranteeFilter);
        }

        [HttpGet]
        public WarrantyGuaranteeInput GetWarrantyGuaranteeForEdit(int id)
        {
            return WarrantyGuaranteeAppService.GetWarrantyGuaranteeForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditWarrantyGuarantee([FromBody] WarrantyGuaranteeInput input)
        {
            WarrantyGuaranteeAppService.CreateOrEditWarrantyGuarantee(input);
        }

        [HttpDelete("{id}")]
        public void DeleteWarrantyGuarantee(int id)
        {
            WarrantyGuaranteeAppService.DeleteWarrantyGuarantee(id);
        }

        [HttpGet]
        public WarrantyGuaranteeForViewDto GetWarrantyGuaranteeForView(int id)
        {
            return WarrantyGuaranteeAppService.GetWarrantyGuaranteeForView(id);
        }
    }
}
