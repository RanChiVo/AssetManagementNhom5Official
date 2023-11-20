using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.SuaChuaBatDongSan.DTO
{
    public class SuaChuaBatDongSanDto : Entity<int>
    {
       
        public string MaTaiSan { set; get; }

        public string TenTaiSan { set; get; }
        public string NgayDeXuat { set; get; }

        public string NgayDuKienSuaXong { set; get; }

        public float ChiPhiDuKien { set; get; }

        public string DonViSuaChua { set; get; }

        public string DonViDeXuat { set; get; }

        public string NguoiDeXuat { set; get; }

        public string NhanVienPhuTrach { set; get; }

        public string NoiDungSuaChua { set; get; }

        public string GhiChu { set; get; }

        public string NgaySuaXong { set; get; }

        public string DonViSuaChuaThucTe { set; get; }

        public string ChiPhiSuaChuaThucTe { set; get; }

        public string NoiDungSuaChuaThucTe { set; get; }

        public string GhiChuThucTe { set; get; }

        public bool ThayDoiCongNang { set; get; }

        public string TrangThaiSuaChua { set; get; }

    }
}
