using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class ContractManagement : FullAuditModel
    {
        public string MaHopDong { get; set; }
        public string SoHopDong { get; set; }
        public string NoiDungHopDong { get; set; }
        public string TongGiaTriHopDong { get; set; }
        public string TienDongThiCong { get; set; }
        public string MaHoSoThau { get; set; }
        public string MaCongTrinh { get; set; }
        public string MaToTrinh { get; set; }
        public string MaBaoLanhHopDong { get; set; }
        public string MaBaoLanhBaoHanh { get; set; }

        public string TongTienDaThanhToan { get; set; }

    }
}
