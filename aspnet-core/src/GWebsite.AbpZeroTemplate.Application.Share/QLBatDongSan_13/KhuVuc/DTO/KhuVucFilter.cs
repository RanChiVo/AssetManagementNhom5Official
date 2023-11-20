using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.KhuVuc.DTO
{
    public class KhuVucFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}
