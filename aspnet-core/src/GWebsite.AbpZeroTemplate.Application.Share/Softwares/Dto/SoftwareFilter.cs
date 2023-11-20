using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;


namespace GWebsite.AbpZeroTemplate.Application.Share.Softwares.Dto
{
    public class SoftwareFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}
