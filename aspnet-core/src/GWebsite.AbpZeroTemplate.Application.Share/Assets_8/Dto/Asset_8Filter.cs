using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Asset_8.Dto
{
    public class Asset_8Filter : PagedAndSortedInputDto
    {
        public string MaTaiSan { set; get; }
        public string MaNhomTaiSan { set; get; }

        public string MaLoaiTaiSan { set; get; }

        public string DiaChi { set; get; }

        public string TenTaiSan { set; get; }
    }
}
