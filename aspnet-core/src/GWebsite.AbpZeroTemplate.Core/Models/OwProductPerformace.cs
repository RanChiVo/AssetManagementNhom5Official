using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class OwProductPerformace
    {
        public int OverviewEcommerceId { get; set; }
        public string ProjectId { get; set; }
        public string ProductName { get; set; }
        public string ItemRevenue { get; set; }
        public string ProductDetailViews { get; set; }
        public string QuantityAddedToCart { get; set; }
        public string QuantityCheckedOut { get; set; }
        public string Dimensions { get; set; }
        public string Domain { get; set; }
        public string Version { get; set; }
        public int VersionInt { get; set; }
        public string RecordStatus { get; set; }
        public string AuthStatus { get; set; }
        public string MakerId { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CheckerId { get; set; }
        public DateTime? ApproveDt { get; set; }
        public string EditorId { get; set; }
        public DateTime? EditDt { get; set; }
    }
}
