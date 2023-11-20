using System;
using System.Collections.Generic;
using System.Linq;
using GWebsite.AbpZeroTemplate.Core.Models;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes_05;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes_05.Dto;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;

namespace GWebsite.AbpZeroTemplate.Web.Core.AssetTypes_05
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_AssetType_05)]

    public class AssetTypeAppService_05 : GWebsiteAppServiceBase, IAssetTypeAppService_05
    {
        private readonly IRepository<AssetType_05> assetTypeRepository;

        public AssetTypeAppService_05(IRepository<AssetType_05> assetTypeRepository)
        {
            this.assetTypeRepository = assetTypeRepository;
        }

        public PagedResultDto<AssetTypeDto_05> GetAssetTypes()
        {
            var query = assetTypeRepository.GetAll();
            var totalCount = query.Count();
            var items = query.ToList();

            return new PagedResultDto<AssetTypeDto_05>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AssetTypeDto_05>(item)).ToList());
        }

        public AssetTypeViewDto_05 GetAssetTypeForView(int id)
        {
            var asseTypeEntity = assetTypeRepository.GetAll()
                                                    .SingleOrDefault(x => x.Id == id);
            if (assetTypeRepository == null)
            {
                return null;
            }
            return ObjectMapper.Map<AssetTypeViewDto_05>(asseTypeEntity); ;
        }
    }
}
