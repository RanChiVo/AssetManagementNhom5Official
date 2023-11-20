using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ExportingUsedAssets;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.ExportingUsedAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_ExportingUsedAsset)]
    public class ExportingUsedAssetAppService : GWebsiteAppServiceBase, IExportingUsedAssetAppService
    {
        private readonly IRepository<ExportingUsedAsset> ExportingUsedAssetRepository;

        public ExportingUsedAssetAppService
            (IRepository<ExportingUsedAsset> ExportingUsedAssetRepository)
        {
            this.ExportingUsedAssetRepository = ExportingUsedAssetRepository;
        }

        #region Public Method

        public void CreateOrEditExportingUsedAsset(ExportingUsedAssetInput ExportingUsedAssetInput)
        {
            if (ExportingUsedAssetInput.Id == 0)
            {
                Create(ExportingUsedAssetInput);
            }
            else
            {
                Update(ExportingUsedAssetInput);
            }
        }

        public void DeleteExportingUsedAsset(int id)
        {
            var ExportingUsedAssetEntity = ExportingUsedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ExportingUsedAssetEntity != null)
            {
                ExportingUsedAssetEntity.IsDelete = true;
                ExportingUsedAssetRepository.Update(ExportingUsedAssetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ExportingUsedAssetInput GetExportingUsedAssetForEdit(int id)
        {
            var ExportingUsedAssetEntity = ExportingUsedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ExportingUsedAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ExportingUsedAssetInput>(ExportingUsedAssetEntity);
        }

        public ExportingUsedAssetForViewDto GetExportingUsedAssetForView(int id)
        {
            var ExportingUsedAssetEntity = ExportingUsedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ExportingUsedAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ExportingUsedAssetForViewDto>(ExportingUsedAssetEntity);
        }

        public PagedResultDto<ExportingUsedAssetDto> GetExportingUsedAssets(ExportingUsedAssetFilter input)
        {
            var query = ExportingUsedAssetRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.AssetId != null)
            {
                query = query.Where(x => x.AssetId.ToLower().Equals(input.AssetId));
            }
            if (input.UsingUnit != null)
            {
                query = query.Where(x => x.UsingUnit.Equals(input.UsingUnit));
            }

            if (input.User != null)
            {
                query = query.Where(x => x.User.ToLower().Equals(input.User));
            }
            if (input.ExportingDay != null)
            {
                query = query.Where(x => x.ExportingDay.Equals(input.ExportingDay));
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
            return new PagedResultDto<ExportingUsedAssetDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ExportingUsedAssetDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ExportingUsedAsset_Create)]
        private void Create(ExportingUsedAssetInput ExportingUsedAssetInput)
        {
            var ExportingUsedAssetEntity = ObjectMapper.Map<ExportingUsedAsset>(ExportingUsedAssetInput);
            SetAuditInsert(ExportingUsedAssetEntity);
            ExportingUsedAssetRepository.Insert(ExportingUsedAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ExportingUsedAsset_Edit)]
        private void Update(ExportingUsedAssetInput ExportingUsedAssetInput)
        {
            var ExportingUsedAssetEntity = ExportingUsedAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == ExportingUsedAssetInput.Id);
            if (ExportingUsedAssetEntity == null)
            {
            }
            ObjectMapper.Map(ExportingUsedAssetInput, ExportingUsedAssetEntity);
            SetAuditEdit(ExportingUsedAssetEntity);
            ExportingUsedAssetRepository.Update(ExportingUsedAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}