using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.GoodsList.Dto
{
    /// <summary>
    /// <model cref="Goods"></model>
    /// </summary>
    public class GoodsFilter : PagedAndSortedInputDto
    {
        public string GoodsCode { get; set; }
    }
}
