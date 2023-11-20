using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class OrderPackage : Entity<int>
    {
        public int? IdUser { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDay { get; set; }
        public decimal SumRegister { get; set; }
        public decimal SumCheckout { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public int IdPackagePrices { get; set; }
        public string Data { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string CodePricesPackages { get; set; }
        public string Token { get; set; }
        public string RecordStatus { get; set; }
        public string AuthStatus { get; set; }
        public string MakerId { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CheckerId { get; set; }
        public DateTime? ApproveDt { get; set; }
        public string EditorId { get; set; }
        public DateTime? EditDt { get; set; }
        public string BankCode { get; set; }
        public int? IdUserString { get; set; }
        public int MonthNumber { get; set; }
        public DateTime? ExpireDt { get; set; }
        public string Website { get; set; }
        public string Subdomain { get; set; }
        public string FtpUser { get; set; }
        public string FtpPassword { get; set; }
        public string LinkAzure { get; set; }
        public string SqlUser { get; set; }
        public string SqlPass { get; set; }
        public string IsCheckOut { get; set; }
        public string AuthStatus1 { get; set; }
        public string FullName { get; set; }
        public string ValueString1 { get; set; }
        public string ValueString2 { get; set; }
        public string CheckId { get; set; }
        public string IsSentMailExpired { get; set; }
        public string IsTrial { get; set; }
        public bool IsHot { get; set; }
        public int Order { get; set; }
    }
}
