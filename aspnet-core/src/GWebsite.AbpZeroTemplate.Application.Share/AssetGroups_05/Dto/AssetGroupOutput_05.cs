using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes_05.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto
{
    /// <summary>
    /// <model cref="AssetGroup_05"></model>
    /// </summary>
    public class AssetGroupOutput_05
    {
        public AssetGroupDto_05 AssetGroup { get; set; }
        public AssetTypeDto_05 AssetType { get; set; }
        public List<ComboboxItemDto> AssetGroups { get; set; }
        public List<ComboboxItemDto> AssetTypes { get; set; }

        public AssetGroupOutput_05()
        {
            AssetGroups = new List<ComboboxItemDto>();
            AssetTypes = new List<ComboboxItemDto>();
        }
    }
}
