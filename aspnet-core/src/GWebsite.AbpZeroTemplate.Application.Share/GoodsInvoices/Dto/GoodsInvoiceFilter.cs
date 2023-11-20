using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.GoodsInvoices.Dto
{
    /// <summary>
    /// <model cref="GoodsInvoice"></model>
    /// </summary>
    public class GoodsInvoiceFilter : PagedAndSortedInputDto
    {
        public string POName { get; set; }
    }
}
