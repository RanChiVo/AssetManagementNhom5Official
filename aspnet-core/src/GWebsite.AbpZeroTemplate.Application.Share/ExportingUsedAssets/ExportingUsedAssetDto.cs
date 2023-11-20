using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.ExportingUsedAssets
{
    /// <summary>
    /// <model cref="ExportingUsedAsset"></model>
    /// </summary>
    public class ExportingUsedAssetDto : Entity<int>
    {
        public DateTime ExportingDay { get; set; }
        public string AssetId { get; set; }
        public DateTime BeginningDateofDepreciation { get; set; }
        public string UsingUnit { get; set; }
        public string User { get; set; }
        public string Note { get; set; }
    }
}
