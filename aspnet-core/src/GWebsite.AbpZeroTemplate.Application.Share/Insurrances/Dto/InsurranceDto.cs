using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Insurrances.Dto
{
    /// <summary>
    /// <model cref="Insurrance"></model>
    /// </summary>
    public class InsurranceDto : Entity<int>
    {
        public string InsurranceId { get; set; }
        public string PurchaseDate { get; set; }
        public string ExpiryDate { get; set; }
        public string Duration { get; set; }
        public string Company { get; set; }
        public string InsurranceTypeId { get; set; }
        public string Payments { get; set; }
        public string Status { get; set; }
    }
}
