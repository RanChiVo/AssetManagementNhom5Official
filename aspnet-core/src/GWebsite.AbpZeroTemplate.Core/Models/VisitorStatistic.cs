using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class VisitorStatistic : Entity<Guid>
    {
        public DateTime VisitedDate { get; set; }
        public string Ipaddress { get; set; }
    }
}
