using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto
{
    /// <summary>
    /// <model cref="AssetGroup_05"></model>
    /// </summary>
    public class AssetGroupDto_05 : Entity<int>
    {
        public string AssetGroupId { get; set; }
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
