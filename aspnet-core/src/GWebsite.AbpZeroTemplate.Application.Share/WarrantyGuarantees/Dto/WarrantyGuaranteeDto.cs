using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.WarrantyGuarantees.Dto
{
    /// <summary>
    /// <model cref="WarrantyGuarantee"></model>
    /// </summary>
    public class WarrantyGuaranteeDto : Entity<int>
    {
        public string MaBaoLanhBaoHanh { get; set; }
        public string HinhThucBLBH { get; set; }
        public string SoChungTuBLBH { get; set; }
        public string NganHangBLBH { get; set; }
        public string SoTienBLBH { get; set; }
        public string SoTienVNDBLBH { get; set; }
        public string NgayHetHanBLBH { get; set; }
        public string DinhKemBLBH { get; set; }
    }
}
