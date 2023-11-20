using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;


namespace GWebsite.AbpZeroTemplate.Application.Share.ExportingUsedAssets
{
    /// <summary>
    /// <model cref="ExportingUsedAsset"></model>
    /// </summary>
    public class ExportingUsedAssetFilter : PagedAndSortedInputDto
    {
        public string AssetId { get; set; }
        public string UsingUnit { get; set; }

        public string ExportingDay { get; set; }
        public string User { get; set; }

    }
}
