using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
   public class Repair_05 : Entity<int>
    {
        public string AssetId { get; set; }
        public string InterpretationContent { get; set; }
        public string Unit { get; set; }
        public float AmountOfMoney { get; set; }
        public DateTime RepairDate { get; set; }
        public string RepairUnit { get; set; }
        public string RepairDetail { get; set; }
    }
}
