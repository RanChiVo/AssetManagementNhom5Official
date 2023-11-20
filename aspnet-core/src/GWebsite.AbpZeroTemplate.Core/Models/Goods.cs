using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Goods : FullAuditModel
    {
        public string GoodsCode { get; set; }
        public string GoodsName { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public string CountryOfManufacture { get; set; }
        public string ContractCode { get; set; }
    }
}
