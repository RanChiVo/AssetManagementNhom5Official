using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.CongTrinh_N13.DTO
{
    public class CongTrinhFilter : PagedAndSortedInputDto
    {
        public string MaCongTrinh { set; get; }
        public string MaKeHoach { set; get; }

        public string TenCongTrinh { set; get; }
    }
}
