using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Asset_8;
using GWebsite.AbpZeroTemplate.Application.Share.Asset_8.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{

    [Route("api/[controller]/[action]")]
    public class Asset_8Controller : GWebsiteControllerBase
    {
        private readonly IAsset_8AppService asset_8AppService;

        public Asset_8Controller(IAsset_8AppService asset_8AppService)
        {
            this.asset_8AppService = asset_8AppService;
        }

        [HttpGet]
        public PagedResultDto<Asset_8Dto> GetAssets_8ByFilter(Asset_8Filter asset_8Filter)
        {
            return asset_8AppService.GetAssets_8(asset_8Filter);
        }

        [HttpGet]
        public Asset_8Input GetAsset_8ForEdit(int id)
        {
            return asset_8AppService.GetAsset_8ForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditAsset_8([FromBody] Asset_8Input input)
        {
            asset_8AppService.CreateOrEditAsset_8(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAsset_8(int id)
        {
            asset_8AppService.DeleteAsset_8(id);
        }

        [HttpGet]
        public Asset_8ForViewDto GetAsset_8ForView(int id)
        {
            return asset_8AppService.GetAsset_8ForView(id);
        }
    }

}
