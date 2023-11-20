using Abp.Runtime.Validation;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetDashboard.Dto
{
    public class AssetDashboardDataInput : AssetDashboardInputBase, IShouldNormalize
    {
        public AssetDashboardChartDateInterval AssetDashboardDateInterval { get; set; }
        public void Normalize()
        {
            TrimTime();
        }

        private void TrimTime()
        {
            StartDate = StartDate.Date;
            StartDate = StartDate.Date;
        }
    }
}
