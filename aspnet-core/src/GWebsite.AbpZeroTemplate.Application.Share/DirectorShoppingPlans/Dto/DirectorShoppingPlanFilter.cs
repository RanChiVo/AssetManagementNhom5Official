using System;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.DirectorShoppingPlans.Dto
{
    public class DirectorShoppingPlanFilter:PagedAndSortedInputDto
    {
        public string KhuVuc { get; set; }
        public string PhongBan { get; set; }
    }
}
