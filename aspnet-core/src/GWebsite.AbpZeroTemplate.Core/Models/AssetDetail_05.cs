using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Core.Models.Base
{
    public class AssetDetail_05 : Entity<int>
    {
        public int AssetDetailId { get; set; }
        public int LiquidationId { get; set; }
        public int UsingProcessId  { get; set; }
        public int RepairId { get; set; }
        public int DepreciationId  { get; set;}
    }
}
