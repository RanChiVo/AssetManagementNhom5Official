using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GWebsite.AbpZeroTemplate.Application.Share.ContractPayments.Dto
{
    public class ContractPaymentOutput
    {
        public ContractPaymentDto ContractPayment { get; set; }
        public List<ComboboxItemDto> ContractPayments { get; set; }

        public ContractPaymentOutput()
        {
            ContractPayments = new List<ComboboxItemDto>();
        }
    }
}
