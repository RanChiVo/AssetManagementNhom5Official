using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.BatDongSan.DTO
{
    public class BatDongSanFilter : PagedAndSortedInputDto
    {
        public string MaBatDongSan { set; get; }

        public string MaLoaiBDS { set; get; }

        public string MaTaiSan { set; get; }

    }
}
