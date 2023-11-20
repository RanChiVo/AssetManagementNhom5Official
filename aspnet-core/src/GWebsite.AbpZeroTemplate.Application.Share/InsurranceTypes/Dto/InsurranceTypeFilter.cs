using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.InsurranceTypes.Dto
{
    /// <summary>
    /// <model cref="InsurranceType"></model>
    /// </summary>
    public class InsurranceTypeFilter : PagedAndSortedInputDto
    {
        public string InsurranceTypeName { get; set; }
    }
}
