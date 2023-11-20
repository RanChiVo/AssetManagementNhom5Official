using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchUserDto
{
    public class SearchAssetUserFilter : PagedAndSortedInputDto
    {
        public long? AssetUnitId { get; set; }
        public long? AssetUserId { get; set; }
        public string AssetUserName { get; set; }
    }
   
}
