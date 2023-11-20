using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Core
{
    public class PurchaseOder_05 : Entity<int>
    {
        public string PONumber { get; set; }
        public string Supplier { get; set; }
    }
}
