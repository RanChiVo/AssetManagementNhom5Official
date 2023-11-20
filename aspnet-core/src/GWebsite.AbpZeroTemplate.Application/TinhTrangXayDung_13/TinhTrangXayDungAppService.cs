using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangXayDung;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangXayDung.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.TinhTrangXayDungs
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_TinhTrangXayDung)]
    public class TinhTrangXayDungAppService : GWebsiteAppServiceBase, ITinhTrangXayDungAppService
    {
        private readonly IRepository<TinhTrangXayDung> tinhTrangXayDungRepository;

        public TinhTrangXayDungAppService(IRepository<TinhTrangXayDung> tinhTrangXayDungRepository)
        {
            this.tinhTrangXayDungRepository = tinhTrangXayDungRepository;
        }

        #region Public Method

        public void CreateOrEditTinhTrangXayDung(TinhTrangXayDungInput tinhTrangXayDungInput)
        {
            if (tinhTrangXayDungInput.Id == 0)
            {
                Create(tinhTrangXayDungInput);
            }
            else
            {
                Update(tinhTrangXayDungInput);
            }
        }

        public void DeleteTinhTrangXayDung(int id)
        {
            var tinhTrangXayDungEntity = tinhTrangXayDungRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (tinhTrangXayDungEntity != null)
            {
                tinhTrangXayDungEntity.IsDelete = true;
                tinhTrangXayDungRepository.Update(tinhTrangXayDungEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public TinhTrangXayDungInput GetTinhTrangXayDungForEdit(int id)
        {
            var tinhTrangXayDungEntity = tinhTrangXayDungRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (tinhTrangXayDungEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TinhTrangXayDungInput>(tinhTrangXayDungEntity);
        }

        public TinhTrangXayDungForViewDto GetTinhTrangXayDungForView(int id)
        {
            var tinhTrangXayDungEntity = tinhTrangXayDungRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (tinhTrangXayDungEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TinhTrangXayDungForViewDto>(tinhTrangXayDungEntity);
        }

        public PagedResultDto<TinhTrangXayDungDto> GetTinhTrangXayDungs(TinhTrangXayDungFilter input)
        {
            var query = tinhTrangXayDungRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<TinhTrangXayDungDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<TinhTrangXayDungDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_TinhTrangXayDung_Create)]
        private void Create(TinhTrangXayDungInput tinhTrangXayDungInput)
        {
            var tinhTrangXayDungEntity = ObjectMapper.Map<TinhTrangXayDung>(tinhTrangXayDungInput);
            SetAuditInsert(tinhTrangXayDungEntity);
            tinhTrangXayDungRepository.Insert(tinhTrangXayDungEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_TinhTrangXayDung_Edit)]
        private void Update(TinhTrangXayDungInput tinhTrangXayDungInput)
        {
            var tinhTrangXayDungEntity = tinhTrangXayDungRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == tinhTrangXayDungInput.Id);
            if (tinhTrangXayDungEntity == null)
            {
            }
            ObjectMapper.Map(tinhTrangXayDungInput, tinhTrangXayDungEntity);
            SetAuditEdit(tinhTrangXayDungEntity);
            tinhTrangXayDungRepository.Update(tinhTrangXayDungEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
