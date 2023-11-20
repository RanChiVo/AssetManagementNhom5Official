using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.GoodsInvoices.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.GoodsInvoices
{
    public interface IGoodsInvoiceAppService
    {
        void CreateOrEditGoodsInvoice(GoodsInvoiceInput goodsinvoiceInput);
        GoodsInvoiceInput GetGoodsInvoiceForEdit(int id);
        void DeleteGoodsInvoice(int id);
        PagedResultDto<GoodsInvoiceDto> GetGoodsInvoices(GoodsInvoiceFilter input);
        GoodsInvoiceForViewDto GetGoodsInvoiceForView(int id);
        Task<ContractOutput> GetContractComboboxForEditAsync(NullableIdDto input);
        IList<GoodsContract> GetGoodsContract(string ContractCode);
        PagedResultDto<ContractDto> GetContracts(ContractFilter input);
    }
}
