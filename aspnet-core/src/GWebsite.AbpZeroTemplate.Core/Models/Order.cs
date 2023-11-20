using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class Order : Entity<int>
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerMessage { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string PaymentStatus { get; set; }
        public bool Status { get; set; }
        public string CustomerId { get; set; }

        public AppUser Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
