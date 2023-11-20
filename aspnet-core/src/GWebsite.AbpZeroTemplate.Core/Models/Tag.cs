using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class Tag : Entity<string>
    {
        public Tag()
        {
            PostTags = new HashSet<PostTag>();
            ProductTags = new HashSet<ProductTag>();
        }
        public string Name { get; set; }
        public string Type { get; set; }

        public ICollection<PostTag> PostTags { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
