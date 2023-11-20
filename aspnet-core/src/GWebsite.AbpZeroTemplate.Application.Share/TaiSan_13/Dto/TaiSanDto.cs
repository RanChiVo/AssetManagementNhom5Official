using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.TaiSan_13.Dto
{
   public class TaiSanDto:Entity<int>
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
