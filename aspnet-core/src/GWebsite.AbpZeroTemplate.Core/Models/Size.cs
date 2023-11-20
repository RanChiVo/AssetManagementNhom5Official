using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class Size : Entity<int>
    {
        public Size()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductQuantities = new HashSet<ProductQuantity>();
        }
        
        public string Name { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<ProductQuantity> ProductQuantities { get; set; }
    }
}
