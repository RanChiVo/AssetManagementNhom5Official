using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contractors;
using GWebsite.AbpZeroTemplate.Application.Share.Contractors.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ContractorController : GWebsiteControllerBase
    {
        private readonly IContractorAppService ContractorAppService;

        public ContractorController(IContractorAppService ContractorAppService)
        {
            this.ContractorAppService = ContractorAppService;
        }

        [HttpGet]
        public PagedResultDto<ContractorDto> GetContractorsByFilter(ContractorFilter ContractorFilter)
        {
            return ContractorAppService.GetContractors(ContractorFilter);
        }

        [HttpGet]
        public ContractorInput GetContractorForEdit(int id)
        {
            return ContractorAppService.GetContractorForEdit(id);
        }

        [HttpGet]
        public ContractorInput GetContractorForEditWithMaHoSoThau(string id)
        {
            return ContractorAppService.GetContractorForEditWithMaHoSoThau(id);
        }

        [HttpPost]
        public void CreateOrEditContractor([FromBody] ContractorInput input)
        {
            ContractorAppService.CreateOrEditContractor(input);
        }

        [HttpDelete("{id}")]
        public void DeleteContractor(int id)
        {
            ContractorAppService.DeleteContractor(id);
        }

        [HttpGet]
        public ContractorForViewDto GetContractorForView(int id)
        {
            return ContractorAppService.GetContractorForView(id);
        }
    }
}
