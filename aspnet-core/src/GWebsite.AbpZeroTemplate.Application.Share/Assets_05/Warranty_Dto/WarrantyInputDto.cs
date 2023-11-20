using Abp.Domain.Entities;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Warranty_Dto
{
    public class WarrantyInputDto : Entity<int>
    {
        public string AssetId { get; set; }
        public float Warrantyperiod { get; set; }
        public DateTime WarrantyDate { get; set; }
        public string InterpretationContent { get; set; }
    }
}
