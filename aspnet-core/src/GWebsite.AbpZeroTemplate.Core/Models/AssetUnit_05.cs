using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class AssetUnit_05 : Entity<int>
    {
        public string AssetUnitID { get; set; }
        public int AssetRegionID { get; set; }
        public int AssetFatherUnitID { get; set; }
        public string AssetUnitName { get; set; }
    }
   
}
