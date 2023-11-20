using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Asset11s;
using GWebsite.AbpZeroTemplate.Application.Share.Asset11s.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class Asset11Controller : GWebsiteControllerBase
    {
        private readonly IAsset11AppService asset11AppService;

        public Asset11Controller(IAsset11AppService asset11AppService)
        {
            this.asset11AppService = asset11AppService;
        }

        [HttpGet]
        public PagedResultDto<Asset11Dto> GetAsset11sByFilter(Asset11Filter asset11Filter)
        {
            return asset11AppService.GetAsset11s(asset11Filter);
        }

        [HttpGet]
        public Asset11Input GetAsset11ForEdit(int id)
        {
            return asset11AppService.GetAsset11ForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditAsset11([FromBody] Asset11Input input)
        {
            asset11AppService.CreateOrEditAsset11(input);
        }

        [HttpPost]
        public void Accounting()
        {
            asset11AppService.Accounting();
        }


        [HttpPost]
        public void Depreciating()
        {
            asset11AppService.Depreciating();
        }

        [HttpDelete("{id}")]
        public void DeleteAsset11(int id)
        {
            asset11AppService.DeleteAsset11(id);
        }

        [HttpGet]
        public Asset11ForViewDto GetAsset11ForView(int id)
        {
            return asset11AppService.GetAsset11ForView(id);
        }
    }
}
