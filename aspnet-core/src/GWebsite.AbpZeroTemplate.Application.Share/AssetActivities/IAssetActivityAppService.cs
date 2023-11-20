using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetActivities
{
    public interface IAssetActivityAppService
    {
        void CreateOrEditAssetActivity(AssetActivityInput assetActivityInput);
        AssetActivityInput GetAssetActivityForEdit(int id);
        void DeleteAssetActivity(int id);
        PagedResultDto<AssetActivityDto> GetAssetActivities(AssetActivityFilter input);
        AssetActivityForViewDto GetAssetActivityForView(int id);
    }
}
