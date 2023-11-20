using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.MainDto;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchAssetDto;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchAssetUnitDto;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchUserDto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using GWebsite.AbpZeroTemplate.Core;
using Abp.Extensions;
using Abp.Organizations;
using Abp.Authorization.Users;
using GSoft.AbpZeroTemplate.Authorization.Users;

namespace GWebsite.AbpZeroTemplate.Web.Core.TransferringAssets
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_TransferringAsset)]
    public class TransferringAssetAppService : GWebsiteAppServiceBase, ITransferringAssetAppService
    {
        #region Initial and Constructor
        private readonly IRepository<TransferringAsset> transferringAssetRepository;
        private readonly IRepository<Asset_05> asset_05Repository;
        
        private readonly IRepository<AssetGroup_05> assetGroup_05Repository;
        private readonly IRepository<OrganizationUnit, long> organizationUnitRepository;
        private readonly IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository;
        private readonly IRepository<AssetType_05> assetType_05Repository;
        
        private readonly IRepository<ExportingUsedAsset> exportingUsedAssetRepository;
        private readonly IRepository<PurchaseOder_05> purchaseOrder_05Repository;

        public TransferringAssetAppService(IRepository<TransferringAsset> transferringAssetRepository,
            IRepository<Asset_05> asset_05Repository,
            IRepository<AssetGroup_05> assetGroup_05Repository,
            IRepository<AssetUnit_05> assetUnit_05Repository,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IRepository<AssetType_05> assetType_05Repository,
            IRepository<ExportingUsedAsset> exportingUsedAssetRepository,
            IRepository<PurchaseOder_05> purchaseOrder_05Repository
            )
        {
            this.transferringAssetRepository = transferringAssetRepository;
            this.asset_05Repository = asset_05Repository;
            this.assetGroup_05Repository = assetGroup_05Repository;
            this.organizationUnitRepository = organizationUnitRepository;
            this.userOrganizationUnitRepository = userOrganizationUnitRepository;
            this.assetType_05Repository = assetType_05Repository;
            this.exportingUsedAssetRepository = exportingUsedAssetRepository;
            this.purchaseOrder_05Repository = purchaseOrder_05Repository;
        }
        #endregion

        #region Public Method Main Dto

        public void CreateOrEditTransferringAsset(TransferringAssetDataInput transferringAssetDataInput)
        {
            if (transferringAssetDataInput.Id == 0)
            {
                Create(transferringAssetDataInput);
            }
            else
            {
                Update(transferringAssetDataInput);
            }
        }

        public TransferringAssetDataInput GetTransferringAssetForEdit(int id)
        {
            var transferringAssetEntity = transferringAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (transferringAssetEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TransferringAssetDataInput>(transferringAssetEntity);
        }

        public TransferringAssetDataOutputDetail GetTransferringAssetDetail(int Id)
        {
            var transferringAssetEntity = transferringAssetRepository.GetAll().Where(t => !t.IsDelete);
            var assetEntity = asset_05Repository.GetAll();
            var assetGroupEntity = assetGroup_05Repository.GetAll();
            var assetTypeEntity = assetType_05Repository.GetAll();
            var assetUnitEntity = organizationUnitRepository.GetAll();
            var exportingUsedAssetEntity = exportingUsedAssetRepository.GetAll();
            var transferringAssetDetailEntity = (from ta in transferringAssetEntity
                                                 join a in assetEntity on ta.AssetId equals a.AssetId
                                                 join ag in assetGroupEntity on a.AssetGroupId equals ag.AssetGroupId
                                                 join at in assetTypeEntity on a.AssetTypeId equals at.Id
                                                 join eua in exportingUsedAssetEntity on ta.AssetId equals eua.AssetId
                                                 join an in assetUnitEntity on ta.UsingUnit equals an.Id
                                                 join user in UserManager.Users on ta.UsingUser equals user.Id
                                                 join an1 in assetUnitEntity on ta.ReceivingUnit equals an1.Id
                                                 join user1 in UserManager.Users on ta.ReceivingUser equals user1.Id
                                                 select new TransferringAssetDataOutputDetail
                                                 {
                                                     Id=ta.Id,
                                                     TransferringDate=ta.TransferringDate,
                                                     AssetId=ta.AssetId,
                                                     AssetName=a.Name,
                                                     AssetGroupName=ag.Name,
                                                     AssetTypeName=at.Name,
                                                     Description=a.Description,
                                                     ExportingDay=eua.ExportingDay,
                                                     TotalMonthDepreciation=a.TotalMonthDepreciation,
                                                     OriginalPrice=a.OriginalPrice,
                                                     DepreciationValue=a.DepreciationValue,
                                                     RemainingDepValue=a.RemainingDepValue,
                                                     IsActive=a.IsActive,
                                                     DepreciationStatus=a.DepreciationStatus,
                                                     UsingUnit=an.DisplayName,
                                                     UsingUser=user.Name,
                                                     ReceivingUnit=an1.DisplayName,
                                                     ReceivingUser=user1.Name,
                                                     IsChecked=ta.IsChecked,
                                                     Note=ta.Note
                                                 }).SingleOrDefault(x => x.Id == Id);



            if (transferringAssetDetailEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TransferringAssetDataOutputDetail>(transferringAssetDetailEntity);
        }

        public TransferringAssetDataOutputForInput GetTransferringAssetDetailForInput(string assetId)
        {
            var assetEntity = asset_05Repository.GetAll().Where(t => !t.IsDelete);
            var assetGroupEntity = assetGroup_05Repository.GetAll();
            var assetTypeEntity = assetType_05Repository.GetAll();
            var exportingUsedAssetEntity = exportingUsedAssetRepository.GetAll();
            var assetUserEntity = userOrganizationUnitRepository.GetAll();
            var assetUnitEntity = organizationUnitRepository.GetAll();
            var transferringAssetDetailEntity = (from eua in exportingUsedAssetEntity
                                                 join a in assetEntity on eua.AssetId equals a.AssetId
                                                 join ag in assetGroupEntity on a.AssetGroupId equals ag.AssetGroupId
                                                 join at in assetTypeEntity on a.AssetTypeId equals at.Id
                                                 join an in assetUnitEntity on eua.UsingUnit equals an.DisplayName
                                                 join user in UserManager.Users on eua.User equals user.Name
                                                 select new TransferringAssetDataOutputForInput
                                                 {
                                                     AssetId = a.AssetId,
                                                     AssetName = a.Name,
                                                     AssetGroupName = ag.Name,
                                                     AssetTypeName = at.Name,
                                                     Description = a.Description,
                                                     ExportingDay = eua.ExportingDay,
                                                     ExportingDayEnd = eua.ExportingDay,
                                                     TotalMonthDepreciation = a.TotalMonthDepreciation,
                                                     OriginalPrice = a.OriginalPrice,
                                                     DepreciationValue = a.DepreciationValue,
                                                     RemainingDepValue = a.RemainingDepValue,
                                                     IsActive = a.IsActive,
                                                     DepreciationStatus = a.DepreciationStatus,
                                                     UsingUnitID = an.Id,
                                                     UsingUnitName = an.DisplayName,
                                                     UsingUserID = user.Id,
                                                     UsingUserName = user.Name
                                                 }).SingleOrDefault(x => x.AssetId == assetId);



            if (transferringAssetDetailEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TransferringAssetDataOutputForInput>(transferringAssetDetailEntity);
        }

        public PagedResultDto<TransferringAssetDataOutputForList> GetTransferringAssets(TransferringAssetFilter input)
        {
            var transferringAssetEntity = transferringAssetRepository.GetAll().Where(x => !x.IsDelete);
            var assetEntity = asset_05Repository.GetAll();
            var assetUserEntity = userOrganizationUnitRepository.GetAll();
            var assetUnitEntity = organizationUnitRepository.GetAll();
            var transferringAssetDetailEntity = (from ta in transferringAssetEntity
                                                 join a in assetEntity on ta.AssetId equals a.AssetId
                                                 join au in UserManager.Users on ta.ReceivingUser equals au.Id
                                                 join an in assetUnitEntity on ta.ReceivingUnit equals an.Id
                                                 select new TransferringAssetDataOutputForList
                                                 {
                                                     Id=ta.Id,
                                                     TransferringDate =  ta.TransferringDate,
                                                     AssetId = a.AssetId,
                                                     AssetName = a.Name,
                                                     ReceivingUnit = an.DisplayName,
                                                     ReceivingUser = au.Name,
                                                     IsChecked = ta.IsChecked,
                                                 });
            // filter by TransferingDate
            if (input.TransferringDate.HasValue)
            {
                
                transferringAssetDetailEntity = transferringAssetDetailEntity.
                    Where(x => x.TransferringDate.Value.Day == input.TransferringDate.Value.Day
                    && x.TransferringDate.Value.Month == input.TransferringDate.Value.Month
                    && x.TransferringDate.Value.Year == input.TransferringDate.Value.Year
                    );
            }

            // filter by IsChecked
            if (input.IsChecked == true || input.IsChecked == false )
                transferringAssetDetailEntity = transferringAssetDetailEntity.Where(x => x.IsChecked == input.IsChecked);
            

            // filter by AssetId
            if (!input.AssetId.IsNullOrWhiteSpace())
            {
                transferringAssetDetailEntity = transferringAssetDetailEntity.Where(t => t.AssetId.Contains(input.AssetId));
            }

            // filter by AssetName
            if (!input.AssetName.IsNullOrWhiteSpace())
            {
                transferringAssetDetailEntity = transferringAssetDetailEntity.Where(t => t.AssetName.ToLower().Contains(input.AssetName.ToLower()));
            }

            // filter by ReceivingUnit
            if (!input.ReceivingUnit.IsNullOrWhiteSpace())
            {
                transferringAssetDetailEntity = transferringAssetDetailEntity.Where(t => t.ReceivingUnit.ToLower().Contains(input.ReceivingUnit.ToLower()));
            }

            // filter by ReceivingPerson
            if (!input.ReceivingUser.IsNullOrWhiteSpace())
            {
                transferringAssetDetailEntity = transferringAssetDetailEntity.Where(t => t.ReceivingUser.ToLower().Contains(input.ReceivingUser.ToLower()));
            }

            var totalCount = transferringAssetDetailEntity.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                transferringAssetDetailEntity = transferringAssetDetailEntity.OrderBy(input.Sorting);
            }

            // paging
            var items = transferringAssetDetailEntity.PageBy(input).ToList();

            // result
            return new PagedResultDto<TransferringAssetDataOutputForList>(
                totalCount,
                items.Select(item => ObjectMapper.Map<TransferringAssetDataOutputForList>(item)).ToList());
        }

        #endregion

        #region Private Method Main Dto

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_TransferringAsset_Create)]
        private void Create(TransferringAssetDataInput transferringAssetDataInput)
        {
            var transferringAssetEntity = ObjectMapper.Map<TransferringAsset>(transferringAssetDataInput);
            SetAuditInsert(transferringAssetEntity);
            transferringAssetRepository.Insert(transferringAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_TransferringAsset_Edit)]
        private void Update(TransferringAssetDataInput transferringAssetDataInput)
        {
            var transferringAssetEntity = transferringAssetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == transferringAssetDataInput.Id);
            if (transferringAssetEntity == null)
            {
            }
            ObjectMapper.Map(transferringAssetDataInput, transferringAssetEntity);
            SetAuditEdit(transferringAssetEntity);
            transferringAssetRepository.Update(transferringAssetEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion

        #region Public Method Search Asset Dto

        public SearchAssetInitData GetAssetInitData()
        {
            SearchAssetInitData output = new SearchAssetInitData
            {
                
                GetAssetGroups = assetGroup_05Repository.GetAll()
                .Select(c => new ComboboxItemDto(c.AssetGroupId, c.Name) { IsSelected = false }).ToList(),
                GetAssetTypes = assetType_05Repository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.Name) { IsSelected = false }).ToList(),
                GetAssetSuppliers = purchaseOrder_05Repository.GetAll()
                .Select(c => new ComboboxItemDto(c.PONumber, c.Supplier) { IsSelected = false }).ToList()
            };
            
            return output;
        }

        public PagedResultDto<SearchAssetDataOutput> GetAssets(SearchAssetFilter input)
        {
            var assetEntity = asset_05Repository.GetAll().Where(x => !x.IsDelete);
            var purchaseOrderEntity = purchaseOrder_05Repository.GetAll();
            var assetGroupEntity = assetGroup_05Repository.GetAll();
            var assetTypeEntity = assetType_05Repository.GetAll();
            var assetDetailEntity = (from a in assetEntity
                                     from po in purchaseOrderEntity
                                     where a.PurchaseOderId == po.PONumber
                                     from ag in assetGroupEntity
                                     where a.AssetGroupId == ag.AssetGroupId
                                     from at in assetTypeEntity
                                     where a.AssetTypeId == at.Id
                                     select new SearchAssetDataOutput
                                     {
                                         AssetTypeName = at.Name,
                                         AssetGroupName = ag.Name,
                                         AssetId = a.AssetId,
                                         AssetName = a.Name,
                                         DateAdded = a.DateAdded,
                                         Supplier = po.Supplier
                                     });



            // filter by AssetTypeName
            if (!input.AssetTypeName.IsNullOrWhiteSpace())
            {
                assetDetailEntity = assetDetailEntity.Where(x => x.AssetTypeName.Equals(input.AssetTypeName));
            }

            // filter by AssetGroupID
            if (!input.AssetGroupName.IsNullOrWhiteSpace())
            {
                assetDetailEntity = assetDetailEntity.Where(x => x.AssetGroupName.Equals(input.AssetGroupName));
            }

            // filter by AssetId
            if (!input.AssetId.IsNullOrWhiteSpace())
            {
                assetDetailEntity = assetDetailEntity.Where(x => x.AssetId.ToLower().Contains(input.AssetId.ToLower()));
            }

            // filter by AssetName
            if (!input.AssetName.IsNullOrWhiteSpace())
            {
                assetDetailEntity = assetDetailEntity.Where(x => x.AssetName.ToLower().Contains(input.AssetName.ToLower()));
            }

            // filter by DateAdded
            if (input.DateAdded.HasValue)
            {
                assetDetailEntity = assetDetailEntity.
                    Where(x => x.DateAdded.Value.Day == input.DateAdded.Value.Day
                    && x.DateAdded.Value.Month == input.DateAdded.Value.Month
                    && x.DateAdded.Value.Year == input.DateAdded.Value.Year
                    );
            }

            // filter by Supplier
            if (!input.Supplier.IsNullOrWhiteSpace())
            {
                assetDetailEntity = assetDetailEntity.Where(x => x.Supplier.Equals(input.Supplier));
            }

            var totalCount = assetDetailEntity.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                assetDetailEntity = assetDetailEntity.OrderBy(input.Sorting);
            }

            // paging
            var items = assetDetailEntity.PageBy(input).ToList();

            // result
            return new PagedResultDto<SearchAssetDataOutput>(
                totalCount,
                items.Select(item => ObjectMapper.Map<SearchAssetDataOutput>(item)).ToList());
        }

        #endregion

        #region Public Method Search Asset Unit Dto

        public SearchAssetUnitInitData GetAssetUnitInitData(long? assetRegion)
        {
            var GetAssetFathers2 = organizationUnitRepository.GetAll().Where(x => x.ParentId != null);
            if (assetRegion != null)
            {
                GetAssetFathers2 = GetAssetFathers2.Where(x => x.ParentId == assetRegion);
            }
             SearchAssetUnitInitData output = new SearchAssetUnitInitData
            {
                TotalUnitNumber = organizationUnitRepository.GetAll().Where(x => !x.IsDeleted).Count().ToString(),
                GetAssetRegions = organizationUnitRepository.GetAll().Where(x => x.ParentId == null)
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.DisplayName) { IsSelected = false }).ToList(),
                GetAssetFathers = GetAssetFathers2
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.DisplayName) { IsSelected = false }).ToList()
            };

            return output;
        }

        

        public PagedResultDto<SearchAssetUnitDataOutput> GetAssetUnits(SearchAssetUnitFilter input)
        {
            var assetUnit = organizationUnitRepository.GetAll();
            //var assetUserEntity = userOrganizationUnitRepository.GetAll();
            
            var assetUnitDetailEntity =
                (from ou in organizationUnitRepository.GetAll()
                join au in assetUnit on ou.ParentId equals au.Id
                select new SearchAssetUnitDataOutput
                    {
                        AssetFatherName = au.DisplayName,
                        AssetUnitID = ou.Id,
                        AssetUnitName = ou.DisplayName
                    });
            
            // filter by AssetUnitFatherName
            if (!input.AssetUnitFatherName.IsNullOrWhiteSpace())
            {
                assetUnitDetailEntity = assetUnitDetailEntity.Where(x => x.AssetFatherName.Equals(input.AssetUnitFatherName));
            }

            // filter by AssetUnitName
            if (!input.AssetUnitName.IsNullOrWhiteSpace())
            {
                assetUnitDetailEntity = assetUnitDetailEntity.Where(x => x.AssetUnitName.ToLower().Contains(input.AssetUnitName));
            }

            var totalCount = assetUnitDetailEntity.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                assetUnitDetailEntity = assetUnitDetailEntity.OrderBy(input.Sorting);
            }

            // paging
            var items = assetUnitDetailEntity.PageBy(input).ToList();

            // result
            return new PagedResultDto<SearchAssetUnitDataOutput>(
                totalCount,
                items.Select(item => ObjectMapper.Map<SearchAssetUnitDataOutput>(item)).ToList());
        }

        public SearchAssetUnitDataOutput GetAssetUnitDetail(long assetUnitID)
        {
            //var assetUserEntity = userOrganizationUnitRepository.GetAll();

            var assetUnitDetailEntity =
                (from ou in organizationUnitRepository.GetAll()
 
                 select new SearchAssetUnitDataOutput
                 {
                     AssetFatherName = ou.DisplayName,
                     AssetUnitID = ou.Id,
                     AssetUnitName = ou.DisplayName
                 }).SingleOrDefault(x => x.AssetUnitID == assetUnitID);

            return ObjectMapper.Map<SearchAssetUnitDataOutput>(assetUnitDetailEntity);
        }

        #endregion

        #region Public Method Search Asset User Dto

        public PagedResultDto<SearchAssetUserDataOutput> GetAssetUsers(SearchAssetUserFilter input)
        {

            var assetUserEntity = from uou in userOrganizationUnitRepository.GetAll().Where(x => !x.IsDeleted)
                        join ou in organizationUnitRepository.GetAll() on uou.OrganizationUnitId equals ou.Id
                        join user in UserManager.Users on uou.UserId equals user.Id
                        select new SearchAssetUserDataOutput
                        {
                            AssetUnitId = uou.OrganizationUnitId,
                            AssetUserId = user.Id,
                            AssetUserName = user.Name
                        };

            // filter by AssetUnitId
            if (input.AssetUnitId != null)
            {
                assetUserEntity = assetUserEntity.Where(x => x.AssetUnitId.Equals(input.AssetUnitId));
            }

            // filter by AssetUserId
            if (input.AssetUserId != null)
            {
                assetUserEntity = assetUserEntity.Where(x => x.AssetUserId.Equals(input.AssetUserId));
            }

            // filter by AssetUnitName
            if (input.AssetUserName != null)
            {
                assetUserEntity = assetUserEntity.Where(x => x.AssetUserName.ToLower().Contains(input.AssetUserName));
            }

            var totalCount = assetUserEntity.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                assetUserEntity = assetUserEntity.OrderBy(input.Sorting);
            }

            // paging
            var items = assetUserEntity.PageBy(input).ToList();

            // result
            return new PagedResultDto<SearchAssetUserDataOutput>(
                totalCount,
                items.Select(item => ObjectMapper.Map<SearchAssetUserDataOutput>(item)).ToList());
        }

        
        public SearchAssetUserDataOutput GetAssetUserDetail(long assetUserId)
        {

            var assetUserEntity = (from user in UserManager.Users 
                                  select new SearchAssetUserDataOutput
                                  {
                                      AssetUnitId = 1,
                                      AssetUserId = user.Id,
                                      AssetUserName = user.Name
                                  }).SingleOrDefault(x => x.AssetUserId == assetUserId);

            return ObjectMapper.Map<SearchAssetUserDataOutput>(assetUserEntity);
        }

        #endregion
    }
}
