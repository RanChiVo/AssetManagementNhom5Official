using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangSuDungDat;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangSuDungDat.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.TinhTrangSuDungDats
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_TinhTrangSuDungDat)]
    public class TinhTrangSuDungDatAppService : GWebsiteAppServiceBase, ITinhTrangSuDungDatAppService
    {
        private readonly IRepository<TinhTrangSuDungDat> tinhTrangSuDungDatRepository;

        public TinhTrangSuDungDatAppService(IRepository<TinhTrangSuDungDat> tinhTrangSuDungDatRepository)
        {
            this.tinhTrangSuDungDatRepository = tinhTrangSuDungDatRepository;
        }

        #region Public Method

        public void CreateOrEditTinhTrangSuDungDat(TinhTrangSuDungDatInput tinhTrangSuDungDatInput)
        {
            if (tinhTrangSuDungDatInput.Id == 0)
            {
                Create(tinhTrangSuDungDatInput);
            }
            else
            {
                Update(tinhTrangSuDungDatInput);
            }
        }

        public void DeleteTinhTrangSuDungDat(int id)
        {
            var tinhTrangSuDungDatEntity = tinhTrangSuDungDatRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (tinhTrangSuDungDatEntity != null)
            {
                tinhTrangSuDungDatEntity.IsDelete = true;
                tinhTrangSuDungDatRepository.Update(tinhTrangSuDungDatEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public TinhTrangSuDungDatInput GetTinhTrangSuDungDatForEdit(int id)
        {
            var tinhTrangSuDungDatEntity = tinhTrangSuDungDatRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (tinhTrangSuDungDatEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TinhTrangSuDungDatInput>(tinhTrangSuDungDatEntity);
        }

        public TinhTrangSuDungDatForViewDto GetTinhTrangSuDungDatForView(int id)
        {
            var tinhTrangSuDungDatEntity = tinhTrangSuDungDatRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (tinhTrangSuDungDatEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TinhTrangSuDungDatForViewDto>(tinhTrangSuDungDatEntity);
        }

        public PagedResultDto<TinhTrangSuDungDatDto> GetTinhTrangSuDungDats(TinhTrangSuDungDatFilter input)
        {
            var query = tinhTrangSuDungDatRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<TinhTrangSuDungDatDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<TinhTrangSuDungDatDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_TinhTrangSuDungDat_Create)]
        private void Create(TinhTrangSuDungDatInput tinhTrangSuDungDatInput)
        {
            var tinhTrangSuDungDatEntity = ObjectMapper.Map<TinhTrangSuDungDat>(tinhTrangSuDungDatInput);
            SetAuditInsert(tinhTrangSuDungDatEntity);
            tinhTrangSuDungDatRepository.Insert(tinhTrangSuDungDatEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_TinhTrangSuDungDat_Edit)]
        private void Update(TinhTrangSuDungDatInput tinhTrangSuDungDatInput)
        {
            var tinhTrangSuDungDatEntity = tinhTrangSuDungDatRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == tinhTrangSuDungDatInput.Id);
            if (tinhTrangSuDungDatEntity == null)
            {
            }
            ObjectMapper.Map(tinhTrangSuDungDatInput, tinhTrangSuDungDatEntity);
            SetAuditEdit(tinhTrangSuDungDatEntity);
            tinhTrangSuDungDatRepository.Update(tinhTrangSuDungDatEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
