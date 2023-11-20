using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class Page : Entity<int>
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public bool Status { get; set; }
    }
}
