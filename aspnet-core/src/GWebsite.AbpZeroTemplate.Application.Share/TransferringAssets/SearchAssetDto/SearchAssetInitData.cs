using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchAssetDto
{
    public class SearchAssetInitData
    {
        public List<ComboboxItemDto> GetAssetTypes { get; set; }
        public List<ComboboxItemDto> GetAssetGroups { get; set; }
        public List<ComboboxItemDto> GetAssetSuppliers { get; set; }

     
        public SearchAssetInitData()
        {
            GetAssetTypes = new List<ComboboxItemDto>();
            GetAssetGroups = new List<ComboboxItemDto>();
            GetAssetSuppliers = new List<ComboboxItemDto>();
        }
    }
}
