using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlanDetails;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlanDetails.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.ConstructionPlanDetails
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail)]
    public class ConstructionPlanDetailAppService : GWebsiteAppServiceBase, IConstructionPlanDetailAppService
    {
        private readonly IRepository<ConstructionPlanDetail> constructionPlanRepository;

        public ConstructionPlanDetailAppService(IRepository<ConstructionPlanDetail> constructionPlanRepository)
        {
            this.constructionPlanRepository = constructionPlanRepository;
        }

        #region Public Method

        public void CreateOrEditConstructionPlanDetail(ConstructionPlanDetailInput constructionPlanInput)
        {
            if (constructionPlanInput.Id == 0)
            {
                Create(constructionPlanInput);
            }
            else
            {
                Update(constructionPlanInput);
            }
        }

        public void DeleteConstructionPlanDetail(int id)
        {
            var constructionPlanEntity = constructionPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (constructionPlanEntity != null)
            {
                constructionPlanEntity.IsDelete = true;
                constructionPlanRepository.Update(constructionPlanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ConstructionPlanDetailInput GetConstructionPlanDetailForEdit(int id)
        {
            var constructionPlanEntity = constructionPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (constructionPlanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ConstructionPlanDetailInput>(constructionPlanEntity);
        }

        public PagedResultDto<ConstructionPlanDetailDto> GetConstructionPlanDetails(ConstructionPlanDetailFilter input)
        {
            var query = constructionPlanRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.MaKeHoach != null)
            {
                query = query.Where(x => x.MaKeHoach.ToLower().Equals(input.MaKeHoach));
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
            return new PagedResultDto<ConstructionPlanDetailDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ConstructionPlanDetailDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail_Create)]
        private void Create(ConstructionPlanDetailInput constructionPlanInput)
        {
            var constructionPlanEntity = ObjectMapper.Map<ConstructionPlanDetail>(constructionPlanInput);
            SetAuditInsert(constructionPlanEntity);
            constructionPlanRepository.Insert(constructionPlanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail_Edit)]
        private void Update(ConstructionPlanDetailInput constructionPlanInput)
        {
            var constructionPlanEntity = constructionPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == constructionPlanInput.Id);
            if (constructionPlanEntity == null)
            {
            }
            ObjectMapper.Map(constructionPlanInput, constructionPlanEntity);
            SetAuditEdit(constructionPlanEntity);
            constructionPlanRepository.Update(constructionPlanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
