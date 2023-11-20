using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;


namespace GWebsite.AbpZeroTemplate.Application.Share.WarrantyGuarantees.Dto
{
    /// <summary>
    /// <model cref="WarrantyGuarantee"></model>
    /// </summary>
    public class WarrantyGuaranteeFilter : PagedAndSortedInputDto
    {
        public string MaBaoLanhBaoHanh { get; set; }

    }
}
