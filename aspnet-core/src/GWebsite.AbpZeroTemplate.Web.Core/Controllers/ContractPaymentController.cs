using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractPayments;
using GWebsite.AbpZeroTemplate.Application.Share.ContractPayments.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ContractPaymentController : GWebsiteControllerBase
    {
        private readonly IContractPaymentAppService contractpaymentAppService;

        public ContractPaymentController(IContractPaymentAppService contractpaymentAppService)
        {
            this.contractpaymentAppService = contractpaymentAppService;
        }

        [HttpGet]
        public PagedResultDto<ContractPaymentDto> GetContractPaymentsByFilter(ContractPaymentFilter contractpaymentFilter)
        {
            return contractpaymentAppService.GetContractPayments(contractpaymentFilter);
        }

        [HttpGet]
        public ContractPaymentInput GetContractPaymentForEdit(int id)
        {
            return contractpaymentAppService.GetContractPaymentForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditContractPayment([FromBody] ContractPaymentInput input)
        {
            contractpaymentAppService.CreateOrEditContractPayment(input);
        }

        [HttpDelete("{id}")]
        public void DeleteContractPayment(int id)
        {
            contractpaymentAppService.DeleteContractPayment(id);
        }

        [HttpGet]
        public ContractPaymentForViewDto GetContractPaymentForView(int id)
        {
            return contractpaymentAppService.GetContractPaymentForView(id);
        }
    }
}
