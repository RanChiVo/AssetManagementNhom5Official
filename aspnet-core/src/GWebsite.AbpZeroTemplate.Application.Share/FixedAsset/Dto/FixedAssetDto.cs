        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.FixedAssets.Dto
{
    /// <summary>
    /// <model cref="FixedAsset"></model>
    /// </summary>
    public class FixedAssetDto : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeofAsset { get; set; }
        public float OperatingCosts { get; set; }
        public float DepreciationValue { get; set; }
        public int Quantity { get; set; }
        public int FixedAssetTag { get; set; }
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
