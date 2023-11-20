using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
namespace GWebsite.AbpZeroTemplate.Application.Share.NhaCungCapHangHoas.Dto
{
    public class NhaCungCapHangHoaFilter : PagedAndSortedInputDto
    {
        public string MaNhaCungCap { get; set; }
    }
}
