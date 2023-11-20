using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps.Dto
{
    public class LoaiNhaCungCapFilter : PagedAndSortedInputDto
    {
        public string MaLoaiNhaCungCap { get; set; }
    }
}
