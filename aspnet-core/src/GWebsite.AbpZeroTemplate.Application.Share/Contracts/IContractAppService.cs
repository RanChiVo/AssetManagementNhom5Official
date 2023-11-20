using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Suppliers.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Contracts
{
    public interface IContractAppService
    {
        void CreateOrEditContract(ContractInput contractInput);
        ContractInput GetContractForEdit(int id);
        void DeleteContract(int id);
        PagedResultDto<ContractDto> GetContracts(ContractFilter input);
        ContractForViewDto GetContractForView(int id);
        Task<BidOutput> GetBidComboboxForEditAsync(NullableIdDto input);
        Task<SupplierOutput> GetSupplierComboboxForEditAsync(NullableIdDto input);
        Task<ContractOutput> GetContractComboboxForEditAsync(NullableIdDto input);
    }
}
