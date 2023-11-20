using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Asset_8.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Asset_8
{
    public interface IAsset_8AppService
    {
        void CreateOrEditAsset_8(Asset_8Input asset_8Input);

        Asset_8Input GetAsset_8ForEdit(int id);
        void DeleteAsset_8(int id);
        PagedResultDto<Asset_8Dto> GetAssets_8(Asset_8Filter input);
        Asset_8ForViewDto GetAsset_8ForView(int id);
    }
}
