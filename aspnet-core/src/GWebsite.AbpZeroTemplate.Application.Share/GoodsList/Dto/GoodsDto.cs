using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.GoodsList.Dto
{
    /// <summary>
    /// <model cref="Goods"></model>
    /// </summary>
    public class GoodsDto : Entity<int>
    {
        public string GoodsCode { get; set; }
        public string GoodsName { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public string CountryOfManufacture { get; set; }
        public string ContractCode { get; set; }
    }
}
