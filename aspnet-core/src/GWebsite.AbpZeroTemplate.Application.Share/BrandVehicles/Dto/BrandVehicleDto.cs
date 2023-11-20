using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.BrandVehicles.Dto
{
    public class BrandVehicleDto : Entity<int>
    {
        public string IdVehicle { get; set; }
        public string NameVehicle { get; set; }
    }
}
