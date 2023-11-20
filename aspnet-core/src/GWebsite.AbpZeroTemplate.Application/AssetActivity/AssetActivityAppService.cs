using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities;
using GWebsite.AbpZeroTemplate.Application.Share.AssetActivities.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.AssetActivities
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
    public class AssetActivityAppService : GWebsiteAppServiceBase, IAssetActivityAppService
    {
        private readonly IRepository<AssetActivity> assetActivityRepository;

        public AssetActivityAppService(IRepository<AssetActivity> assetActivityRepository)
        {
            this.assetActivityRepository = assetActivityRepository;
        }

        #region Public Method

        public void CreateOrEditAssetActivity(AssetActivityInput assetActivityInput)
        {
            if (assetActivityInput.Id == 0)
            {
                Create(assetActivityInput);
            }
            else
            {
                Update(assetActivityInput);
            }
        }

        public void DeleteAssetActivity(int id)
        {
            var assetActivityEntity = assetActivityRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetActivityEntity != null)
            {
                assetActivityEntity.IsDelete = true;
                assetActivityRepository.Update(assetActivityEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public AssetActivityInput GetAssetActivityForEdit(int id)
        {
            var assetActivityEntity = assetActivityRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetActivityEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetActivityInput>(assetActivityEntity);
        }

        public AssetActivityForViewDto GetAssetActivityForView(int id)
        {
            var assetActivityEntity = assetActivityRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetActivityEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetActivityForViewDto>(assetActivityEntity);
        }

        public PagedResultDto<AssetActivityDto> GetAssetActivities(AssetActivityFilter input)
        {
            var query = assetActivityRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.AssetActivityType != null)
            {
                query = query.Where(x => x.AssetActivityType.ToLower().Equals(input.AssetActivityType));
            }

            if (input.InvestmentType != null)
            {
                query = query.Where(x => x.InvestmentType.ToLower().Equals(input.InvestmentType));
            }

            if (input.AssetId != null)
            {
                query = query.Where(x => x.AssetId.ToLower().Equals(input.AssetId));
            }

            /*
            if (input.StartingExecutionTime && input.EndingExecutionTime)
            {
                query = query.Where(x => x.ExecutionTime >= input.StartingExecutionTime && x.ExecutionTime <= input.EndingExecutionTime);
            }
            */

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            // var items = query.PageBy(input).ToList();
            var items = query.ToList();

            // result
            return new PagedResultDto<AssetActivityDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AssetActivityDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(AssetActivityInput assetActivityInput)
        {
            var assetActivityEntity = ObjectMapper.Map<AssetActivity>(assetActivityInput);
            SetAuditInsert(assetActivityEntity);
            assetActivityRepository.Insert(assetActivityEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(AssetActivityInput assetActivityInput)
        {
            var assetActivityEntity = assetActivityRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == assetActivityInput.Id);
            if (assetActivityEntity == null)
            {
            }
            ObjectMapper.Map(assetActivityInput, assetActivityEntity);
            SetAuditEdit(assetActivityEntity);
            assetActivityRepository.Update(assetActivityEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
