using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class LiquidationDetail_05 :Entity<int>
    {
        public float RemainingDepreciationValue { get; set; }
        public float LiquidationPrice { get; set; }
        public string FormLiquidation { get; set; }
        public string Note { get; set; }
    }
}
