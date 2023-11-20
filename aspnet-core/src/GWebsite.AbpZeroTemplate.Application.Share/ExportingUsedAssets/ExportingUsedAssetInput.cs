using System;
using System.Text;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.ExportingUsedAssets
{
    /// <summary>
    /// <model cref="ExportingUsedAsset"></model>
    /// </summary>
    public class ExportingUsedAssetInput : Entity<int>
    {
        public DateTime ExportingDay { get; set; } = DateTime.Now;
        public string AssetId { get; set; }
        public DateTime BeginningDateofDepreciation { get; set; }
        public string UsingUnit { get; set; }
        public string User { get; set; }
        public string Note { get; set; }
    }
}