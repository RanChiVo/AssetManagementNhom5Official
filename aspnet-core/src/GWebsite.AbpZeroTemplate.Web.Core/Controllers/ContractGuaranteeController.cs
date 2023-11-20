using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractGuarantees;
using GWebsite.AbpZeroTemplate.Application.Share.ContractGuarantees.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ContractGuaranteeController : GWebsiteControllerBase
    {
        private readonly IContractGuaranteeAppService ContractGuaranteeAppService;

        public ContractGuaranteeController(IContractGuaranteeAppService ContractGuaranteeAppService)
        {
            this.ContractGuaranteeAppService = ContractGuaranteeAppService;
        }

        [HttpGet]
        public PagedResultDto<ContractGuaranteeDto> GetContractGuaranteesByFilter(ContractGuaranteeFilter ContractGuaranteeFilter)
        {
            return ContractGuaranteeAppService.GetContractGuarantees(ContractGuaranteeFilter);
        }

        [HttpGet]
        public ContractGuaranteeInput GetContractGuaranteeForEdit(int id)
        {
            return ContractGuaranteeAppService.GetContractGuaranteeForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditContractGuarantee([FromBody] ContractGuaranteeInput input)
        {
            ContractGuaranteeAppService.CreateOrEditContractGuarantee(input);
        }

        [HttpDelete("{id}")]
        public void DeleteContractGuarantee(int id)
        {
            ContractGuaranteeAppService.DeleteContractGuarantee(id);
        }

        [HttpGet]
        public ContractGuaranteeForViewDto GetContractGuaranteeForView(int id)
        {
            return ContractGuaranteeAppService.GetContractGuaranteeForView(id);
        }
    }
}
