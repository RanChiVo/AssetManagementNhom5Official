using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.GoodsInvoices;
using GWebsite.AbpZeroTemplate.Application.Share.GoodsInvoices.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using Microsoft.AspNetCore.Mvc;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class GoodsInvoiceController : GWebsiteControllerBase
    {
        private readonly IGoodsInvoiceAppService goodsinvoiceAppService;

        public GoodsInvoiceController(IGoodsInvoiceAppService goodsinvoiceAppService)
        {
            this.goodsinvoiceAppService = goodsinvoiceAppService;
        }

        [HttpGet]
        public PagedResultDto<GoodsInvoiceDto> GetGoodsInvoicesByFilter(GoodsInvoiceFilter goodsinvoiceFilter)
        {
            return goodsinvoiceAppService.GetGoodsInvoices(goodsinvoiceFilter);
        }

        [HttpGet]
        public PagedResultDto<ContractDto> GetContractsByFilter(ContractFilter contractFilter)
        {
            return goodsinvoiceAppService.GetContracts(contractFilter);
        }

        [HttpGet]
        public GoodsInvoiceInput GetGoodsInvoiceForEdit(int id)
        {
            return goodsinvoiceAppService.GetGoodsInvoiceForEdit(id);
        }

        [HttpGet]
        public async Task<ContractOutput> GetContractComboboxForEditAsync(int id)
        {
            return await goodsinvoiceAppService.GetContractComboboxForEditAsync(new NullableIdDto() { Id = id });
        }


        [HttpPost]
        public void CreateOrEditGoodsInvoice([FromBody] GoodsInvoiceInput input)
        {
            goodsinvoiceAppService.CreateOrEditGoodsInvoice(input);
        }

        [HttpDelete("{id}")]
        public void DeleteGoodsInvoice(int id)
        {
            goodsinvoiceAppService.DeleteGoodsInvoice(id);
        }

        [HttpGet]
        public GoodsInvoiceForViewDto GetGoodsInvoiceForView(int id)
        {
            return goodsinvoiceAppService.GetGoodsInvoiceForView(id);
        }

        [HttpGet]
        public IList<GoodsContract> GetGoodsContract(string ContractCode)
        {
            return goodsinvoiceAppService.GetGoodsContract(ContractCode);
        }
    }
}
