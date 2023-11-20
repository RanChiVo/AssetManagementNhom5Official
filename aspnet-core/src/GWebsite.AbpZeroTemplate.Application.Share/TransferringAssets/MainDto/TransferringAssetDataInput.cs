using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;


namespace GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.MainDto
{
    /// <summary>
    /// <model cref="Customer"></model>
    /// </summary>
    public class TransferringAssetDataInput : FullAuditModel
    {
        public DateTime? TransferringDate { get; set; }
        public string AssetId { get; set; }
        public bool IsChecked { get; set; }
        public long UsingUnit { get; set; }
        public long UsingUser { get; set; }
        public long ReceivingUnit { get; set; }
        public long ReceivingUser { get; set; }
        public string Note { get; set; }
        public string AttachingFileName { get; set; }

    }
}
