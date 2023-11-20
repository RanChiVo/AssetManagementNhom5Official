using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Insurrance : FullAuditModel
    {
        public string InsurranceId { get; set; }
        public string PurchaseDate { get; set; }
        public string ExpiryDate { get; set; }
        public string Duration { get; set; }
        public string Company { get; set; }
        public string InsurranceTypeId { get; set; }
        public string Payments { get; set; }
        public string Status { get; set; }
    }
}
