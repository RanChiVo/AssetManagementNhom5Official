using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class ContractGuarantee : FullAuditModel
    {
        public string MaBaoLanhHopDong { get; set; }
        public string HinhThucBLHD { get; set; }
        public string SoChungTuBLHD { get; set; }
        public string NganHangBLHD { get; set; }
        public string SoTienBLHD { get; set; }
        public string SoTienVNDBLHD { get; set; }
        public string NgayHetHanBLHD { get; set; }
        public string DinhKemBLHD { get; set; }
    }
}
