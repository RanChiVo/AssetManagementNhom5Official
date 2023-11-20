using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class Color : Entity<int>
    {
        public Color()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductQuantities = new HashSet<ProductQuantity>();
        }
        
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<ProductQuantity> ProductQuantities { get; set; }
    }
}
