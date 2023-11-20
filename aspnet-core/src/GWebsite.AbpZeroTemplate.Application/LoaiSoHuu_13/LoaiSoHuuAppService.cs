using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiSoHuu;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiSoHuu.DTO;

namespace GWebsite.AbpZeroTemplate.Web.Core.LoaiSoHuus
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiSoHuu)]
    public class LoaiSoHuuAppService : GWebsiteAppServiceBase, ILoaiSoHuuAppService
    {
        private readonly IRepository<LoaiSoHuu> loaiSoHuuRepository;
        public LoaiSoHuuAppService(IRepository<LoaiSoHuu> loaiSoHuuRepository)
        {
            this.loaiSoHuuRepository = loaiSoHuuRepository;
        }

        #region Public Method

        public void CreateOrEditLoaiSoHuu(LoaiSoHuuInput loaiSoHuuInput)
        {
            if (loaiSoHuuInput.Id == 0)
            {
                Create(loaiSoHuuInput);
            }
            else
            {
                Update(loaiSoHuuInput);
            }
        }

        public void DeleteLoaiSoHuu(int id)
        {
            var loaiSoHuuEntity = loaiSoHuuRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (loaiSoHuuEntity != null)
            {
                loaiSoHuuEntity.IsDelete = true;
                loaiSoHuuRepository.Update(loaiSoHuuEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public LoaiSoHuuInput GetLoaiSoHuuForEdit(int id)
        {
            var loaiSoHuuEntity = loaiSoHuuRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (loaiSoHuuEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LoaiSoHuuInput>(loaiSoHuuEntity);
        }

        public LoaiSoHuuForViewDto GetLoaiSoHuuForView(int id)
        {
           
            var loaiSoHuuEntity = loaiSoHuuRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (loaiSoHuuEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LoaiSoHuuForViewDto>(loaiSoHuuEntity);
        }

        public PagedResultDto<LoaiSoHuuDto> GetLoaiSoHuus(LoaiSoHuuFilter input)
        {
            var query = loaiSoHuuRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<LoaiSoHuuDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<LoaiSoHuuDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiSoHuu_Create)]
        private void Create(LoaiSoHuuInput loaiSoHuuInput)
        {
            var loaiSoHuuEntity = ObjectMapper.Map<LoaiSoHuu>(loaiSoHuuInput);
            SetAuditInsert(loaiSoHuuEntity);
            loaiSoHuuRepository.Insert(loaiSoHuuEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_LoaiSoHuu_Edit)]
        private void Update(LoaiSoHuuInput loaiSoHuuInput)
        {
            var loaiSoHuuEntity = loaiSoHuuRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == loaiSoHuuInput.Id);
            if (loaiSoHuuEntity == null)
            {
            }
            ObjectMapper.Map(loaiSoHuuInput, loaiSoHuuEntity);
            SetAuditEdit(loaiSoHuuEntity);
            loaiSoHuuRepository.Update(loaiSoHuuEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
