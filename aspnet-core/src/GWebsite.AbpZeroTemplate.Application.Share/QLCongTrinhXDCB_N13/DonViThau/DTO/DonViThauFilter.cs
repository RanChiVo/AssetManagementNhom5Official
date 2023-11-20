using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau.DTO
{
    public class DonViThauFilter : PagedAndSortedInputDto
    {
        public string MaDonViThau { set; get; }
        public string MaGoiThau { set; get; }
    }
}
