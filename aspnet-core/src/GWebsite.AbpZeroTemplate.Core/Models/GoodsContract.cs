using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class GoodsContract
    {
        public string GoodsContractCode { get; set; }
        public string GoodsName { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public string SupplierName { get; set; }
    }
}
