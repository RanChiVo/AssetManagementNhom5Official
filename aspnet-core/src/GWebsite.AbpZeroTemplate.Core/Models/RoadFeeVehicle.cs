using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class RoadFeeVehicle : FullAuditModel
    {
        public string MaPhiDuongBo { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public string LoaiPhi { get; set; }
        public string SoTien { get; set; }
        public string DonViThuPhi { get; set; }
        public string TrangThaiDuyet { get; set; }
        public string GhiChu { get; set; }

    }
}
