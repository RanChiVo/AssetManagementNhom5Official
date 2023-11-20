using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;


namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstates.Dto
{
    /// <summary>
    /// <model cref="RealEstate_9"></model>
    /// </summary>
    public class RealEstateFilter_9 : PagedAndSortedInputDto
    {
        public string MaTaiSan { get; set; }
        public string MaBatDongSan { get; set; }
        public string MaLoaiBatDongSan { get; set; }
        public string TinhTrangSuDung { get; set; }
    }
}
