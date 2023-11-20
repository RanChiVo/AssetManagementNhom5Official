using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Contractors.Dto
{
    /// <summary>
    /// <model cref="Contractors_9"></model>
    /// </summary>
    public class ContractorInput : Entity<int>
    {
        public string MaHoSoThau { get; set; }
        public string MaDonViThau { get; set; }
        public string TenDonViThau { get; set; }
        public string NgayNopHS { get; set; }
        public string GiaChaoThau { get; set; }
        public string HinhThuocBL { get; set; }
        public string SoChungThuSL { get; set; }
        public string TaiNganHang { get; set; }
        public string FileDinhKem { get; set; }
        public string TrungThau { get; set; }
    }
}
