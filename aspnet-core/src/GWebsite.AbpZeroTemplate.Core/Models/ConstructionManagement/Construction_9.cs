using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Construction_9 : FullAuditModel
    {
        public string MaCongTrinh { get; set; }
        public string TenCongTrinh { get; set; }
        public string MaLoaiCongTrinh { get; set; }
        public string MaKeHoach { get; set; }
        public string DiaChiCongTrinh { get; set; }
        public string DienTichCongTrinh { get; set; }

        public int ChiPhiDuocDuyet { get; set; }
        public int ChiPhiDeXuat { get; set; }
        public int ChiPhiTrinh { get; set; }
        public int NamThucHien { get; set; }

        public string NgayDuKienThucHien { get; set; }
        public string ThoiGianDuKienHT { get; set; }
        public string MoTaCongTrinh { get; set; }

        public string ChiPhiDaThucHien { get; set; }
        public string NgayThucThiThucTe { get; set; }
        public string NgayHoanThanh { get; set; }
        public string TienDo { get; set; }

        public string TrangThaiDuyet { get; set; }
        public string DonViLapKeHoach { get; set; }
    }
}
