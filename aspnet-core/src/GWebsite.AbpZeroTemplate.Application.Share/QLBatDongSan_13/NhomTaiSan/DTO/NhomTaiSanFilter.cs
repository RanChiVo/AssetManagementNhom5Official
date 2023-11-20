using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.NhomTaiSan.DTO
{
    public class NhomTaiSanFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}

