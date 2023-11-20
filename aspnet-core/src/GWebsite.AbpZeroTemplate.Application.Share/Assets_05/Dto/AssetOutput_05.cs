using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes_05.Dto;
using GWebsite.AbpZeroTemplate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Dto
{
    public class AssetOutput_05
    {
        public AssetDto_05 Asset { get; set; }
        public AssetGroupDto_05 AssetGroup { get; set; }
        public List<ComboboxItemDto> PurchaseOders { get; set; }
        public List<ComboboxItemDto> AssetGroups { get; set; }
        public List<ComboboxItemDto> AssetTypes { get; set; }

        public AssetOutput_05()
        {
            AssetGroups = new List<ComboboxItemDto>();
            AssetTypes = new List<ComboboxItemDto>();
            PurchaseOders = new List<ComboboxItemDto>();
        }
    }
}
