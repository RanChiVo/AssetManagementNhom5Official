using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstateTypes.Dto
{
    /// <summary>
    /// <model cref="RealEstateType_9"></model>
    /// </summary>
    public class RealEstateTypeInput_9 : Entity<int>
    {
        public string MaLoaiBatDongSan { get; set; }
        public string TenLoaiBatDongSan { get; set; }
    }
}
