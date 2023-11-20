using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;


namespace GWebsite.AbpZeroTemplate.Application.Share.BrandVehicles.Dto
{
    public class BrandVehicleFilter : PagedAndSortedInputDto
    {
        public string IdVehicle { get; set; }
    }
}
