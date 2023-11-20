using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Application.Share.ProductTypes.Dto
{
    public class ProductTypeDto : Entity<int>
    {
        public string MaLoaiSanPham { get; set; }
        public string TenLoaiSanPham { get; set; }
    }
}
