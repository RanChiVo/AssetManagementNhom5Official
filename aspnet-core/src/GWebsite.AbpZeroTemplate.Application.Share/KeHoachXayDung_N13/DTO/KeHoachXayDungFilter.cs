using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.KeHoachXayDung_N13.DTO
{
    public class KeHoachXayDungFilter : PagedAndSortedInputDto
    {
        public string MaKeHoach { set; get; }
        public string TenKeHoach { set; get; }
        public string MaDonVi { set; get; }
        public string TrangThaiDuyet { set; get; }
        public string NamThucHien { set; get; }
    }
}
