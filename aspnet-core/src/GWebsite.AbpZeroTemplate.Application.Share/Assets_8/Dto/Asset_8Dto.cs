using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Application.Share.Asset_8.Dto
{
    public class Asset_8Dto : Entity<int>
    {

        public string MaTaiSan { set; get; }
        public string MaNhomTaiSan { set; get; }

        public string MaLoaiTaiSan { set; get; }

        public string DiaChi { set; get; }

        public string TenTaiSan { set; get; }

        public string TinhTrangTaiSan { set; get; }

        public float NguyenGiaTaiSan { set; get; }

        public float GiaTinhKhauHao { set; get; }

        public string NgayNhapTaiSan { set; get; }

        public string NgayBatDauKhauHao { set; get; }

        public string NgayKetThucKhauHao { set; get; }

        public string KhauHao { set; get; }

        public string GhiChu { set; get; }

    }
}

