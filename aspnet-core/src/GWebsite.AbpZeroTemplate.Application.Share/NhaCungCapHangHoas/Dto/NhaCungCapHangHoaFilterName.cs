using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
namespace GWebsite.AbpZeroTemplate.Application.Share.NhaCungCapHangHoas.Dto
{
    public class NhaCungCapHangHoaFilterName : PagedAndSortedInputDto
    {
        public string MaLoaiNhaCungCap  { get; set; }
    }
}
