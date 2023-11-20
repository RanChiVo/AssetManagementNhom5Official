using GWebsite.AbpZeroTemplate.Application.Share.AssetDashboard;
using GWebsite.AbpZeroTemplate.Application.Share.AssetDashboard.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AssetDashboardController : GWebsiteControllerBase
    {
        private readonly IAssetDashboardAppService assetDashboardAppService;

        public AssetDashboardController(IAssetDashboardAppService assetDashboardAppService)
        {
            this.assetDashboardAppService = assetDashboardAppService;
        }

        [HttpGet]
        public async Task<AssetDashboardDataOutput> GetAssetDashboardData(AssetDashboardChartDateInterval assetDashboardDateInterval, DateTime startDate, DateTime endDate)
        {
            return await assetDashboardAppService.GetAssetDashboardData(new AssetDashboardDataInput() { AssetDashboardDateInterval = assetDashboardDateInterval, StartDate = startDate, EndDate = endDate});
        }

        [HttpGet]
        public async Task<AssetTotalNumberStatisticsDataOutput> GetAssetTotalNumberStatistics(AssetDashboardChartDateInterval assetStatisticsDateInterval, DateTime startDate, DateTime endDate)
        {
            return await assetDashboardAppService.GetAssetTotalNumberStatistics(new AssetTotalNumberStatisticsDataInput() { AssetStatisticsDateInterval = assetStatisticsDateInterval, StartDate = startDate, EndDate = endDate });
        }
    }

}
