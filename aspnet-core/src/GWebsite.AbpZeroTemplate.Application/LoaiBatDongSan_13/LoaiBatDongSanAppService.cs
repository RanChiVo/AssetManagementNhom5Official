using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiBatDongSan;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiBatDongSan.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.LoaiBatDongSans
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiBatDongSan)]
    public class LoaiBatDongSanAppService : GWebsiteAppServiceBase, ILoaiBatDongSanAppService
    {
        private readonly IRepository<LoaiBatDongSan> loaiBatDongSanRepository;

        public LoaiBatDongSanAppService(IRepository<LoaiBatDongSan> loaiBatDongSanRepository)
        {
            this.loaiBatDongSanRepository = loaiBatDongSanRepository;
        }

        #region Public Method

        public void CreateOrEditLoaiBatDongSan(LoaiBatDongSanInput loaiBatDongSanInput)
        {
            if (loaiBatDongSanInput.Id == 0)
            {
                Create(loaiBatDongSanInput);
            }
            else
            {
                Update(loaiBatDongSanInput);
            }
        }

        public void DeleteLoaiBatDongSan(int id)
        {
            var loaiBatDongSanEntity = loaiBatDongSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (loaiBatDongSanEntity != null)
            {
                loaiBatDongSanEntity.IsDelete = true;
                loaiBatDongSanRepository.Update(loaiBatDongSanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public LoaiBatDongSanInput GetLoaiBatDongSanForEdit(int id)
        {
            var loaiBatDongSanEntity = loaiBatDongSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (loaiBatDongSanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LoaiBatDongSanInput>(loaiBatDongSanEntity);
        }

        public LoaiBatDongSanForViewDto GetLoaiBatDongSanForView(int id)
        {
            var loaiBatDongSanEntity = loaiBatDongSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (loaiBatDongSanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LoaiBatDongSanForViewDto>(loaiBatDongSanEntity);
        }

        public PagedResultDto<LoaiBatDongSanDto> GetLoaiBatDongSans(LoaiBatDongSanFilter input)
        {
            var query = loaiBatDongSanRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<LoaiBatDongSanDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<LoaiBatDongSanDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiBatDongSan_Create)]
        private void Create(LoaiBatDongSanInput loaiBatDongSanInput)
        {
            var loaiBatDongSanEntity = ObjectMapper.Map<LoaiBatDongSan>(loaiBatDongSanInput);
            SetAuditInsert(loaiBatDongSanEntity);
            loaiBatDongSanRepository.Insert(loaiBatDongSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiBatDongSan_Edit)]
        private void Update(LoaiBatDongSanInput loaiBatDongSanInput)
        {
            var loaiBatDongSanEntity = loaiBatDongSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == loaiBatDongSanInput.Id);
            if (loaiBatDongSanEntity == null)
            {
            }
            ObjectMapper.Map(loaiBatDongSanInput, loaiBatDongSanEntity);
            SetAuditEdit(loaiBatDongSanEntity);
            loaiBatDongSanRepository.Update(loaiBatDongSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
