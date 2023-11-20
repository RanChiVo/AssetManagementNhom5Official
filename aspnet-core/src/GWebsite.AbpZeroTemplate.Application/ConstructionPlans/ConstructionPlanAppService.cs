using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlans;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlans.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace GWebsite.AbpZeroTemplate.Web.Core.ConstructionPlans
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_ConstructionPlan)]
    public class ConstructionPlanAppService : GWebsiteAppServiceBase, IConstructionPlanAppService
    {
        private readonly IRepository<ConstructionPlan> constructionPlanRepository;

        public ConstructionPlanAppService(IRepository<ConstructionPlan> constructionPlanRepository)
        {
            this.constructionPlanRepository = constructionPlanRepository;
        }

        #region Public Method

        public void CreateOrEditConstructionPlan(ConstructionPlanInput constructionPlanInput)
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

        public void DeleteConstructionPlan(int id)
        {
            var constructionPlanEntity = constructionPlanRepository.GetAll().Where(x => !x.IsDelete && x.TinhTrang != "Đã Duyệt").SingleOrDefault(x => x.Id == id);
            if (constructionPlanEntity != null)
            {
                constructionPlanEntity.IsDelete = true;
                constructionPlanRepository.Update(constructionPlanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ConstructionPlanInput GetConstructionPlanForEdit(int id)
        {
            var constructionPlanEntity = constructionPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (constructionPlanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ConstructionPlanInput>(constructionPlanEntity);
        }

        public ConstructionPlanForViewDto GetConstructionPlanForView(int id)
        {
            var constructionPlanEntity = constructionPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (constructionPlanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ConstructionPlanForViewDto>(constructionPlanEntity);
        }

        public PagedResultDto<ConstructionPlanDto> GetConstructionPlans(ConstructionPlanFilter input)
        {
            var query = constructionPlanRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.KhuVuc != null)
            {
                query = query.Where(x => x.KhuVuc.ToLower().Equals(input.KhuVuc));
            }

            if (input.PhongBan != null)
            {
                query = query.Where(x => x.PhongBan.ToLower().Equals(input.PhongBan));
            }

            if (input.MaKeHoach != null)
            {
                query = query.Where(x => x.MaKeHoach.ToLower().Equals(input.MaKeHoach));
            }

            if (input.TinhTrang != null)
            {
                query = query.Where(x => x.TinhTrang.ToLower().Contains(input.TinhTrang));
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
            return new PagedResultDto<ConstructionPlanDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ConstructionPlanDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail_Create)]
        private void Create(ConstructionPlanInput constructionPlanInput)
        {
            var constructionPlanEntity = ObjectMapper.Map<ConstructionPlan>(constructionPlanInput);
            SetAuditInsert(constructionPlanEntity);
            constructionPlanRepository.Insert(constructionPlanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ConstructionPlanDetail_Edit)]
        private void Update(ConstructionPlanInput constructionPlanInput)
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
