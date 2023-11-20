using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05;
using GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes_05.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;

namespace GWebsite.AbpZeroTemplate.Web.Core.AssetGroups_05
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetGroup_05)]

    public class AssetGroupAppService_05 : GWebsiteAppServiceBase, IAssetGroupAppService_05
    {
        private readonly IRepository<AssetGroup_05> assetGroupRepository;
        private readonly IRepository<AssetType_05> assetTypeRepository;

        public AssetGroupAppService_05(IRepository<AssetGroup_05> assetGroupRepository,
            IRepository<AssetType_05> assetTypeRepository)
        {
            this.assetGroupRepository = assetGroupRepository;
            this.assetTypeRepository = assetTypeRepository;
        }

        #region Public Method

        public void CreateOrEditAssetGroup(AssetGroupDto_05 assetGroupInput)
        {
            Console.WriteLine(assetGroupInput.Id);

            if (assetGroupInput.Id == 0)
            {
                Create(assetGroupInput);
            }
            else
            {
                Update(assetGroupInput);
            }
        }

        public void DeleteAssetGroup(string idAssetGroup)
        {
            var assetGroupEntity = assetGroupRepository.GetAll()
                                                       .Where(x => !x.IsDelete)
                                                       .SingleOrDefault(x => x.AssetGroupId == idAssetGroup);
            if (assetGroupEntity != null)
            {
                assetGroupEntity.IsDelete = true;
                assetGroupRepository.Update(assetGroupEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public AssetGroupOutput_05 GetAssetGroupEdit(string id)
        {
            AssetGroup_05 assetGroup = null;
            var output = new AssetGroupOutput_05();
            var selectedAssetId = 1;
            assetGroup = assetGroupRepository.GetAll()
                                             .Where(x => !x.IsDelete)
                                              .SingleOrDefault(x => x.AssetGroupId == id);

            if (assetGroup == null)
            {
                output.AssetGroup = new AssetGroupDto_05();
            }
            else
            {
                output.AssetGroup = ObjectMapper.Map<AssetGroupDto_05>(assetGroup);
                selectedAssetId = assetGroup.AssetTypeId ?? 0;
            }

            var parentId = output.AssetGroup.SelectedId ?? null;//Do du lieu name vai combobox
            output.AssetGroups = assetGroupRepository.GetAll()
                .Where(x => !x.IsDelete)
                .Select(c => new ComboboxItemDto(c.AssetGroupId, c.Name)
                { IsSelected = parentId == c.AssetGroupId })
                .ToList();

            output.AssetTypes = assetTypeRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.Name)
                { IsSelected = selectedAssetId == c.Id })
                .ToList();
            return output;
        }

        public AssetGroupInput_05 GetAssetGroupForEdit(string idAssetGroup)
        {
            AssetGroupInput_05 assetGroup = null;
            var assetGroupEntity = assetGroupRepository.GetAll()
                                                       .Where(x => !x.IsDelete)
                                                       .SingleOrDefault(x => x.AssetGroupId == idAssetGroup);
            if (assetGroupEntity == null)
            {
                assetGroup = new AssetGroupInput_05();

                return assetGroup;
            }
            return ObjectMapper.Map<AssetGroupInput_05>(assetGroupEntity);
        }
       
        public AssetGroupForViewDto_05 GetAssetGroupForView(string idAssetGroup)
        {
            var assetGroupEntity = assetGroupRepository.GetAll()
                                                       .Where(x => !x.IsDelete)
                                                       .SingleOrDefault(x => x.AssetGroupId == idAssetGroup);
            if (assetGroupEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetGroupForViewDto_05>(assetGroupEntity);
        }

        public PagedResultDto<AssetGroupDto_05> GetAssetGroups(AssetGroupFilter_05 input)
        {
            var query = assetGroupRepository.GetAll().Where(x => !x.IsDelete);

            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Equals(input.Name));
            }

            var totalCount = query.Count();

            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(sorting => input.Sorting);
            }

            var items = query.PageBy(input).ToList();

            return new PagedResultDto<AssetGroupDto_05>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AssetGroupDto_05>(item)).ToList());
        }
        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetGroup_05_Create)]

        private void Create(AssetGroupDto_05 assetGroupInput)
        {
            var assetGroupEntity = ObjectMapper.Map<AssetGroup_05>(assetGroupInput);
            SetAuditInsert(assetGroupEntity);
            assetGroupRepository.Insert(assetGroupEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetGroup_05_Edit)]

        private void Update(AssetGroupDto_05 assetGroupInput)
        {
            var assetGroupEntity = assetGroupRepository.GetAll()
                                                       .Where(x => !x.IsDelete)
                                                       .SingleOrDefault(x => x.AssetGroupId == assetGroupInput.AssetGroupId);
            if (assetGroupEntity != null)
            {
                ObjectMapper.Map(assetGroupInput, assetGroupEntity);
                SetAuditEdit(assetGroupEntity);
                assetGroupRepository.Update(assetGroupEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        #endregion
    }
}
