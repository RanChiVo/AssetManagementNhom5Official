using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes.Dto
{
    public class CategoryTypeInput : Entity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PrefixWord { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
