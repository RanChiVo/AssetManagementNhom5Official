using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchAssetUnitDto
{
    public class SearchAssetUnitFilter: PagedAndSortedInputDto
    {
        public string AssetUnitFatherName { get; set; }
        public string AssetUnitName { get; set; }
    }
}
