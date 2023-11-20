using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;


namespace GWebsite.AbpZeroTemplate.Application.Share.BidManagers.Dto
{
    /// <summary>
    /// <model cref="BidManager_9"></model>
    /// </summary>
    public class BidManagerFilter : PagedAndSortedInputDto
    {
        public string MaHoSoThau { get; set; }
        public string HangMucThau { get; set; }
        public string NgayNhanHSThau { get; set; }
        public string NgayHetHanNopHSThau { get; set; }
        public string HinhThucThau { get; set; }
        public string MaCongTrinh { get; set; }
    }
}
