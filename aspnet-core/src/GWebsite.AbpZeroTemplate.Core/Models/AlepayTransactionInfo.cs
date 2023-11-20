using Abp.Domain.Entities;
using System;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class AlepayTransactionInfo : Entity<int>
    {
        public string TransactionCode { get; set; }
        public string OrderCode { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerPhone { get; set; }
        public string CardNumber { get; set; }
        public string BuyerName { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string Installment { get; set; }
        public string Is3D { get; set; }
        public string Month { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string Method { get; set; }
        public string TransactionTime { get; set; }
        public string SuccessTime { get; set; }
        public string BankHotline { get; set; }
        public string AlepayToken { get; set; }
        public string ErrorCode { get; set; }
        public string Cancel { get; set; }
        public string Data { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public int? IdUser { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? IdPackagePrices { get; set; }
        public string CodePricesPackages { get; set; }
        public string RecordStatus { get; set; }
        public string AuthStatus { get; set; }
        public string MakerId { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CheckerId { get; set; }
        public DateTime? ApproveDt { get; set; }
        public string EditorId { get; set; }
        public DateTime? EditDt { get; set; }
    }
}
