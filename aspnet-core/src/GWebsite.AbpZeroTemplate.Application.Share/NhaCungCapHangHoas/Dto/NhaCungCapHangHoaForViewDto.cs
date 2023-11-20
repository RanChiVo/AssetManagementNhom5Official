using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.NhaCungCapHangHoas.Dto
{
    public class NhaCungCapHangHoaForViewDto
    {
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string MaLoaiNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string NguoiLienHe { get; set; }
        public bool HoatDong { get; set; }
        public string GhiChu { get; set; }
    }
}
