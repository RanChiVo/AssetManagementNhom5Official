using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractManagements.Dto
{
    /// <summary>
    /// <model cref="ContractManagement"></model>
    /// </summary>
    public class ContractManagementForViewDto
    {
        public string MaHopDong { get; set; }
        public string SoHopDong { get; set; }
        public string NoiDungHopDong { get; set; }
        public string TongGiaTriHopDong { get; set; }
        public string TienDongThiCong { get; set; }
        public string MaHoSoThau { get; set; }
        public string MaCongTrinh { get; set; }
        public string MaToTrinh { get; set; }
        public string MaBaoLanhHopDong { get; set; }
        public string MaBaoLanhBaoHanh { get; set; }

        public string TongTienDaThanhToan { get; set; }
    }
}
