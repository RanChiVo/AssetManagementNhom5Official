using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;


namespace GWebsite.AbpZeroTemplate.Application.Share.OperateVehicles.Dto
{
    public class OperateVehicleFilter : PagedAndSortedInputDto
    {
        public string NgayVanHanh { get; set; }
        public string MaVanHanh { get; set; }
        public string Number { get; set; }
    }
}
