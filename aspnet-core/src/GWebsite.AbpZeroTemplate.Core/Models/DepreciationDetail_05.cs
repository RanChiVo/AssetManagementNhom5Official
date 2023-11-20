using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class DepreciationDetail_05 :Entity<int>
    {
        public string Name { get; set; }
        public float AmountOfMoney { get; set; }
        public string Content { get; set; }
    }
}
