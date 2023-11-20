using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ProductTypes.Dto
{
    public class ProductTypeFilter : PagedAndSortedInputDto
    {
        public string MaLoaiSanPham { get; set; }
    }
}
