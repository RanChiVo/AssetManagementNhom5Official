namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class CategoryType : FullAuditModel
    {
        public string Name { get; set; }
        public string PrefixWord { get; set; }
        public string Description { get; set; }
    }
}
