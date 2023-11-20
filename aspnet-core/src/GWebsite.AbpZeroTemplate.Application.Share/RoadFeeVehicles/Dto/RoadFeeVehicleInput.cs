using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.RoadFeeVehicles.Dto
{
    public class RoadFeeVehicleInput : Entity<int>
    {

        public string MaPhiDuongBo { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public string LoaiPhi { get; set; }
        public string SoTien { get; set; }
        public string DonViThuPhi { get; set; }
        public string TrangThaiDuyet { get; set; }
        public string GhiChu { get; set; }
    }
}
