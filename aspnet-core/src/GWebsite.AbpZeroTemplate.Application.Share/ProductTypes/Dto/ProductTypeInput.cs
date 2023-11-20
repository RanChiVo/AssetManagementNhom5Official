using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ProductTypes.Dto
{
    public class ProductTypeInput : Entity<int>
    {
        public string MaLoaiSanPham { get; set; }
        public string TenLoaiSanPham { get; set; }
    }
}
