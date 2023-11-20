using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto
{
    public class AssetActivityFilter : PagedAndSortedInputDto
    {
        public string AssetActivityType { get; set; }
        public string InvestmentType { get; set; }
        public string AssetId { get; set; }
        public DateTime StartingExecutionTime { get; set; }
        public DateTime EndingExecutionTime { get; set; }
    }
}
