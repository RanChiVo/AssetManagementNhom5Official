using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class RepairDetail_05 : Entity<int>
    {
        public string InterpretationContent { get; set; }
        public string Unit { get; set; }
        public float AmountOfMoney { get; set; }
        public DateTime RepairDate { get; set; }
        public string RepairUnit { get; set; }
        public string RepairDetail { get; set; }
    }
}
