using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.TypeVehicles.Dto
{
    public class TypeVehicleInput : Entity<int>
    {
        public string IdTypeCar { get; set; }
        public string NameTypeCar { get; set; }
    }
}
