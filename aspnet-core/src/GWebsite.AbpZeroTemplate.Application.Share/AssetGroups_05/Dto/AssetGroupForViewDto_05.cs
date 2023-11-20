using System;
using System.ComponentModel.DataAnnotations;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto
{
    public class AssetGroupForViewDto_05
    {
        [Key]
        public string Id { get; set; }
        public string SelectedId { get; set; }
        public string Name { get; set; }
        public int AssetTypeId { get; set; }
        public int Level { get; set; }
        public string FatherAssetGroup { get; set; }
        public int MonthsDepreciation { get; set; }
        public float DepreciationRates { get; set; }
        public string AssetAccount { get; set; }
        public string DepreciationAccount { get; set; }
        public string CostAccount { get; set; }
        public string IncomeAccount { get; set; }
        public string LiquidationCostAccount { get; set; }
    }
}
