using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto
{
    /// <summary>
    /// <model cref="Category"></model>
    /// </summary>
    public class CategoryFilter : PagedAndSortedInputDto
    {
        public string CategoryType { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public bool IsCreatedCheckedAll { get; set; }
        public DateTime StartCreatedDate { get; set; }
        public DateTime EndCreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public bool IsUpdatedCheckedAll { get; set; }
        public DateTime StartUpdatedDate { get; set; }
        public DateTime EndUpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
