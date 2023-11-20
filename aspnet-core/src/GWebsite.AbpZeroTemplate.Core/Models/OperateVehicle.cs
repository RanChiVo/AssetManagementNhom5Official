using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class OperateVehicle : FullAuditModel
    {
        public string MaVanHanh { get; set; }
        public string NgayVanHanh { get; set; }
        public float SoKm { get; set; }
        public string XangTieuThu { get; set; }
        public string TrangThaiDuyet { get; set; }
        public string GhiChu { get; set; }
      
    }
}
