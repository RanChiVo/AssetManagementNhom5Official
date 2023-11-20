using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.FixedAssets;
using GWebsite.AbpZeroTemplate.Application.Share.FixedAssets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.FixedAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_FixedAsset)]
    public class FixedAssetAppService : GWebsiteAppServiceBase, IFixedAssetAppService
    {
        private readonly IRepository<FixedAsset> fixedAssetRepository;

        public FixedAssetAppService(IRepository<FixedAsset> fixedAssetRepository)
        {
            this.fixedAssetRepository = fixedAssetRepository;
        }

        #region Public Method

        public void CreateOrEditFixedAsset(FixedAssetInput fixedAssetInput)
        {
            if (fixedAssetInput.Id == 0)
            {
                Create(fixedAssetInput);
            }
            else
            {
                Update(fixedAssetInput);
            }
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_FixedAsset_Delete)]
        public void DeleteFixedAsset(int id)
        {
            var fixedAssetEntity = fixedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (fixedAssetEntity != null)
            {
                fixedAssetEntity.IsDelete = true;
                fixedAssetRepository.Update(fixedAssetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public FixedAssetInput GetFixedAssetForEdit(int id)
        {
            var fixedAssetEntity = fixedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (fixedAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<FixedAssetInput>(fixedAssetEntity);
        }

        public FixedAssetForViewDto GetFixedAssetForView(int id)
        {
            var fixedAssetEntity = fixedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (fixedAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<FixedAssetForViewDto>(fixedAssetEntity);
        }

        public PagedResultDto<FixedAssetDto> GetFixedAssets(FixedAssetFilter input)
        {
            var query = fixedAssetRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Equals(input.Name));
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
            return new PagedResultDto<FixedAssetDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<FixedAssetDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_FixedAsset_Create)]
        private void Create(FixedAssetInput fixedAssetInput)
        {
            var fixedAssetEntity = ObjectMapper.Map<FixedAsset>(fixedAssetInput);
            SetAuditInsert(fixedAssetEntity);
            fixedAssetRepository.Insert(fixedAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_FixedAsset_Edit)]
        private void Update(FixedAssetInput fixedAssetInput)
        {
            var fixedAssetEntity = fixedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == fixedAssetInput.Id);
            if (fixedAssetEntity == null)
            {
                ObjectMapper.Map(fixedAssetInput, fixedAssetEntity);
                SetAuditEdit(fixedAssetEntity);
                fixedAssetRepository.Update(fixedAssetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }
        
        #endregion
    }
}
