using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.MainDto
{
    /// <summary>
    /// <model cref="Customer"></model>
    /// </summary>
    public class TransferringAssetDataOutputDetail : FullAuditModel //Class nay dung de hien thi thong tin chi tiet cua TS de edit hoac view
    {
        public DateTime? TransferringDate { get; set; }
        public string AssetId { get; set; }
        public string AssetName { get; set; }
        public string AssetGroupName { get; set; }//Join table AssetGroup
        public string AssetTypeName { get; set; }//Join table AssetType
        public string Description { get; set; }//Mô tả


        public DateTime? ExportingDay { get; set; }//Join table ExportingUsedAsset
        public DateTime? ExportingDayEnd { get; set; }
        public int TotalMonthDepreciation { get; set; }//Số tháng khấu hao
        public float OriginalPrice { get; set; }//giá gốc
        public float DepreciationValue { get; set; }//giá trị khấu hao
        public float RemainingDepValue { get; set; }//Giá trị khấu hao còn lại
        public bool IsActive { get; set; }//đang hoạt động
        public string DepreciationStatus { get; set; }//Tình trạng khấu hao
        public string UsingUnit { get; set; }
        public string UsingUser { get; set; }
        public string ReceivingUnit { get; set; }
        public string ReceivingUser { get; set; }
        public bool IsChecked { get; set; }
        public string Note { get; set; }
    }
}
