using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.SuaChuaBatDongSan.DTO
{
    public class SuaChuaBatDongSanFilter : PagedAndSortedInputDto
    {
        public string MaTaiSan { set; get; }

        public string NgayDeXuat { set; get; }
        public string NgaySuaXong { set; get; }


    }
}
