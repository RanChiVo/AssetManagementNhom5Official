using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchUserDto
{
    public class SearchAssetUserDataOutput:Entity<long>
    {
        public long AssetUnitId { get; set; }
        public long AssetUserId { get; set; }
        public string AssetUserName { get; set; }
    }
}
