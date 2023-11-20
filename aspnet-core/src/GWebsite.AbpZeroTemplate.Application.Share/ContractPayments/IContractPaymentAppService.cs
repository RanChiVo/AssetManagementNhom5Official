using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractPayments.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractPayments
{
    public interface IContractPaymentAppService
    {
        void CreateOrEditContractPayment(ContractPaymentInput contractpaymentInput);
        ContractPaymentInput GetContractPaymentForEdit(int id);
        void DeleteContractPayment(int id);
        PagedResultDto<ContractPaymentDto> GetContractPayments(ContractPaymentFilter input);
        ContractPaymentForViewDto GetContractPaymentForView(int id);
    }
}
