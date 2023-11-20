using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.BidManagers.Dto
{
    /// <summary>
    /// <model cref="BidManager_9"></model>
    /// </summary>
    public class BidManagerDto : Entity<int>
    {
        public string MaHoSoThau { get; set; }
        public string HangMucThau { get; set; }
        public string NgayNhanHSThau { get; set; }
        public string NgayHetHanNopHSThau { get; set; }
        public string NgayMoThau { get; set; }
        public string HinhThucThau { get; set; }
        public string BaoLanhDuThau { get; set; }
        public string PhanTram { get; set; }
        public string NgayHetHanBaoLanh { get; set; }
        public string FileDinhKem { get; set; }
        public string MaCongTrinh { get; set; }
        public string MaDonViThau { get; set; }
    }
}
