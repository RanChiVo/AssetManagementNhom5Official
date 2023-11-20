using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Insurrances.Dto
{
    /// <summary>
    /// <model cref="Insurrance"></model>
    /// </summary>
    public class InsurranceFilter : PagedAndSortedInputDto
    {
        public string Company { get; set; }
    }
}
