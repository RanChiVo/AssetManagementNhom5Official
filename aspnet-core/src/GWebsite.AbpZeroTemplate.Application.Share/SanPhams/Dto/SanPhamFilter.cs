using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.SanPhams.Dto
{
    public class SanPhamFilter : PagedAndSortedInputDto
    {
        public string MaSanPham { get; set; }
    }
}
