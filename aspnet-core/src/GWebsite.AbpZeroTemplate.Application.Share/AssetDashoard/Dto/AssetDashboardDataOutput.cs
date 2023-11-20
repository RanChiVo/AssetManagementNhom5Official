using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetDashboard.Dto
{
    public class AssetDashboardDataOutput
    {
        public List<AssetTotalNumberStatistic> AssetTotalNumberStatistics { get; set; }
        public List<AssetStatusStatistic> AssetStatusStatistics { get; set; }
    }
}

