using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractManagements;
using GWebsite.AbpZeroTemplate.Application.Share.ContractManagements.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ContractManagementController : GWebsiteControllerBase
    {
        private readonly IContractManagementAppService ContractManagementAppService;

        public ContractManagementController(IContractManagementAppService ContractManagementAppService)
        {
            this.ContractManagementAppService = ContractManagementAppService;
        }

        [HttpGet]
        public PagedResultDto<ContractManagementDto> GetContractManagementsByFilter(ContractManagementFilter ContractManagementFilter)
        {
            return ContractManagementAppService.GetContractManagements(ContractManagementFilter);
        }

        [HttpGet]
        public ContractManagementInput GetContractManagementForEdit(int id)
        {
            return ContractManagementAppService.GetContractManagementForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditContractManagement([FromBody] ContractManagementInput input)
        {
            ContractManagementAppService.CreateOrEditContractManagement(input);
        }

        [HttpDelete("{id}")]
        public void DeleteContractManagement(int id)
        {
            ContractManagementAppService.DeleteContractManagement(id);
        }

        [HttpGet]
        public ContractManagementForViewDto GetContractManagementForView(int id)
        {
            return ContractManagementAppService.GetContractManagementForView(id);
        }
    }
}
