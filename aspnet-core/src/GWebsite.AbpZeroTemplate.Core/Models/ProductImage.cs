using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class ProductImage : Entity<int>
    {
        public int ProductId { get; set; }
        public string Path { get; set; }
        public string Caption { get; set; }

        public Product Product { get; set; }
    }
}
