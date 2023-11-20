using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Bids;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Projects;
using GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace GWebsite.AbpZeroTemplate.Web.Core.Bids
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Bid)]
    public class BidAppService : GWebsiteAppServiceBase, IBidAppService
    {
        private readonly IRepository<Bid> bidRepository;
        private readonly IRepository<Project> projectRepository;

        public BidAppService(IRepository<Bid> bidRepository, IRepository<Project> projectRepository)
        {
            this.bidRepository = bidRepository;
            this.projectRepository = projectRepository;
        }

        #region Public Method

        public void CreateOrEditBid(BidInput bidInput)
        {
            if (bidInput.Id == 0)
            {
                Create(bidInput);
            }
            else
            {
                Update(bidInput);
            }
        }

        public void DeleteBid(int id)
        {
            var bidEntity = bidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (bidEntity != null)
            {
                bidEntity.IsDelete = true;
                bidRepository.Update(bidEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public BidInput GetBidForEdit(int id)
        {
            var bidEntity = bidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (bidEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<BidInput>(bidEntity);
        }

        //public async Task<BidOutput> GetBidForEditAsync(NullableIdDto input)
        //{
        //    Bid hoSoThau = null;
        //    if (input.Id.HasValue && input.Id.Value > 0)
        //    {
        //        hoSoThau = await bidRepository.GetAsync(input.Id.Value);
        //    }
        //    var output = new BidOutput();

        //    output.Bid = hoSoThau != null
        //        ? ObjectMapper.Map<BidDto>(hoSoThau)
        //        : new BidDto();

        //    output.Bids = await bidRepository.GetAll()
        //        .Select(c => new ComboboxItemDto(c.Id.ToString(), c.MaHoSo))
        //        .ToListAsync();

        //    return output;
        //}

        public async Task<ProjectOutput> GetProjectComboboxForEditAsync(NullableIdDto input)
        {
            Project duAn = null;
            if (input.Id.HasValue && input.Id.Value > 0)
            {
                duAn = await projectRepository.GetAsync(input.Id.Value);
            }
            var output = new ProjectOutput();

            output.Project = duAn != null
                ? ObjectMapper.Map<ProjectDto>(duAn)
                : new ProjectDto();

            output.Projects = await projectRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.ProjectName))
                .ToListAsync();

            return output;
        }

        public BidForViewDto GetBidForView(int id)
        {
            var bidEntity = bidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (bidEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<BidForViewDto>(bidEntity);
        }

        public PagedResultDto<BidDto> GetBids(BidFilter input)
        {
            var query = bidRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.BidCode != null)
            {
                query = query.Where(x => x.BidCode.ToLower().Equals(input.BidCode));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<BidDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<BidDto>(item)).ToList());
        }

        public async Task<ListResultDto<ProjectDto>> GetProjectRelateToBids()
        {

            var items = await projectRepository.GetAllListAsync();

            return new ListResultDto<ProjectDto>(
                items.Select(item => ObjectMapper.Map<ProjectDto>(item)).ToList());

        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Bid_Create)]
        private void Create(BidInput bidInput)
        {
            var bidEntity = ObjectMapper.Map<Bid>(bidInput);
            SetAuditInsert(bidEntity);
            bidRepository.Insert(bidEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Bid_Edit)]
        private void Update(BidInput bidInput)
        {
            var bidEntity = bidRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == bidInput.Id);
            if (bidEntity == null)
            {
            }
            ObjectMapper.Map(bidInput, bidEntity);
            SetAuditEdit(bidEntity);
            bidRepository.Update(bidEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
