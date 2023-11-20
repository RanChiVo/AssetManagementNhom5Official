using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class AssetUser_05 : Entity<int>
    {
        public string AssetUnitID { get; set; }
        public string AssetUserID { get; set; }
        public string AssetUserName { get; set; }
    }
   
}
