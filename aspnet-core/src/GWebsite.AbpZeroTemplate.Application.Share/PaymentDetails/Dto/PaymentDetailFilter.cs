using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;


namespace GWebsite.AbpZeroTemplate.Application.Share.PaymentDetails.Dto
{
    /// <summary>
    /// <model cref="PaymentDetails_9"></model>
    /// </summary>
    public class PaymentDetailFilter : PagedAndSortedInputDto
    {
        public string DaThanhToan { get; set; }
    }
}
