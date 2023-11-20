using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.TaiSan_13.Dto
{
   public class TaiSanFilter : PagedAndSortedInputDto
    {
        public string MaTaiSan { set; get; }
        public string MaNhomTaiSan { set; get; }

        public string MaLoaiTaiSan { set; get; }

        public string TenTaiSan { set; get; }

        
    }
}
