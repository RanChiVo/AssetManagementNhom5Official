using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.GoodsInvoices.Dto
{
    /// <summary>
    /// <model cref="GoodsInvoice"></model>
    /// </summary>
    public class GoodsInvoiceInput : Entity<int>
    {
        public string POCode { get; set; }
        public string PODate { get; set; }
        public string POName { get; set; }
        public string ReportNumber { get; set; }
        public string ReportReceiveDate { get; set; }
        public string ReportConfirmDate { get; set; }
        public string ContractCode { get; set; }
        public string ContractId { get; set; }
        public string TotalPriceContract { get; set; }
        public string TotalPriceContractPayment { get; set; }
        public string ContractContent { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string UnitAddress { get; set; }
        public string PaymentProcess { get; set; }
        public string ShippingProcess { get; set; }
        public string BillStatus { get; set; }
    }
}
