using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiBatDongSan.DTO
{
    public class LoaiBatDongSanFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}
