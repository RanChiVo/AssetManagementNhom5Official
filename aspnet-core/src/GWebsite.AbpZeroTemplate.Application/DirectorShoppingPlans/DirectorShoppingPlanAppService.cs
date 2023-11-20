using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.DirectorShoppingPlans;
using GWebsite.AbpZeroTemplate.Application.Share.DirectorShoppingPlans.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.DirectorShoppingPlans
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_DirectorShoppingPlan)]
    public class DirectorShoppingPlanAppService : GWebsiteAppServiceBase, IDirectorShoppingPlanAppService
    {
        private readonly IRepository<DirectorShoppingPlan> directorShoppingPlanRepository;

        public DirectorShoppingPlanAppService(IRepository<DirectorShoppingPlan> directorShoppingPlanRepository)
        {
            this.directorShoppingPlanRepository = directorShoppingPlanRepository;
        }

        #region Public Method

        public void CreateOrEditDirectorShoppingPlan(DirectorShoppingPlanInput directorShoppingPlanInput)
        {
            if (directorShoppingPlanInput.Id == 0)
            {
                Create(directorShoppingPlanInput);
            }
            else
            {
                Update(directorShoppingPlanInput);
            }
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_DirectorShoppingPlan_Delete)]
        public void DeleteDirectorShoppingPlan(int id)
        {
            var directorShoppingPlanEntity = directorShoppingPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (directorShoppingPlanEntity != null)
            {
                directorShoppingPlanEntity.IsDelete = true;
                directorShoppingPlanRepository.Update(directorShoppingPlanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public DirectorShoppingPlanInput GetDirectorShoppingPlanForEdit(int id)
        {
            var directorShoppingPlanEntity = directorShoppingPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (directorShoppingPlanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DirectorShoppingPlanInput>(directorShoppingPlanEntity);
        }

        public DirectorShoppingPlanForViewDto GetDirectorShoppingPlanForView(int id)
        {
            var directorShoppingPlanEntity = directorShoppingPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (directorShoppingPlanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DirectorShoppingPlanForViewDto>(directorShoppingPlanEntity);
        }

        public PagedResultDto<DirectorShoppingPlanDto> GetDirectorShoppingPlans(DirectorShoppingPlanFilter input)
        {
            var query = directorShoppingPlanRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.KhuVuc != null)
            {
                query = query.Where(x => x.KhuVuc.ToLower().Equals(input.KhuVuc));
            }

            if (input.PhongBan != null)
            {
                query = query.Where(x => x.PhongBan.ToLower().Equals(input.PhongBan));
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
            return new PagedResultDto<DirectorShoppingPlanDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<DirectorShoppingPlanDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_DirectorShoppingPlan_Create)]
        private void Create(DirectorShoppingPlanInput directorShoppingPlanInput)
        {
            var directorShoppingPlanEntity = ObjectMapper.Map<DirectorShoppingPlan>(directorShoppingPlanInput);
            SetAuditInsert(directorShoppingPlanEntity);
            directorShoppingPlanRepository.Insert(directorShoppingPlanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_DirectorShoppingPlan_Edit)]
        private void Update(DirectorShoppingPlanInput directorShoppingPlanInput)
        {
            var directorShoppingPlanEntity = directorShoppingPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == directorShoppingPlanInput.Id);
            if (directorShoppingPlanEntity == null)
            {
            }
            ObjectMapper.Map(directorShoppingPlanInput, directorShoppingPlanEntity);
            SetAuditEdit(directorShoppingPlanEntity);
            directorShoppingPlanRepository.Update(directorShoppingPlanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
