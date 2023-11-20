using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Bids
{
    public interface IBidAppService
    {
        void CreateOrEditBid(BidInput bidInput);
        BidInput GetBidForEdit(int id);
        void DeleteBid(int id);
        PagedResultDto<BidDto> GetBids(BidFilter input);
        BidForViewDto GetBidForView(int id);
        Task<ListResultDto<ProjectDto>> GetProjectRelateToBids();
        //Task<BidOutput> GetBidForEditAsync(NullableIdDto input);
        Task<ProjectOutput> GetProjectComboboxForEditAsync(NullableIdDto input);
    }
}
