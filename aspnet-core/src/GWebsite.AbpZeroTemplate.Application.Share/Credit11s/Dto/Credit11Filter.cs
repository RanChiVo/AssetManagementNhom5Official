using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Credit11s.Dto
{
    /// <summary>
    /// <model cref="Credit"></model>
    /// </summary>
    public class Credit11Filter : PagedAndSortedInputDto
    {
        public string AssetId { get; set; }
    }
}
