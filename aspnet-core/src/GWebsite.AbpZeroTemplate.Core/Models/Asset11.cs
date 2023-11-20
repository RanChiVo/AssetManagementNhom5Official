namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Asset11 : FullAuditModel
    {
        public string Name { get; set; }
        public string AssetId { get; set; }
        public int Price { get; set; }
        public int Vat { get; set; }
        public int Quantity { get; set; }
        public int Time { get; set; }
        public int DebitAccount { get; set; }
        public int CreditAccount { get; set; }
        public bool IsAccounted { get; set; }
        public bool IsDepreciated { get; set; }
    }
}