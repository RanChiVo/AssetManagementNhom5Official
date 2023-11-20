using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlans;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlans.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace GWebsite.AbpZeroTemplate.Web.Core.ShoppingPlans
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_ShoppingPlan)]
    public class ShoppingPlanAppService : GWebsiteAppServiceBase, IShoppingPlanAppService
    {
        private readonly IRepository<ShoppingPlan> shoppingPlanRepository;

        public ShoppingPlanAppService(IRepository<ShoppingPlan> shoppingPlanRepository)
        {
            this.shoppingPlanRepository = shoppingPlanRepository;
        }

        #region Public Method

        public void CreateOrEditShoppingPlan(ShoppingPlanInput shoppingPlanInput)
        {
            if (shoppingPlanInput.Id == 0)
            {
                Create(shoppingPlanInput);
            }
            else
            {
                Update(shoppingPlanInput);
            }
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ShoppingPlan_Delete)]
        public void DeleteShoppingPlan(int id)
        {
            var shoppingPlanEntity = shoppingPlanRepository.GetAll().Where(x => !x.IsDelete && x.TinhTrang != "Đã Duyệt").SingleOrDefault(x => x.Id == id);
            if (shoppingPlanEntity != null)
            {
                shoppingPlanEntity.IsDelete = true;
                shoppingPlanRepository.Update(shoppingPlanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ShoppingPlanInput GetShoppingPlanForEdit(int id)
        {
            var shoppingPlanEntity = shoppingPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (shoppingPlanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ShoppingPlanInput>(shoppingPlanEntity);
        }

        public ShoppingPlanForViewDto GetShoppingPlanForView(int id)
        {
            var shoppingPlanEntity = shoppingPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (shoppingPlanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ShoppingPlanForViewDto>(shoppingPlanEntity);
        }

        public PagedResultDto<ShoppingPlanDto> GetShoppingPlans(ShoppingPlanFilter input)
        {
            var query = shoppingPlanRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.KhuVuc != null)
            {
                query = query.Where(x => x.KhuVuc.ToLower().Equals(input.KhuVuc));
            }

            if (input.PhongBan != null)
            {
                query = query.Where(x => x.PhongBan.ToLower().Equals(input.PhongBan));
            }

            if(input.MaKeHoach != null)
            {
                query = query.Where(x => x.MaKeHoach.ToLower().Equals(input.MaKeHoach));
            }

            if(input.TinhTrang != null)
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
            return new PagedResultDto<ShoppingPlanDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ShoppingPlanDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ShoppingPlan_Create)]
        private void Create(ShoppingPlanInput shoppingPlanInput)
        {
            var shoppingPlanEntity = ObjectMapper.Map<ShoppingPlan>(shoppingPlanInput);
            SetAuditInsert(shoppingPlanEntity);
            shoppingPlanRepository.Insert(shoppingPlanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ShoppingPlan_Edit)]
        private void Update(ShoppingPlanInput shoppingPlanInput)
        {
            var shoppingPlanEntity = shoppingPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == shoppingPlanInput.Id);
            if (shoppingPlanEntity == null)
            {
            }
            ObjectMapper.Map(shoppingPlanInput, shoppingPlanEntity);
            SetAuditEdit(shoppingPlanEntity);
            shoppingPlanRepository.Update(shoppingPlanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
