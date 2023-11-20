using Abp.Application.Services;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetDashboard.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetDashboard
{
    public interface IAssetDashboardAppService
    {
        Task<AssetDashboardDataOutput> GetAssetDashboardData(AssetDashboardDataInput input);

        Task<AssetTotalNumberStatisticsDataOutput> GetAssetTotalNumberStatistics(AssetTotalNumberStatisticsDataInput input);
    }
}
