using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto
{
    public class CategoryInput
    {
        public int? Id { get; set; }
        [Required]
        public string CategoryType { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }


    }
}
