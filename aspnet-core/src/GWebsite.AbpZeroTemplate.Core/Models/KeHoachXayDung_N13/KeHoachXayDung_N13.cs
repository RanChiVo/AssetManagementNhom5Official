using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models.KeHoachXayDung_N13
{
    public class KeHoachXayDung_N13 : FullAuditModel
    {
        public string MaKeHoach { set; get; }
        public string TenKeHoach { set; get; }
        public string MaDonVi { set; get; }
        public string NgayLapKeHoach { set; get; }
        public string TrangThaiDuyet { set; get; }
        public string NgayHieuLuc { set; get; }

        public string NamThucHien { set; get; }

        public string KinhPhiDuocDuyet { set; get; }

    }
}
