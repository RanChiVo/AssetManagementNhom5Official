using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Asset11s.Dto
{
    /// <summary>
    /// <model cref="Asset11"></model>
    /// </summary>
    public class Asset11ForViewDto
    {
        public string Name { get; set; }
        public string AssetId { get; set; }
        public double Price { get; set; }
        public int Vat { get; set; }
        public int Quantity { get; set; }
        public int Time { get; set; }
        public int DebitAccount { get; set; }
        public int CreditAccount { get; set; }
        public bool IsAccounted { get; set; }
        public bool IsDepreciated { get; set; }
    }
}
