using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class DisposalPlan: FullAuditModel
    {
        public string MaKeHoach { get; set; }
        public string KhuVuc { get; set; }
        public string PhongBan { get; set; }
        public int Nam { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public string KinhPhi { get; set; }
        public string TinhTrang { get; set; }
        public int SoLanThayDoi { get; set; }
    }
}
