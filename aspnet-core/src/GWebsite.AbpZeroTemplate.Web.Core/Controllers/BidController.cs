using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bids;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Projects;
using GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BidController : GWebsiteControllerBase
    {
        private readonly IBidAppService bidAppService;

        public BidController(IBidAppService bidAppService)
        {
            this.bidAppService = bidAppService;
        }

        [HttpGet]
        public PagedResultDto<BidDto> GetBidsByFilter(BidFilter bidFilter)
        {
            return bidAppService.GetBids(bidFilter);
        }

        [HttpGet]
        public async Task<ListResultDto<ProjectDto>> GetProjectRelateToBids()
        {
            return await bidAppService.GetProjectRelateToBids();
        }

        [HttpGet]
        public BidInput GetBidForEdit(int id)
        {
            return bidAppService.GetBidForEdit(id);
        }

        //[HttpGet]
        //public async Task<BidOutput> GetBidForEditAsync(int id)
        //{
        //    return await bidAppService.GetBidForEditAsync(new NullableIdDto() { Id = id });
        //}

        [HttpGet]
        public async Task<ProjectOutput> GetProjectComboboxForEditAsync(int id)
        {
            return await bidAppService.GetProjectComboboxForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpPost]
        public void CreateOrEditBid([FromBody] BidInput input)
        {
            bidAppService.CreateOrEditBid(input);
        }

        [HttpDelete("{id}")]
        public void DeleteBid(int id)
        {
            bidAppService.DeleteBid(id);
        }

        [HttpGet]
        public BidForViewDto GetBidForView(int id)
        {
            return bidAppService.GetBidForView(id);
        }
    }
}
