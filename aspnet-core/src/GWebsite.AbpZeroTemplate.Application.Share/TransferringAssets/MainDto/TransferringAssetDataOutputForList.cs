using GWebsite.AbpZeroTemplate.Core.Models;
using System;


namespace GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.MainDto
{
    /// <summary>
    /// <model cref="Customer"></model>
    /// </summary>
    public class TransferringAssetDataOutputForList : FullAuditModel
    {
        public DateTime? TransferringDate { get; set; }
        public string AssetId { get; set; }
        public string AssetName { get; set; }
        public string ReceivingUnit { get; set; }
        public string ReceivingUser { get; set; }
        public bool IsChecked { get; set; }
    }
}
