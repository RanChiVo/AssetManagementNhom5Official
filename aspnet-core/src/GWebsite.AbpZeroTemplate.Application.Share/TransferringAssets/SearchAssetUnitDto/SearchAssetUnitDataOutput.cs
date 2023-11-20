using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchAssetUnitDto
{
    public class SearchAssetUnitDataOutput : Entity<long>
    {
        public string AssetFatherName { get; set; }
        public long AssetUnitID { get; set; }
        public string AssetUnitName { get; set; }
    }
}
