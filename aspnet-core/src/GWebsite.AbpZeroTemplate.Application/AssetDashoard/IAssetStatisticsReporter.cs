using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Application.Share.AssetDashboard.Dto;

namespace GWebsite.AbpZeroTemplate.Web.Core.AssetDashboard
{
    public interface IAssetStatisticsService
    {
        Task<List<AssetTotalNumberStatistic>> GetAssetTotalNumberStatisticsData(AssetDashboardChartDateInterval dateInterval,
            DateTime startDate, DateTime endDate );
    }
}