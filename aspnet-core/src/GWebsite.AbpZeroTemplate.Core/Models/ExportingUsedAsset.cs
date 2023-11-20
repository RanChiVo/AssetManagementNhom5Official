using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class ExportingUsedAsset : FullAuditModel
    {
        public DateTime ExportingDay { get; set; }
        public string AssetId { get; set; }
        public DateTime BeginningDateofDepreciation { get; set; }
        public string UsingUnit { get; set; }
        public string User { get; set; }
        public string Note { get; set; }
    }
}
