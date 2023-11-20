using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Dto
{
    /// <summary>
    /// <model cref="Asset_05"></model>
    /// </summary>
    public class AssetFilter_05 : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}
