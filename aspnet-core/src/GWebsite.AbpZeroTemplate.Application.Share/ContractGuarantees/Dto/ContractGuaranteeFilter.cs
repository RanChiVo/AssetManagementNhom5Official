using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;


namespace GWebsite.AbpZeroTemplate.Application.Share.ContractGuarantees.Dto
{
    /// <summary>
    /// <model cref="ContractGuarantee"></model>
    /// </summary>
    public class ContractGuaranteeFilter : PagedAndSortedInputDto
    {
        public string MaBaoLanhHopDong { get; set; }
    }
}
