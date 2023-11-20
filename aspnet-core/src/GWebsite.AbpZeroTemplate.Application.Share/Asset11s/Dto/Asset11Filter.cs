using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Asset11s.Dto
{
    /// <summary>
    /// <model cref="Asset11"></model>
    /// </summary>
    public class Asset11Filter : PagedAndSortedInputDto
    {
        public string AssetId { get; set; }
    }
}
