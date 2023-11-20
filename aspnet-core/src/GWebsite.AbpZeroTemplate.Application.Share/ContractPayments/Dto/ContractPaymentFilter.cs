using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractPayments.Dto
{
    /// <summary>
    /// <model cref="ContractPayment"></model>
    /// </summary>
    public class ContractPaymentFilter : PagedAndSortedInputDto
    {
        public string ContractCode { get; set; }
    }
}
