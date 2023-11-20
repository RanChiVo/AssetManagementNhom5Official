using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Asset_05 : FullAuditModel
    {
        public string AssetId { get; set; }
        public string Name { get; set; }//Tên
        public int TotalMonthDepreciation { get; set; }//Số tháng khấu hao
        public float DepreciationValue { get; set; }//giá trị khấu hao
        public float DepreciationRate { get; set; }//Tỉ lệ khấu hao
        public int RemainingDepMonths { get; set; }//Số tháng khấu hao còn lại
        public string DepreciationStatus { get; set; }//Tình trạng khấu hao
        public float RemainingDepValue { get; set; }//Giá trị khấu hao còn lại
        public string Description { get; set; }//Mô tả
        public DateTime? DateAdded { get; set; }//Ngày nhận
        public int  Quantity { get; set; }//số lượng
        public float OriginalPrice { get; set; }//giá gốc
        public string Note { get; set; }//ghi chú
        public bool IsActive { get; set; }//đang hoạt động
        public string PurchaseOderId { get; set; }
        public string AssetGroupId { get; set; }
        public string WarrantyId { get; set; }
        public string LinkofImage { get; set; }
        public int AssetTypeId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Categocy { get; set; }
        public string PurchaseFrom { get; set; }
    }
}
