using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;


namespace GWebsite.AbpZeroTemplate.Application.Share.Contractors.Dto
{
    /// <summary>
    /// <model cref="Contractors_9"></model>
    /// </summary>
    public class ContractorFilter : PagedAndSortedInputDto
    {
        public string MaDonViThau { get; set; }
        public string TenDonViThau { get; set; }
    }
}
