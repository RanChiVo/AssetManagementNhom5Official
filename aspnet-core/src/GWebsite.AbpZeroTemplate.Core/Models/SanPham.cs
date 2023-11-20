using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class SanPham : FullAuditModel
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
