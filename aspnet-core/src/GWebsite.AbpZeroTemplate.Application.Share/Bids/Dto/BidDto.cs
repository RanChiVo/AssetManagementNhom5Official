using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto
{
    /// <summary>
    /// <model cref="Bid"></model>
    /// </summary>
    public class BidDto : Entity<int>
    {
        public string BidCode { get; set; }
        public string BidItem { get; set; }
        public string BidFormality { get; set; }
        public string GuaranteeAmount { get; set; }
        public string ApprovalStatus { get; set; }
        public string BidDayStart { get; set; }
        public string BidDayEnd { get; set; }
        public string ProjectName { get; set; }
        public string BidUnit { get; set; }
    }
}
