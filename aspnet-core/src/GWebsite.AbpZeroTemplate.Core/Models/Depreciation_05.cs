using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Depreciation_05 :Entity<int>
    {
        public string AssetId { get; set; }
        public string Name { get; set; }
        public float AmountOfMoney { get; set; }
        public string Content { get; set; }
    }
}
