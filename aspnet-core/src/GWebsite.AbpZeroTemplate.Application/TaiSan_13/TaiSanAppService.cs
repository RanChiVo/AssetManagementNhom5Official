using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSan_13;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSan_13.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using GWebsite.AbpZeroTemplate.Core.Models.TaiSan13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.Asset_13
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_TaiSan)]
    public class TaiSanAppService : GWebsiteAppServiceBase, ITaiSanAppService
    {
        private readonly IRepository<TaiSan_13> taiSanRepository;

        public TaiSanAppService(IRepository<TaiSan_13> taiSanRepository)
        {
            this.taiSanRepository = taiSanRepository;
        }

        #region Public Method

        public void CreateOrEditTaiSan(TaiSanInput taiSanInput)
        {
            if (taiSanInput.Id == 0)
            {
                Create(taiSanInput);
            }
            else
            {
                Update(taiSanInput);
            }
        }

        public void DeleteTaiSan(int id)
        {
            var taiSanEntity = taiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (taiSanEntity != null)
            {
                taiSanEntity.IsDelete = true;
                taiSanRepository.Update(taiSanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public TaiSanInput GetTaiSanForEdit(int id)
        {
            var taiSanEntity = taiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (taiSanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TaiSanInput>(taiSanEntity);
        }

        public TaiSanForViewDto GetTaiSanForView(int id)
        {
            var taiSanEntity = taiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (taiSanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TaiSanForViewDto>(taiSanEntity);
        }

        public PagedResultDto<TaiSanDto> GetTaiSans(TaiSanFilter input)
        {
            var query = taiSanRepository.GetAll().Where(x => !x.IsDelete);    
            // filter by value
            if (input.MaTaiSan != null)
            {
                query = query.Where(x => x.MaTaiSan.ToLower().Equals(input.MaTaiSan));
            }

            // filter by value
            if (input.TenTaiSan != null)
            {
                query = query.Where(x => x.TenTaiSan.ToLower().Equals(input.TenTaiSan));
            }
            // filter by value
            if (input.MaLoaiTaiSan != null)
            {
                query = query.Where(x => x.MaLoaiTaiSan.ToLower().Equals(input.MaLoaiTaiSan));
            }
            // filter by value
            if (input.MaNhomTaiSan != null)
            {
                query = query.Where(x => x.MaNhomTaiSan.ToLower().Equals(input.MaNhomTaiSan));
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
            return new PagedResultDto<TaiSanDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<TaiSanDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_TaiSan_Create)]
        private void Create(TaiSanInput taiSanInput)
        {
            int nextID = taiSanRepository.GetAll().Count() + 1;
            taiSanInput.MaTaiSan = "TS000" + nextID;
            var taiSanEntity = ObjectMapper.Map<TaiSan_13>(taiSanInput);
            SetAuditInsert(taiSanEntity);
            taiSanRepository.Insert(taiSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_TaiSan_Edit)]
        private void Update(TaiSanInput taiSanInput)
        {
            var taiSanEntity = taiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == taiSanInput.Id);
            if (taiSanEntity == null)
            {
            }
            ObjectMapper.Map(taiSanInput, taiSanEntity);
            SetAuditEdit(taiSanEntity);
            taiSanRepository.Update(taiSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}


