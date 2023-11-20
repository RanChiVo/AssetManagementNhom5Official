using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
   public class UsingProcessDetail_05 : Entity<int>
    {
        public DateTime UseDate { get; set; }
        public string Unit { get; set; }
        public string User { get; set; }
        public string Content { get; set; }
    }
}
