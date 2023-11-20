using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstateRepairs.Dto
{
    /// <summary>
    /// <model cref="RealEstateRepair_9"></model>
    /// </summary>
    public class RealEstateRepairFilter_9 : PagedAndSortedInputDto
    {
        public string MaTaiSan { get; set; }
        public string TenTaiSan { get; set; }
        public string NgayDeXuat { get; set; }
        public string NgaySuaChuaXong { get; set; }
        public string NguoiDeXuat { get; set; }
        public string NhanVienPhuTrach { get; set; }
        public string TrangThaiDuyet { get; set; }

    }
}
