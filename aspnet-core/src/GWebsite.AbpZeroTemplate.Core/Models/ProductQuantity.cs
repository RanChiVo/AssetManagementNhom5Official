using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class ProductQuantity
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int Quantity { get; set; }

        public Color Color { get; set; }
        public Product Product { get; set; }
        public Size Size { get; set; }
    }
}
