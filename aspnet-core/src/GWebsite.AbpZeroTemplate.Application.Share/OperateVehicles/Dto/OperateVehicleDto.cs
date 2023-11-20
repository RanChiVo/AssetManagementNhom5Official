using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.OperateVehicles.Dto
{
    public class OperateVehicleDto : Entity<int>
    {
        public string MaVanHanh { get; set; }
        public string NgayVanHanh { get; set; }
        public float SoKm { get; set; }
        public string XangTieuThu { get; set; }
        public string TrangThaiDuyet { get; set; }
        public string GhiChu { get; set; }
        public string Number { get; set; }
        public string IdVehicle { get; set; }
        public string Name { get; set; }
    }
}