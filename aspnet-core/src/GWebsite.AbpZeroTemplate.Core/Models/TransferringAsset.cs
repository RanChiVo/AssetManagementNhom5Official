using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class TransferringAsset : FullAuditModel
    {
        public DateTime? TransferringDate { get; set; }
        public string AssetId { get; set; }
        public bool IsChecked { get; set; }
        public long UsingUnit { get; set; }
        public long UsingUser { get; set; }
        public long ReceivingUnit { get; set; }
        public long ReceivingUser { get; set; }
        public string Note { get; set; }
        public string AttachingFileName { get; set; }
    }
}
