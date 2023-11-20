using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    
    public class NhaCungCapHangHoa : FullAuditModel
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
        public NhaCungCapHangHoa() { }
        public NhaCungCapHangHoa(string maNhaCungCap, string tenNhaCungCap, string maLoaiNhaCungCap, string diaChi, string email
            , string soDienThoai, string nguoiLienHe, bool hoatDong, string ghiChu)
        {
            this.MaLoaiNhaCungCap = maNhaCungCap;
            this.TenNhaCungCap = tenNhaCungCap;
            this.MaLoaiNhaCungCap = maLoaiNhaCungCap;
            this.DiaChi = diaChi;
            this.Email = email;
            this.SoDienThoai = soDienThoai;
            this.NguoiLienHe = nguoiLienHe;
            this.HoatDong = hoatDong;
            this.GhiChu = ghiChu;
        }
    }
}
