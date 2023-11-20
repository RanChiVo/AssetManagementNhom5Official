using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Asset_8;
using GWebsite.AbpZeroTemplate.Application.Share.Asset_8.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.Assets_8
{
    [AbpAuthorize(GWebsitePermissions.Pages_QuanLyXe_Asset)]
    public class Asset_8AppService : GWebsiteAppServiceBase, IAsset_8AppService
    {
        private readonly IRepository<Asset_8> asset_8Repository;

        public Asset_8AppService(IRepository<Asset_8> asset_8Repository)
        {
            this.asset_8Repository = asset_8Repository;
        }

        #region Public Method

        public void CreateOrEditAsset_8(Asset_8Input asset_8Input)
        {
            if (asset_8Input.Id == 0)
            {
                Create(asset_8Input);
            }
            else
            {
                Update(asset_8Input);
            }
        }

        public void DeleteAsset_8(int id)
        {
            var asset_8Entity = asset_8Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (asset_8Entity != null)
            {
                asset_8Entity.IsDelete = true;
                asset_8Repository.Update(asset_8Entity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public Asset_8Input GetAsset_8ForEdit(int id)
        {
            var asset_8Entity = asset_8Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (asset_8Entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<Asset_8Input>(asset_8Entity);
        }

        public Asset_8ForViewDto GetAsset_8ForView(int id)
        {
            var asset_8Entity = asset_8Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (asset_8Entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<Asset_8ForViewDto>(asset_8Entity);
        }

        public PagedResultDto<Asset_8Dto> GetAssets_8(Asset_8Filter input)
        {
            var query = asset_8Repository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.TenTaiSan != null)
            {
                query = query.Where(x => x.TenTaiSan.ToLower().Equals(input.TenTaiSan));
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
            return new PagedResultDto<Asset_8Dto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<Asset_8Dto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_QuanLyXe_Asset_Create)]
        private void Create(Asset_8Input asset_8Input)
        {
            int nextID= asset_8Repository.GetAll().Count() + 1;
            asset_8Input.MaTaiSan = "TS000" + nextID;
            var asset_8Entity = ObjectMapper.Map<Asset_8>(asset_8Input);
            SetAuditInsert(asset_8Entity);
            asset_8Repository.Insert(asset_8Entity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_QuanLyXe_Asset_Edit)]
        private void Update(Asset_8Input asset_8Input)
        {
            var asset_8Entity = asset_8Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == asset_8Input.Id);
            if (asset_8Entity == null)
            {
            }
            ObjectMapper.Map(asset_8Input, asset_8Entity);
            SetAuditEdit(asset_8Entity);
            asset_8Repository.Update(asset_8Entity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}


