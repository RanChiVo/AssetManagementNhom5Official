using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets_05;
using GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Assets_05.Warranty_Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes_05.Dto;
using GWebsite.AbpZeroTemplate.Core;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Assets_05
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset_05)]

    public class AssetAppService_05 : GWebsiteAppServiceBase, IAssetAppService_05
    {
        private readonly IRepository<Asset_05> assetRepository;
        private readonly IRepository<AssetGroup_05> assetGroupRepository;
        private readonly IRepository<AssetType_05> assetTypeRepository;
        private readonly IRepository<Warranty_05> warrantyRepository;
        private readonly IRepository<PurchaseOder_05> purchaseRepository;

        public AssetAppService_05(IRepository<Asset_05> assetRepository, 
            IRepository<AssetGroup_05> assetGroupRepository, IRepository<AssetType_05> assetTypeRepository,
            IRepository<Warranty_05> warrantyRepository, IRepository<PurchaseOder_05> purchaseRepository)
        {
            this.assetRepository = assetRepository;
            this.assetGroupRepository = assetGroupRepository;
            this.assetTypeRepository = assetTypeRepository;
            this.warrantyRepository = warrantyRepository;
            this.purchaseRepository = purchaseRepository;
        }
        
        #region Public Method

        public void CreateOrEditAsset(AssetDto_05 assetInput)
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

        public void DeleteAsset(string id)
        {
            var assetEntity = assetRepository.GetAll()
                                             .Where(x => !x.IsDelete)
                                             .SingleOrDefault(x => x.AssetId == id);
            if (assetEntity != null)
            {
                assetEntity.IsDelete = true;
                assetRepository.Update(assetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public AssetDto_05 GetAssetForEdit(string id)
        {
            AssetDto_05 assetDto = null;
            var assetEntity = assetRepository.GetAll()
                                             .Where(x => !x.IsDelete)
                                             .SingleOrDefault(x => x.AssetId == id);
            if (assetEntity == null)
            {
                assetDto = new AssetDto_05();
                return assetDto;
            }
            return ObjectMapper.Map<AssetDto_05>(assetEntity);
        }

        public AssetForViewDto_05 GetAssetForView(string id)
        {
            var assetEntity = assetRepository.GetAll()
                                             .Where(x => !x.IsDelete)
                                             .SingleOrDefault(x => x.AssetId == id);
            if (assetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetForViewDto_05>(assetEntity);
        }

        public AssetOutput_05 GetAssetEdit(string id)
        {
            Asset_05 asset = null;
            var output = new AssetOutput_05();
            var selectedAssetId = 1;
            var selectedAssetGroupId = "";
            var selectedSupplierId = "";

            asset = assetRepository.GetAll()
                                   .Where(x => !x.IsDelete)
                                   .SingleOrDefault(x => x.AssetId == id);

            if(asset != null)
            {
                output.Asset = ObjectMapper.Map<AssetDto_05>(asset);
                selectedAssetId = asset.AssetTypeId;
                selectedAssetGroupId = asset.AssetGroupId;
                selectedSupplierId = asset.PurchaseOderId;
            }
            else
            {
                output.AssetGroup = new AssetGroupDto_05();
                output.Asset = new AssetDto_05();
            }

            output.AssetGroups = assetGroupRepository.GetAll()
                .Where(x => !x.IsDelete)
                .Select(c => new ComboboxItemDto(c.AssetGroupId, c.Name)
                { IsSelected = selectedAssetGroupId == c.AssetGroupId })
                .ToList();

            output.AssetTypes = assetTypeRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.Name)
                { IsSelected = selectedAssetId == c.Id })
                .ToList();

            output.PurchaseOders = purchaseRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.Supplier)
                { IsSelected = selectedSupplierId == c.PONumber})
               .ToList();
            return output;
        }

        public PagedResultDto<AssetDto_05> GetAssets(AssetFilter_05 input)
        {
            var assetEntity = assetRepository.GetAll().Where(x => !x.IsDelete);
            var assetTypeEntity = assetTypeRepository.GetAll();
            var assetGroupEntity = assetGroupRepository.GetAll();
            var orderPurchaseEntity = purchaseRepository.GetAll();
            var assetDetailEntity = (from ta in assetEntity
                                                 join a in assetTypeEntity on ta.AssetTypeId equals a.Id
                                                 join ag in assetGroupEntity on ta.AssetGroupId equals ag.AssetGroupId
                                                 join at in assetTypeEntity on ta.AssetTypeId equals at.Id
                                                 join op in orderPurchaseEntity on ta.PurchaseOderId equals op.PONumber
                                                 select new AssetDto_05
                                                 {
                                                     Id = ta.Id,
                                                     AssetId = ta.AssetId,
                                                     Name = ta.Name,
                                                     Description = ta.Description,
                                                     DateAdded = ta.DateAdded,
                                                     TotalMonthDepreciation = ta.TotalMonthDepreciation,
                                                     DepreciationRate = ta.DepreciationRate,
                                                     Quantity = ta.Quantity,
                                                     OriginalPrice = ta.OriginalPrice,
                                                     DepreciationValue = ta.DepreciationValue,
                                                     Note = ta.Note,
                                                     IsActive = ta.IsActive,
                                                     LinkofImage = ta.LinkofImage,
                                                     NameAssetGroup = ag.Name,
                                                     NameAssetType = ag.Name,
                                                     Supplier = op.Supplier,
                                                 });

            
            if (input.Name != null)
            {
                assetDetailEntity = assetDetailEntity.Where(x => x.Name.ToLower().Equals(input.Name));
            }

            var totalCount = assetDetailEntity.Count();

            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                assetDetailEntity = assetDetailEntity.OrderBy(input.Sorting);
            }

            var items = assetDetailEntity.PageBy(input).ToList();

            return new PagedResultDto<AssetDto_05>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AssetDto_05>(item)).ToList());
        }

        public PagedResultDto<WarrantyDto> GetWarrantysForView(string assetId)
        {
            var query = warrantyRepository.GetAll().Where(x=> x.AssetId == assetId);

            var totalCount = query.Count();

            var items = query.ToList();

            return new PagedResultDto<WarrantyDto>(
             totalCount,
             items.Select(item => ObjectMapper.Map<WarrantyDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset_05_Create)]

        private void Create(AssetDto_05 assetInput)
        {
            CreateIdAuto(assetInput);
            var assetEntity = ObjectMapper.Map<Asset_05>(assetInput);
            SetAuditInsert(assetEntity);
            assetRepository.Insert(assetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset_05_Edit)]

        private void Update(AssetDto_05 assetInput)
        {
            var assetEntity = assetRepository.GetAll()
                                             .Where(x => !x.IsDelete)
                                             .SingleOrDefault(x => x.AssetId == assetInput.AssetId);
            if (assetEntity != null)
            {
                ObjectMapper.Map(assetInput, assetEntity);
                SetAuditEdit(assetEntity);
                assetRepository.Update(assetEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        private void CreateIdAuto(AssetDto_05 assetInput)
        {
            int count = assetRepository.GetAll().Count();
            string tempID = "";
            string AssetID = "";

            count += 1;

            if (assetInput.AssetTypeId == 1)
            {
                AssetID += "T";
            }
            else
            {
                AssetID += "C";
            }

            tempID = count.ToString();

            while (tempID.Length < 6)
            {
                tempID = "0" + tempID;
            }

            assetInput.AssetId = AssetID + assetInput.AssetGroupId
                                                     .Substring(3) 
                                                     + tempID;
        }
        #endregion
    }
}
