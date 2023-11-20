using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class AdsPage : Entity<int>
    {
        public string Link { get; set; }
    }
}
