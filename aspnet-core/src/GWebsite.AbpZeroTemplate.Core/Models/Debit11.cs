namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Debit11 : FullAuditModel
    {
        public string AssetId { get; set; }
        public int AccountType { get; set; }
        public double Price { get; set; } 
    }
}