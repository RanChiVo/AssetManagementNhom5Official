using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bids;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Suppliers;
using GWebsite.AbpZeroTemplate.Application.Share.Suppliers.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ContractController : GWebsiteControllerBase
    {
        private readonly IContractAppService contractAppService;

        public ContractController(IContractAppService contractAppService)
        {
            this.contractAppService = contractAppService;
        }

        [HttpGet]
        public PagedResultDto<ContractDto> GetContractsByFilter(ContractFilter contractFilter)
        {
            return contractAppService.GetContracts(contractFilter);
        }

        [HttpGet]
        public ContractInput GetContractForEdit(int id)
        {
            return contractAppService.GetContractForEdit(id);
        }

        [HttpGet]
        public async Task<BidOutput> GetBidComboboxForEditAsync(int id)
        {
            return await contractAppService.GetBidComboboxForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpGet]
        public async Task<SupplierOutput> GetSupplierComboboxForEditAsync(int id)
        {
            return await contractAppService.GetSupplierComboboxForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpGet]
        public async Task<ContractOutput> GetContractComboboxForEditAsync(int id)
        {
            return await contractAppService.GetContractComboboxForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpPost]
        public void CreateOrEditContract([FromBody] ContractInput input)
        {
            contractAppService.CreateOrEditContract(input);
        }

        [HttpDelete("{id}")]
        public void DeleteContract(int id)
        {
            contractAppService.DeleteContract(id);
        }

        [HttpGet]
        public ContractForViewDto GetContractForView(int id)
        {
            return contractAppService.GetContractForView(id);
        }
    }
}
