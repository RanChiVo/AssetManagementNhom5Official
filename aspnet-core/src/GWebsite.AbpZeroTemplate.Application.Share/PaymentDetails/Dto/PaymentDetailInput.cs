using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.PaymentDetails.Dto
{
    /// <summary>
    /// <model cref="PaymentDetails_9"></model>
    /// </summary>
    public class PaymentDetailInput : Entity<int>
    {
        public string NgayDuKienThanhToan { get; set; }
        public string SoTienThanhToan { get; set; }
        public string DaThanhToan { get; set; }
        public string NgayThanhToan { get; set; }
        public string NoiDungThanhToan { get; set; }
    }
}
