using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.MucDichSuDungDat;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.MucDichSuDungDat.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.MucDichSuDungDats
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_MucDichSuDungDat)]
    public class MucDichSuDungDatAppService : GWebsiteAppServiceBase, IMucDichSuDungDatAppService
    {
        private readonly IRepository<MucDichSuDungDat> mucDichSuDungDatRepository;

        public MucDichSuDungDatAppService(IRepository<MucDichSuDungDat> mucDichSuDungDatRepository)
        {
            this.mucDichSuDungDatRepository = mucDichSuDungDatRepository;
        }

        #region Public Method

        public void CreateOrEditMucDichSuDungDat(MucDichSuDungDatInput mucDichSuDungDatInput)
        {
            if (mucDichSuDungDatInput.Id == 0)
            {
                Create(mucDichSuDungDatInput);
            }
            else
            {
                Update(mucDichSuDungDatInput);
            }
        }

        public void DeleteMucDichSuDungDat(int id)
        {
            var mucDichSuDungDatEntity = mucDichSuDungDatRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (mucDichSuDungDatEntity != null)
            {
                mucDichSuDungDatEntity.IsDelete = true;
                mucDichSuDungDatRepository.Update(mucDichSuDungDatEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public MucDichSuDungDatInput GetMucDichSuDungDatForEdit(int id)
        {
            var mucDichSuDungDatEntity = mucDichSuDungDatRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (mucDichSuDungDatEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<MucDichSuDungDatInput>(mucDichSuDungDatEntity);
        }

        public MucDichSuDungDatForViewDto GetMucDichSuDungDatForView(int id)
        {
            var mucDichSuDungDatEntity = mucDichSuDungDatRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (mucDichSuDungDatEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<MucDichSuDungDatForViewDto>(mucDichSuDungDatEntity);
        }

        public PagedResultDto<MucDichSuDungDatDto> GetMucDichSuDungDats(MucDichSuDungDatFilter input)
        {
            var query = mucDichSuDungDatRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<MucDichSuDungDatDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<MucDichSuDungDatDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_MucDichSuDungDat_Create)]
        private void Create(MucDichSuDungDatInput mucDichSuDungDatInput)
        {
            var mucDichSuDungDatEntity = ObjectMapper.Map<MucDichSuDungDat>(mucDichSuDungDatInput);
            SetAuditInsert(mucDichSuDungDatEntity);
            mucDichSuDungDatRepository.Insert(mucDichSuDungDatEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_MucDichSuDungDat_Edit)]
        private void Update(MucDichSuDungDatInput mucDichSuDungDatInput)
        {
            var mucDichSuDungDatEntity = mucDichSuDungDatRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == mucDichSuDungDatInput.Id);
            if (mucDichSuDungDatEntity == null)
            {
            }
            ObjectMapper.Map(mucDichSuDungDatInput, mucDichSuDungDatEntity);
            SetAuditEdit(mucDichSuDungDatEntity);
            mucDichSuDungDatRepository.Update(mucDichSuDungDatEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
