using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class Product : Entity<int>
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductImages = new HashSet<ProductImage>();
            ProductQuantities = new HashSet<ProductQuantity>();
            ProductTags = new HashSet<ProductTag>();
        }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int? CategoryId { get; set; }
        public string ThumbnailImage { get; set; }
        public decimal? Price { get; set; }
        public decimal? OriginalPrice { get; set; }
        public decimal? PromotionPrice { get; set; }
        public bool? IncludedVat { get; set; }
        public int? Warranty { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }
        public string Tags { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public bool Status { get; set; }

        public ProductCategory Category { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductQuantity> ProductQuantities { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
