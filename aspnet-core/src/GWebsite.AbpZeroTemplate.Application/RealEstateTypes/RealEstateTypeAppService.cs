using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstateTypes;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstateTypes.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.RealEstateTypes
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_RealEstateType9)]
    public class RealEstateTypeAppService : GWebsiteAppServiceBase, IRealEstateTypeAppService
    {
        private readonly IRepository<RealEstateType_9> RealEstateTypeRepository;

        public RealEstateTypeAppService(IRepository<RealEstateType_9> RealEstateTypeRepository)
        {
            this.RealEstateTypeRepository = RealEstateTypeRepository;
        }

        #region Public Method

        public void CreateOrEditRealEstateType(RealEstateTypeInput_9 RealEstateTypeInput)
        {
            if (RealEstateTypeInput.Id == 0)
            {
                Create(RealEstateTypeInput);
            }
            else
            {
                Update(RealEstateTypeInput);
            }
        }

        public void DeleteRealEstateType(int id)
        {
            var RealEstateTypeEntity = RealEstateTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (RealEstateTypeEntity != null)
            {
                RealEstateTypeEntity.IsDelete = true;
                RealEstateTypeRepository.Update(RealEstateTypeEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public RealEstateTypeInput_9 GetRealEstateTypeForEdit(int id)
        {
            var RealEstateTypeEntity = RealEstateTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (RealEstateTypeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RealEstateTypeInput_9>(RealEstateTypeEntity);
        }

        public RealEstateTypeForViewDto_9 GetRealEstateTypeForView(int id)
        {
            var RealEstateTypeEntity = RealEstateTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (RealEstateTypeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RealEstateTypeForViewDto_9>(RealEstateTypeEntity);
        }

        public PagedResultDto<RealEstateTypeDto_9> GetRealEstateTypes(RealEstateTypeFilter_9 input)
        {
            var query = RealEstateTypeRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaLoaiBatDongSan != null)
            {
                query = query.Where(x => x.MaLoaiBatDongSan.ToLower().Equals(input.MaLoaiBatDongSan));
            }
            if (input.TenLoaiBatDongSan != null)
            {
                query = query.Where(x => x.TenLoaiBatDongSan.ToLower().Equals(input.TenLoaiBatDongSan));
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
            return new PagedResultDto<RealEstateTypeDto_9>(
                totalCount,
                items.Select(item => ObjectMapper.Map<RealEstateTypeDto_9>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_RealEstateType9_Create)]
        private void Create(RealEstateTypeInput_9 RealEstateTypeInput)
        {
            var RealEstateTypeEntity = ObjectMapper.Map<RealEstateType_9>(RealEstateTypeInput);
            SetAuditInsert(RealEstateTypeEntity);
            RealEstateTypeRepository.Insert(RealEstateTypeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_RealEstateType9_Edit)]
        private void Update(RealEstateTypeInput_9 RealEstateTypeInput)
        {
            var RealEstateTypeEntity = RealEstateTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == RealEstateTypeInput.Id);
            if (RealEstateTypeEntity == null)
            {
            }
            ObjectMapper.Map(RealEstateTypeInput, RealEstateTypeEntity);
            SetAuditEdit(RealEstateTypeEntity);
            RealEstateTypeRepository.Update(RealEstateTypeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
