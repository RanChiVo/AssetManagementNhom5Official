using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class OwOverviewEcommerce
    {
        public int OverviewEcommerceId { get; set; }
        public string ProjectId { get; set; }
        public string Sessions { get; set; }
        public string Pageviews { get; set; }
        public string Timeonpage { get; set; }
        public string Transactionrevenue { get; set; }
        public string Productdetailviews { get; set; }
        public string Productaddstocart { get; set; }
        public string Productcheckouts { get; set; }
        public string Users { get; set; }
        public string NewsUsers { get; set; }
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
