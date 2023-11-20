using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class Slide : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public int? DisplayOrder { get; set; }
        public bool Status { get; set; }
        public string Content { get; set; }
    }
}
