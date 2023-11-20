using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class InsurranceType : FullAuditModel
    {
        public string InsurranceTypeId { get; set; }
        public string InsurranceTypeName { get; set; }
    }
}
