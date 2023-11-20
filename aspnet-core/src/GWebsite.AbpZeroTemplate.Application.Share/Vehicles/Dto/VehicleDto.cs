﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Vehicles.Dto
{
    public class VehicleDto : Entity<int>
    {

        public string IdVehicle { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public string IdTypeCar { get; set; }
        public string Model { get; set; }
        public string MachineNumber { get; set; }
        public string Color { get; set; }
        public string HostName { get; set; }
        public string NameEngine { get; set; }

        public string MaTaiSan { set; get; }
        public string TenTaiSan { set; get; }
        public float NguyenGiaTaiSan { set; get; }
        public string IdModel { get; set; }
        public string SoKmDaDi { get; set; }
        public string DinhMucNhienLieu { get; set; }

        public string MaVanHanh { get; set; }
    }
}