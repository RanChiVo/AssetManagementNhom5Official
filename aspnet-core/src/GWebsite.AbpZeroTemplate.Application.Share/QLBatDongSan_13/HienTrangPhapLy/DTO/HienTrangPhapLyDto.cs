using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.HienTrangPhapLy.DTO
{
    public class HienTrangPhapLyDto : Entity<int>
    {
        public string Name { get; set; }
    }
}
