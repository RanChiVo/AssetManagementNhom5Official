using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.BidManagers;
using GWebsite.AbpZeroTemplate.Application.Share.BidManagers.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.BidManagers
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_BidManager9)]
    public class BidManagerAppService : GWebsiteAppServiceBase, IBidManagerAppService
    {
        private readonly IRepository<BidManager_9> BidManagerRepository;

        public BidManagerAppService(IRepository<BidManager_9> BidManagerRepository)
        {
            this.BidManagerRepository = BidManagerRepository;
        }

        #region Public Method

        public void CreateOrEditBidManager(BidManagerInput BidManagerInput)
        {
            if (BidManagerInput.Id == 0)
            {
                Create(BidManagerInput);
            }
            else
            {
                Update(BidManagerInput);
            }
        }

        public void DeleteBidManager(int id)
        {
            var BidManagerEntity = BidManagerRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (BidManagerEntity != null)
            {
                BidManagerEntity.IsDelete = true;
                BidManagerRepository.Update(BidManagerEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public BidManagerInput GetBidManagerForEdit(int id)
        {
            var BidManagerEntity = BidManagerRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (BidManagerEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<BidManagerInput>(BidManagerEntity);
        }


        public BidManagerForViewDto GetBidManagerForView(int id)
        {
            var BidManagerEntity = BidManagerRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (BidManagerEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<BidManagerForViewDto>(BidManagerEntity);
        }

        public PagedResultDto<BidManagerDto> GetBidManagers(BidManagerFilter input)
        {
            var query = BidManagerRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.HangMucThau != null)
            {
                query = query.Where(x => x.HangMucThau.ToLower().Equals(input.HangMucThau));
            }
            if (input.HinhThucThau != null)
            {
                query = query.Where(x => x.HinhThucThau.ToLower().Equals(input.HinhThucThau));
            }
            if (input.MaCongTrinh != null)
            {
                query = query.Where(x => x.MaCongTrinh.ToLower().Equals(input.MaCongTrinh));
            }
            if (input.MaHoSoThau != null)
            {
                query = query.Where(x => x.MaHoSoThau.ToLower().Equals(input.MaHoSoThau));
            }
            if (input.NgayHetHanNopHSThau != null)
            {
                query = query.Where(x => x.NgayHetHanNopHSThau.ToLower().Equals(input.NgayHetHanNopHSThau));
            }
            if (input.NgayNhanHSThau != null)
            {
                query = query.Where(x => x.NgayNhanHSThau.ToLower().Equals(input.NgayNhanHSThau));
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
            return new PagedResultDto<BidManagerDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<BidManagerDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_BidManager9_Create)]
        private void Create(BidManagerInput BidManagerInput)
        {
            var BidManagerEntity = ObjectMapper.Map<BidManager_9>(BidManagerInput);
            SetAuditInsert(BidManagerEntity);
            BidManagerRepository.Insert(BidManagerEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_BidManager9_Edit)]
        private void Update(BidManagerInput BidManagerInput)
        {
            var BidManagerEntity = BidManagerRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == BidManagerInput.Id);
            if (BidManagerEntity == null)
            {
            }
            ObjectMapper.Map(BidManagerInput, BidManagerEntity);
            SetAuditEdit(BidManagerEntity);
            BidManagerRepository.Update(BidManagerEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
