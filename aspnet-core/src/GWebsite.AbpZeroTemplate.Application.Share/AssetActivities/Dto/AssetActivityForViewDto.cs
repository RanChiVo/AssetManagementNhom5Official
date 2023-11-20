using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto
{
    public class AssetActivityForViewDto
    {
        public string AssetActivityType { get; set; }
        public string InvestmentType { get; set; }
        public string AssetId { get; set; }
        public Double Cost { get; set; }
        public DateTime ExecutionTime { get; set; }
    }
}
