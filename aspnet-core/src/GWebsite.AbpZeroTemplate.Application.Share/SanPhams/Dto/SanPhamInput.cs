using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.SanPhams.Dto
{
    public class SanPhamInput : Entity<int>
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string MaLoaiSanPham { get; set; }
        public string MaNhaCungCap { get; set; }
        public string GiaSanPham { get; set; }
        public string DonViTinh { get; set; }
        public string SoLuong { get; set; }
    }
}
