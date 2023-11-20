using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractPayments.Dto
{
    /// <summary>
    /// <model cref="ContractPayment"></model>
    /// </summary>
    public class ContractPaymentDto : Entity<int>
    {
        public string ContractPaymentCode { get; set; }
        public string TimePayment { get; set; }
        public string PaymentDate { get; set; }
        public string Ratio { get; set; }
        public string Money { get; set; }
        public string Content { get; set; }
        public string ContractCode { get; set; }
        public Boolean Disable { get; set; }

        public ContractPaymentDto()
        {
            this.Disable = false;
        }
    }
}
