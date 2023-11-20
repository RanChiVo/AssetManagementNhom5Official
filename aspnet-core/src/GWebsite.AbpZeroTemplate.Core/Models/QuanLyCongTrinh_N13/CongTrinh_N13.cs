using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models.QuanLyCongTrinh_N13
{
    public class CongTrinh_N13 : FullAuditModel
    {
        public string MaDuAnXayDungCoBan { set; get; }
        public string MaCongTrinh { set; get; }
        public string MaKeHoach { set; get; }

        public string TenCongTrinh { set; get; }

        public string DuKienXayDung { set; get; }

        public string DuKienHoanThanh { set; get; }

        public float KinhPhiDeXuat { set; get; }

        public float KinhPhiTrinh { set; get; }

        public float KinhPhiDuocDuyet { set; get; }

        public string TienDoThucHien { set; get; }

        public float ChiPhiDaSuDung { set; get; }

        public string MaLoaiCongTrinh { set; get; }

        public string DiaChiCongTrinh { set; get; }

        public float DienTichCongTrinh { set; get; }

        public string MoTaCongTrinh { set; get; }

        public string NgayThiCongThucTe { set; get; }

        public string GhiChu { set; get; }
    }
}
