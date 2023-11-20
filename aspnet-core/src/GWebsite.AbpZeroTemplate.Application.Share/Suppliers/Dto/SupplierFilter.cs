using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Suppliers.Dto
{
    /// <summary>
    /// <model cref="Supplier"></model>
    /// </summary>
    public class SupplierFilter : PagedAndSortedInputDto
    {
        public string SupplierName { get; set; }
    }
}
