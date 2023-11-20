using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;


namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstateTypes.Dto
{
    /// <summary>
    /// <model cref="RealEstateType_9"></model>
    /// </summary>
    public class RealEstateTypeFilter_9 : PagedAndSortedInputDto
    {
        public string MaLoaiBatDongSan { get; set; }
        public string TenLoaiBatDongSan { get; set; }
    }
}
