using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto
{
    /// <summary>
    /// <model cref="Contract"></model>
    /// </summary>
    public class ContractForViewDto
    {
        public string ContractCode { get; set; }
        public string BidCode { get; set; }
        public string ContractName { get; set; }
        public string SupplierName { get; set; }
        public string ContractDayCreate { get; set; }
        public string ApprovalStatus { get; set; }
        public string UnitAcceptedCode { get; set; }
        public string GoodsName { get; set; }

        public string Content { get; set; }
        public string TotalPrice { get; set; }
        public string TotalPricePay { get; set; }

        public string ContractForm { get; set; }
        public string GuaranteeForm { get; set; }
        public string ContractConfirmNumber { get; set; }
        public string GuaranteeConfirmNumber { get; set; }
        public string ContractBank { get; set; }
        public string GuaranteeBank { get; set; }
        public string ContractRatio { get; set; }
        public string ContractPrice { get; set; }
        public string GuaranteeRatio { get; set; }
        public string GuaranteePrice { get; set; }
        public string ContractExpire { get; set; }
        public string GuaranteeExpire { get; set; }
    }
}
