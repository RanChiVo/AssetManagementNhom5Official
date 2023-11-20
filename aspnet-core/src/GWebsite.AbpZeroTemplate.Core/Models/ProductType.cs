using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class ProductType : FullAuditModel
    {
        public string MaLoaiSanPham { get; set; }
        public string TenLoaiSanPham { get; set; }

    }
}
