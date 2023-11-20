using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Plans.Dto
{
    /// <summary>
    /// <model cref="Plan_9"></model>
    /// </summary>
    public class PlanInput : Entity<int>
    {
        public string MaKeHoach { get; set; }
        public string TenKeHoach { get; set; }
        public string MaDonVi { get; set; }
        public string NgayLapKeHoach { get; set; }
        public string TrangThaiDuyet { get; set; }
        public string NgayHieuLuc { get; set; }
        public int NamThucHien { get; set; }
        public string TongChiPhi { get; set; }
        public string TongChiPhiĐuocDuyet { get; set; }
    }
}
