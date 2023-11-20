using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiTaiSan.DTO
{
    public class LoaiTaiSanFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}

