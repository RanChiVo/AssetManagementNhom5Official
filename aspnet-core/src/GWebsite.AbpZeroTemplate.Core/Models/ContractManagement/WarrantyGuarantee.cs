using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class WarrantyGuarantee : FullAuditModel
    {
        public string MaBaoLanhBaoHanh { get; set; }
        public string HinhThucBLBH { get; set; }
        public string SoChungTuBLBH { get; set; }
        public string NganHangBLBH { get; set; }
        public string SoTienBLBH { get; set; }
        public string SoTienVNDBLBH { get; set; }
        public string NgayHetHanBLBH { get; set; }
        public string DinhKemBLBH { get; set; }
    }
}
