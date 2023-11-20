using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.ModelVehicles.Dto
{
    public class ModelVehicleDto : Entity<int>
    {
        public string IdModel { get; set; }
        public string NameModel { get; set; }
    }
}
