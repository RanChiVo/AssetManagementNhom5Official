using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto
{
    public class CustomerFilter : PagedAndSortedInputDto
    {
        public String Name { get; set; }
    }
}
