using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class BrandVehicle : FullAuditModel
    {
        public string IdVehicle { get; set; }
        public string NameVehicle { get; set; }
    }
}
