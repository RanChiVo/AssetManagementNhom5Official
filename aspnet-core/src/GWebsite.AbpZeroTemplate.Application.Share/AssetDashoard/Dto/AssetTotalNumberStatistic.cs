using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetDashboard.Dto
{
    public class AssetTotalNumberStatistic
    {
        public string Label { get; set; }
        public DateTime Date { get; set; }
        public decimal NumberOfAsset { get; set; }

        public AssetTotalNumberStatistic()
        {

        }

        public AssetTotalNumberStatistic( DateTime date)
        { 
            Date = date;
        }

        public AssetTotalNumberStatistic(DateTime date, decimal numberOfAsset)
        {
            Date = date;
            this.NumberOfAsset = numberOfAsset;
        }
    }
}
