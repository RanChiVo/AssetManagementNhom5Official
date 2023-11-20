using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class Footers : Entity<string>
    {
        public string Content { get; set; }
    }
}
