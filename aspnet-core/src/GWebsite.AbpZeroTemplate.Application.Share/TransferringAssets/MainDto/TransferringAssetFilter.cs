using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.MainDto
{
    /// <summary>
    /// <model cref="Customer"></model>
    /// </summary>
    public class TransferringAssetFilter : PagedAndSortedInputDto//Class nay dung de search TA
    {
        public DateTime? TransferringDate { get; set; }
        public string AssetId { get; set; }
        public string AssetName { get; set; }
        public string ReceivingUnit { get; set; }
        public string ReceivingUser { get; set; }
        public bool? IsChecked { get; set; }
    }
}
