using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes.Dto
{
    /// <summary>
    /// <model cref="CategoryType"></model>
    /// </summary>
    public class CategoryTypeDto : Entity<int>
    {
        public string Name { get; set; }
        public string PrefixWord { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
