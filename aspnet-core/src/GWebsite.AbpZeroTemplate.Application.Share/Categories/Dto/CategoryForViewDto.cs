using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto
{
    public class CategoryForViewDto
    {
        public string CategoryType { get; set; }
        public string CategoryId { get; set; }

        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public bool IsDelete { get; set; }
    }
}
