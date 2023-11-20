using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.BidManagers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.BidManagers
{
    public interface IBidManagerAppService
    {
        void CreateOrEditBidManager(BidManagerInput BidManagergInput);
        BidManagerInput GetBidManagerForEdit(int id);
        void DeleteBidManager(int id);
        PagedResultDto<BidManagerDto> GetBidManagers(BidManagerFilter input);
        BidManagerForViewDto GetBidManagerForView(int id);
    }
}
