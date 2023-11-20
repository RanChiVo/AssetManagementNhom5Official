using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlanDetails.Dto
{
    public class ShoppingPlanDetailDto:Entity<int>
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string DonVi { get; set; }
        public string SoLuong { get; set; }
        public string GiaTriMotSP { get; set; }
        public int ThangKeHoach { get; set; }
        public int SoLuongThucHien { get; set; }
        public int ThanhThucHien { get; set; }
        public string MaKeHoach { get; set; }
    }
}
