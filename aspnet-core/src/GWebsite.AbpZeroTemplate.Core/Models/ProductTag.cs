using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class ProductTag
    {
        public int ProductId { get; set; }
        public string TagId { get; set; }

        public Product Product { get; set; }
        public Tag Tag { get; set; }
    }
}
