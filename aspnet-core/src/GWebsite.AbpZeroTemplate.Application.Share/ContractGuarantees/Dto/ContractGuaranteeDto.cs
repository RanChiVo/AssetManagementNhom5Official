using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractGuarantees.Dto
{
    /// <summary>
    /// <model cref="ContractGuarantee"></model>
    /// </summary>
    public class ContractGuaranteeDto : Entity<int>
    {
        public string MaBaoLanhHopDong { get; set; }
        public string HinhThucBLHD { get; set; }
        public string SoChungTuBLHD { get; set; }
        public string NganHangBLHD { get; set; }
        public string SoTienBLHD { get; set; }
        public string SoTienVNDBLHD { get; set; }
        public string NgayHetHanBLHD { get; set; }
        public string DinhKemBLHD { get; set; }
    }
}
