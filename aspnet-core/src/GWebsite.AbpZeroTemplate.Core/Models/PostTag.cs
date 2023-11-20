using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class PostTag
    {
        public int PostId { get; set; }
        public string TagId { get; set; }

        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}
