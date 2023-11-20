using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.BidManagers;
using GWebsite.AbpZeroTemplate.Application.Share.BidManagers.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BidManagerController : GWebsiteControllerBase
    {
        private readonly IBidManagerAppService BidManagerAppService;

        public BidManagerController(IBidManagerAppService BidManagerAppService)
        {
            this.BidManagerAppService = BidManagerAppService;
        }

        [HttpGet]
        public PagedResultDto<BidManagerDto> GetBidManagersByFilter(BidManagerFilter BidManagerFilter)
        {
            return BidManagerAppService.GetBidManagers(BidManagerFilter);
        }

        [HttpGet]
        public BidManagerInput GetBidManagerForEdit(int id)
        {
            return BidManagerAppService.GetBidManagerForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditBidManager([FromBody] BidManagerInput input)
        {
            BidManagerAppService.CreateOrEditBidManager(input);
        }

        [HttpDelete("{id}")]
        public void DeleteBidManager(int id)
        {
            BidManagerAppService.DeleteBidManager(id);
        }

        [HttpGet]
        public BidManagerForViewDto GetBidManagerForView(int id)
        {
            return BidManagerAppService.GetBidManagerForView(id);
        }
    }
}
