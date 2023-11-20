using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Warranty_Dto
{
    public class WarrantyDto : Entity<int>
    {
        public string AssetId { get; set; }
        public float Warrantyperiod { get; set; }
        public DateTime WarrantyDate { get; set; }
        public string InterpretationContent { get; set; }
    }
}