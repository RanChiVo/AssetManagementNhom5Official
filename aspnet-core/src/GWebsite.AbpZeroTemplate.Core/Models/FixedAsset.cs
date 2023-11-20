﻿using System;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class FixedAsset : FullAuditModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeofAsset { get; set; }
        public float OperatingCosts { get; set; }
        public float DepreciationValue { get; set; }
        public int Quantity { get; set; }
        public int AssetTag { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchaseFrom { get; set; }
        public float Cost { get; set; }
        public bool isActive { get; set; }
        public string Categocy { get; set; }
        public string Location { get; set; }
        public string PONumber { get; set; }
        public string LinkofImage { get; set; }
    }
}
