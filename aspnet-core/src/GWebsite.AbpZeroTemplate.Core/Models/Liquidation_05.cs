using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Liquidation_05 : FullAuditModel
    {
        public string AssetId { get; set; }
        public DateTime LiquidationDate { get; set; }
        public float RemainingDepreciationValue { get; set; }
        public float LiquidationPrice { get; set; }
        public string FormLiquidation { get; set; }
        public string Note { get; set; }
    }
}
