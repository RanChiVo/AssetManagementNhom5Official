using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Auditing;
using Abp.Timing;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetDashboard;
using GWebsite.AbpZeroTemplate.Application.Share.AssetDashboard.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Dto;

namespace GWebsite.AbpZeroTemplate.Web.Core.AssetDashboard
{
    [DisableAuditing]
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetDashboard)]
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset_05)]
    public class AssetDashboardAppService: GWebsiteAppServiceBase, IAssetDashboardAppService
    {
        private readonly IRepository<Asset_05> assetDashboardRepository;
        private readonly IRepository<AssetType_05> assetTypeDashboardRepository;
        private readonly IAssetStatisticsService assetStatisticsService;

        public AssetDashboardAppService(IRepository<Asset_05> assetDashboardRepository,
             IAssetStatisticsService assetStatisticsService, IRepository<AssetType_05> assetTypeDashboardRepository)
        {
            this.assetDashboardRepository = assetDashboardRepository;
            this.assetStatisticsService = assetStatisticsService;
            this.assetTypeDashboardRepository = assetTypeDashboardRepository;
        }

        public async Task<AssetDashboardDataOutput> GetAssetDashboardData(AssetDashboardDataInput input)
        {
            return new AssetDashboardDataOutput
            {
                //line-chart
                AssetTotalNumberStatistics = await assetStatisticsService.GetAssetTotalNumberStatisticsData(input.AssetDashboardDateInterval, input.StartDate, input.EndDate),
                //pie-chart
                AssetStatusStatistics = await GetAssetStatusStatisticsData(input.StartDate, input.EndDate),
                //add more card to dashboard
            };
        }
        public async Task<AssetTotalNumberStatisticsDataOutput> GetAssetTotalNumberStatistics(AssetTotalNumberStatisticsDataInput input)
        {
            return new AssetTotalNumberStatisticsDataOutput(await assetStatisticsService.GetAssetTotalNumberStatisticsData(input.AssetStatisticsDateInterval, input.StartDate, input.EndDate));
        }
        private async Task<List<AssetStatusStatistic>> GetAssetStatusStatisticsData (DateTime startDate, DateTime endDate)
        {
            var assetEntity = assetDashboardRepository.GetAll().Where(x => !x.IsDelete)
                .Where(t => t.PurchaseDate >= startDate &&
                            t.PurchaseDate <= endDate);

            var assetTypeEntity = assetTypeDashboardRepository.GetAll();

            var assetDetailEntity = (from ta in assetEntity
                                     join a in assetTypeEntity on ta.AssetTypeId equals a.Id
                                     select new AssetDto_05
                                     {
                                         Id = ta.Id,
                                         AssetId = ta.AssetId,
                                         Name = ta.Name,
                                         DateAdded = ta.DateAdded,
                                         PurchaseDate = ta.PurchaseDate,
                                         PurchaseFrom = ta.PurchaseFrom,
                                         Quantity = ta.Quantity,
                                         NameAssetType = a.Name,
                                     }).GroupBy(t => t.AssetId)
                                     .Select(t => new AssetStatusStatistic
                                     {
                                         Label = t.Key,
                                         Value = t.Count()
                                     }).OrderBy(t => t.Label).ToListAsync();

            return await assetDetailEntity;

        }

    }
}



