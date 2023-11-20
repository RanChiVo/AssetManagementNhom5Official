using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetDashboard.Dto
{
    public class AssetTotalNumberStatisticsDataOutput
    {
        public List<AssetTotalNumberStatistic> assetDashboardAssetStastistics { get; set; }

        public AssetTotalNumberStatisticsDataOutput(List<AssetTotalNumberStatistic> assetDashboardAssetStastistics)
        {
            this.assetDashboardAssetStastistics = assetDashboardAssetStastistics;
        }
    }
}