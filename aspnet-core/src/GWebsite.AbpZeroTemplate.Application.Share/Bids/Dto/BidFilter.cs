using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto
{
    /// <summary>
    /// <model cref="Bid"></model>
    /// </summary>
    public class BidFilter : PagedAndSortedInputDto
    {
        public string BidCode { get; set; }
    }
}
