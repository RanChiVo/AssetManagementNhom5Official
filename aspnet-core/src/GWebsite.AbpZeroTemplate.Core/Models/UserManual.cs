using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class UserManual : Entity<int>
    {
        public string Code { get; set; }
        public string ValueString { get; set; }
        public string ValueHtml { get; set; }
        public string Image { get; set; }
        public int? ValueInt { get; set; }
        public int? UserManualCategoryId { get; set; }
    }
}
