using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Debit11s.Dto
{
    /// <summary>
    /// <model cref="Debit"></model>
    /// </summary>
    public class Debit11Filter : PagedAndSortedInputDto
    {
        public string AssetId { get; set; }
    }
}
