using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetDashboard.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Web.Core.AssetDashboard
{
    public class AssetStatisticsService : GWebsiteAppServiceBase, IAssetStatisticsService
    {
        private readonly IRepository<Asset_05> assetDashboardRepository;

        public AssetStatisticsService(IRepository<Asset_05> assetDashboardRepository)
        {
            this.assetDashboardRepository = assetDashboardRepository;
        }

        public async Task<List<AssetTotalNumberStatistic>> GetDailyAssetStatisticsData(DateTime startDate, DateTime endDate)
        {
            var dailyRecords = await assetDashboardRepository.GetAll()
                .Where(s => s.PurchaseDate >= startDate &&
                            s.PurchaseDate <= endDate)
                .GroupBy(s => new DateTime(s.PurchaseDate.Year, s.PurchaseDate.Month, s.PurchaseDate.Day))
                .Select(s => new AssetTotalNumberStatistic
                {
                    Date = s.First().PurchaseDate.Date,
                    NumberOfAsset = s.Sum(c => c.Quantity)
                })
                .ToListAsync();

            FillGapsInDailyAssetStatistics(dailyRecords, startDate, endDate);
            return dailyRecords.OrderBy(s => s.Date).ToList();
        }

        public static void FillGapsInDailyAssetStatistics(ICollection<AssetTotalNumberStatistic> dailyRecords, DateTime startDate, DateTime endDate)
        {
            var currentDay = startDate;
            while (currentDay <= endDate)
            {
                if (dailyRecords.All(d => d.Date != currentDay.Date))
                {
                    dailyRecords.Add(new AssetTotalNumberStatistic(currentDay));
                }

                currentDay = currentDay.AddDays(1);
            }
        }

        public async Task<List<AssetTotalNumberStatistic>> GetAssetTotalNumberStatisticsData(AssetDashboardChartDateInterval dateInterval,
            DateTime startDate, DateTime endDate)
        {
            List<AssetTotalNumberStatistic> assetTotalNumberStastistics;
             
            switch (dateInterval)
            {
                case AssetDashboardChartDateInterval.Daily:
                    assetTotalNumberStastistics = await GetDailyAssetStatisticsData(startDate, endDate);
                    break;
                case AssetDashboardChartDateInterval.Weekly:
                    assetTotalNumberStastistics = await GetWeeklyAssetStatisticsData(startDate, endDate);
                    break;
                case AssetDashboardChartDateInterval.Monthly:
                    assetTotalNumberStastistics = await GetMonthlyAssetStatisticsData(startDate, endDate);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dateInterval), dateInterval, null);
            }

            assetTotalNumberStastistics.ForEach(i =>
            {
                i.Label = i.Date.ToString(L("DateFormatShort"));
            });

            return assetTotalNumberStastistics.OrderBy(i => i.Date).ToList();
        }

        public async Task<List<AssetTotalNumberStatistic>> GetWeeklyAssetStatisticsData(DateTime startDate, DateTime endDate)
        {
            var dailyRecords = await GetDailyAssetStatisticsData(startDate, endDate);
            var firstDayOfWeek = DateTimeFormatInfo.CurrentInfo == null
                ? DayOfWeek.Sunday
                : DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek;

            var assetTotalNumberStastistics = new List<AssetTotalNumberStatistic>();
            decimal weeklyAmount = 0;
            var weekStart = dailyRecords.First().Date;
            var isFirstWeek = weekStart.DayOfWeek == firstDayOfWeek;

            dailyRecords.ForEach(dailyRecord =>
            {
                if (dailyRecord.Date.DayOfWeek == firstDayOfWeek)
                {
                    if (!isFirstWeek)
                    {
                        assetTotalNumberStastistics.Add(new AssetTotalNumberStatistic(weekStart, weeklyAmount));
                    }

                    isFirstWeek = false;
                    weekStart = dailyRecord.Date;
                    weeklyAmount = 0;
                }

                weeklyAmount += dailyRecord.NumberOfAsset;
            });

            assetTotalNumberStastistics.Add(new AssetTotalNumberStatistic(weekStart, weeklyAmount));
            return assetTotalNumberStastistics;
        }

        public async Task<List<AssetTotalNumberStatistic>> GetMonthlyAssetStatisticsData(DateTime startDate, DateTime endDate)
        {
            var dailyRecords = await GetDailyAssetStatisticsData(startDate, endDate);
            var query = dailyRecords.GroupBy(d => new
            {
                d.Date.Year,
                d.Date.Month
            })
            .Select(grouping => new AssetTotalNumberStatistic
            {
                Date = FindMonthlyDate(startDate, grouping.Key.Year, grouping.Key.Month),
                NumberOfAsset = grouping.DefaultIfEmpty().Sum(x => x.NumberOfAsset)
            });

            return query.ToList();
        }

        public static DateTime FindMonthlyDate(DateTime startDate, int groupYear, int groupMonth)
        {
            if (groupYear == startDate.Year && groupMonth == startDate.Month)
            {
                return new DateTime(groupYear, groupMonth, startDate.Day);
            }

            return new DateTime(groupYear, groupMonth, 1);
        }
    }

}