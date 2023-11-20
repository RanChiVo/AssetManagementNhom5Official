using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlanDetails;
using GWebsite.AbpZeroTemplate.Application.Share.ShoppingPlanDetails.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace GWebsite.AbpZeroTemplate.Web.Core.ShoppingPlansDetails
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail)]
    public class ShoppingPlanDetailAppService : GWebsiteAppServiceBase, IShoppingPlanDetailAppService
    {
        private readonly IRepository<ShoppingPlanDetail> shoppingPlanRepository;

        public ShoppingPlanDetailAppService(IRepository<ShoppingPlanDetail> shoppingPlanRepository)
        {
            this.shoppingPlanRepository = shoppingPlanRepository;
        }

        #region Public Method

        public void CreateOrEditShoppingPlanDetail(ShoppingPlanDetailInput shoppingPlanInput)
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

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail_Delete)]
        public void DeleteShoppingPlanDetail(int id)
        {
            var shoppingPlanEntity = shoppingPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (shoppingPlanEntity != null)
            {
                shoppingPlanEntity.IsDelete = true;
                shoppingPlanRepository.Update(shoppingPlanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ShoppingPlanDetailInput GetShoppingPlanDetailForEdit(int id)
        {
            var shoppingPlanEntity = shoppingPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (shoppingPlanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ShoppingPlanDetailInput>(shoppingPlanEntity);
        }

        public PagedResultDto<ShoppingPlanDetailDto> GetShoppingPlanDetails(ShoppingPlanDetailFilter input)
        {
            var query = shoppingPlanRepository.GetAll().Where(x => !x.IsDelete);
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
            return new PagedResultDto<ShoppingPlanDetailDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ShoppingPlanDetailDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail_Create)]
        private void Create(ShoppingPlanDetailInput shoppingPlanInput)
        {
            var shoppingPlanEntity = ObjectMapper.Map<ShoppingPlanDetail>(shoppingPlanInput);
            SetAuditInsert(shoppingPlanEntity);
            shoppingPlanRepository.Insert(shoppingPlanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ShoppingPlanDetail_Edit)]
        private void Update(ShoppingPlanDetailInput shoppingPlanInput)
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
