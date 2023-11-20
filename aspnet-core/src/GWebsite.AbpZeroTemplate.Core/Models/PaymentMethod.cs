using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class PaymentMethod: Entity<int>
    {
        public string SoTaiKhoan { get; set; }
        public string IdPackagePrices { get; set; }
        public string MaAdmin { get; set; }
        public string UserName { get; set; }
        public string ThongTinNganHang { get; set; }
        public string HoTen { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public bool Status { get; set; }
    }
}
