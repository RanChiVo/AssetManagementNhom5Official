using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;


namespace GWebsite.AbpZeroTemplate.Application.Share.Constructions.Dto
{
    /// <summary>
    /// <model cref="Construction_9"></model>
    /// </summary>
    public class ConstructionFilter : PagedAndSortedInputDto
    {
        public string MaCongTrinh { get; set; }
        public string TenCongTrinh { get; set; }

        public string MaKeHoach { get; set; }
        public string NgayThucThiThucTe { get; set; }
    }
}
