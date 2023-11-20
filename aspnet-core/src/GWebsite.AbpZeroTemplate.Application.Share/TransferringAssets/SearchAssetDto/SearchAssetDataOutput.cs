using Abp.Domain.Entities;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchAssetDto
{
    public class SearchAssetDataOutput : Entity<int>
    {
        public string AssetTypeName { get; set; }
        public string AssetGroupName { get; set; }
        public string AssetId { get; set; }
        public string AssetName { get; set; }
        public DateTime? DateAdded { get; set; }
        public string Supplier { get; set; }
    }
   
}
