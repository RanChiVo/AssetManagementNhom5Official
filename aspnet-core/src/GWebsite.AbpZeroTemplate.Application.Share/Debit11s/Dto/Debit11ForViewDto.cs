using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Debit11s.Dto
{
    /// <summary>
    /// <model cref="Debit"></model>
    /// </summary>
    public class Debit11ForViewDto
    {
        public string AssetId { get; set; }
        public int AccountType { get; set; }
        public double Price { get; set; }
    }
}
