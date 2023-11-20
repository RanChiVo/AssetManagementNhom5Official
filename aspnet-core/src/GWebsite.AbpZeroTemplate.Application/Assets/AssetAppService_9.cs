using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Assets;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Assets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset9)]
    public class AssetAppService_9 : GWebsiteAppServiceBase, IAssetAppService_9
    {
        private readonly IRepository<Asset_test9> assetRepository;

        public AssetAppService_9(IRepository<Asset_test9> assetRepository)
        {
            this.assetRepository = assetRepository;
        }

        #region Public Method

        public void CreateOrEditAsset(AssetInput_9 assetInput)
        {
            if (assetInput.Id == 0)
            {
                Create(assetInput);
            }
            else
            {
                Update(assetInput);
            }
        }

        public void DeleteAsset(int id)
        {
            var assetEntity = assetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetEntity != null)
            {
                assetEntity.IsDelete = true;
                assetRepository.Update(assetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public AssetInput_9 GetAssetForEdit(int id)
        {
            var assetEntity = assetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetInput_9>(assetEntity);
        }

        public AssetInput_9 GetAssetForEditWithMTS(string maTaiSan)
        {
            var assetEntity = assetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.MaTaiSan == maTaiSan);
            if (assetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetInput_9>(assetEntity);
        }

        public AssetForViewDto_9 GetAssetForView(int id)
        {
            var assetEntity = assetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (assetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetForViewDto_9>(assetEntity);
        }

        public PagedResultDto<AssetDto_9> GetAssets(AssetFilter_9 input)
        {
            var query = assetRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.LoaiTaiSan != null)
            {
                query = query.Where(x => x.LoaiTaiSan.ToLower().Equals(input.LoaiTaiSan));
            }
            if (input.MaTaiSan != null)
            {
                query = query.Where(x => x.MaTaiSan.ToLower().Equals(input.MaTaiSan));
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
            return new PagedResultDto<AssetDto_9>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AssetDto_9>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset9_Create)]
        private void Create(AssetInput_9 assetInput)
        {
            var AssetEntity = ObjectMapper.Map<Asset_test9>(assetInput);
            SetAuditInsert(AssetEntity);
            assetRepository.Insert(AssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset9_Edit)]
        private void Update(AssetInput_9 assetInput)
        {
            var assetEntity = assetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == assetInput.Id);
            if (assetEntity == null)
            {
            }
            ObjectMapper.Map(assetInput, assetEntity);
            SetAuditEdit(assetEntity);
            assetRepository.Update(assetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
