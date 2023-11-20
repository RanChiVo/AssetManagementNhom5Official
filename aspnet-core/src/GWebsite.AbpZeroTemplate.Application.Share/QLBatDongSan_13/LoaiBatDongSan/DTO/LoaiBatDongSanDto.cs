using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiBatDongSan.DTO
{
    public class LoaiBatDongSanDto : Entity<int>
    {
        public string Name { get; set; }
    }
}
