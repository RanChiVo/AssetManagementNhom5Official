using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchAssetUnitDto
{
    public class SearchAssetUnitInitData
    {
        public string TotalUnitNumber { get; set; }
        public List<ComboboxItemDto> GetAssetRegions { get; set; }
        public List<ComboboxItemDto> GetAssetFathers { get; set; }

        public SearchAssetUnitInitData()
        {
            GetAssetRegions = new List<ComboboxItemDto>();
            GetAssetFathers = new List<ComboboxItemDto>();
        }
    }
    
}
