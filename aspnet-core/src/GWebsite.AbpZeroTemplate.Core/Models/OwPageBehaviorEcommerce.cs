using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class OwPageBehaviorEcommerce
    {
        public int PageBehaviorEcommerceId { get; set; }
        public string ProjectId { get; set; }
        public string PagePath { get; set; }
        public string PageView { get; set; }
        public string PageValue { get; set; }
        public string TimeOnPage { get; set; }
        public string ExitRate { get; set; }
        public string Dimensions { get; set; }
        public string Domain { get; set; }
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
