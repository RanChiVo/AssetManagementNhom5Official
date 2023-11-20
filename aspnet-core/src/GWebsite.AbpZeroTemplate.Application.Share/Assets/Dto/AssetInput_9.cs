using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto
{
    /// <summary>
    /// <model cref="Asset_test9"></model>
    /// </summary>
    public class AssetInput_9 : Entity<int>
    {
        public string MaTaiSan { get; set; }
        public string LoaiTaiSan { get; set; }
    }
}
