using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class WarrantyDetail_05 : Entity<int>
    {
        public string Id { get; set; }
        public float Warrantyperiod { get; set; }
        public DateTime WarrantyDate { get; set; }
        public string InterpretationContent { get; set; }
    }
}
