using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Credit11s.Dto
{
    /// <summary>
    /// <model cref="Debit"></model>
    /// </summary>
    public class Credit11Input : Entity<int>
    {
        public string AssetId { get; set; }
        public int AccountType { get; set; }
        public double Price { get; set; }
    }
}
