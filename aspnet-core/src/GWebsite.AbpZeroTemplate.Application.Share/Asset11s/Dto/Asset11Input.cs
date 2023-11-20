using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Asset11s.Dto
{
    /// <summary>
    /// <model cref="Asset11"></model>
    /// </summary>
    public class Asset11Input : Entity<int>
    {
        public string Name { get; set; }
        public string AssetId { get; set; }
        public double Price { get; set; }
        public int Vat { get; set; }
        public int Quantity { get; set; }
        public int Time { get; set; }
        public int DebitAccount { get; set; }
        public int CreditAccount { get; set; }
    }
}
