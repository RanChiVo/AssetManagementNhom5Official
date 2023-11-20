using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.FixedAssets.Dto
{
    /// <summary>
    /// <model cref="FixedAsset"></model>
    /// </summary>
    public class FixedAssetFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}
