using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class ContractPayment : FullAuditModel
    {
        public string ContractPaymentCode { get; set; }
        public string TimePayment { get; set; }
        public string PaymentDate { get; set; }
        public string Ratio { get; set; }
        public string Money { get; set; }
        public string Content { get; set; }
        public string ContractCode { get; set; }
        public Boolean Disable { get; set; }

        public ContractPayment()
        {
            this.Disable = false;
        }
    }
}
