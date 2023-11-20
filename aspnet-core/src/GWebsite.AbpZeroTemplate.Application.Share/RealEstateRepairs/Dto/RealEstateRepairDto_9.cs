using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstateRepairs.Dto
{
    /// <summary>
    /// <model cref="RealEstateRepair_9"></model>
    /// </summary>
    public class RealEstateRepairDto_9 : Entity<int>
    {
        public string MaTaiSan { get; set; }
        public string TenTaiSan { get; set; }
        public string NgayDeXuat { get; set; }
        public string DonViSuaChua { get; set; }
        public string NgayDuKienSuaXong { get; set; }
        public string DonViDeXuat { get; set; }
        public string ChiPhiDuKien { get; set; }
        public string NguoiDeXuat { get; set; }
        public string NhanVienPhuTrach { get; set; }
        public string NoiDungSuaChua { get; set; }
        public string GhiChu { get; set; }

        public string TrangThaiDuyet { get; set; }

        public string NgaySuaChuaXong { get; set; }
        public string DonViSuaChuaThucTe { get; set; }
        public string ChiPhiSuaChuaThucTe { get; set; }
        public string NoiDungSuaChuaThucTe { get; set; }
        public string GhiChuThucTe { get; set; }
    }
}
