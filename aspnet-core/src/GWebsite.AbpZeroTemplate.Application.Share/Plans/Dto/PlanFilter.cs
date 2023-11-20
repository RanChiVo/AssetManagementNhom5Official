using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;


namespace GWebsite.AbpZeroTemplate.Application.Share.Plans.Dto
{
    /// <summary>
    /// <model cref="Plan_9"></model>
    /// </summary>
    public class PlanFilter : PagedAndSortedInputDto
    {
        public string MaKeHoach { get; set; }
        public string TenKeHoach { get; set; }
        public string MaDonVi { get; set; }
        public string NgayLapKeHoach { get; set; }
    }
}
