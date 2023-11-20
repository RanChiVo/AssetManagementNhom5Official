using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.KeHoachXayDung_N13.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models.KeHoachXayDung_N13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application.Share.KeHoachXayDung_N13;

namespace GWebsite.AbpZeroTemplate.Web.Core.KeHoach_13
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyKeHoachXayDung_KeHoachXayDung)]
    public class KeHoachXayDungAppService : GWebsiteAppServiceBase, IKeHoachXayDungAppService
    {
        private readonly IRepository<KeHoachXayDung_N13> keHoachXayDungRepository;

        public KeHoachXayDungAppService(IRepository<KeHoachXayDung_N13> keHoachXayDungRepository)
        {
            this.keHoachXayDungRepository = keHoachXayDungRepository;
        }

        #region Public Method

        public void CreateOrEditKeHoachXayDung(KeHoachXayDungInput keHoachXayDungInput)
        {
            if (keHoachXayDungInput.Id == 0)
            {
                Create(keHoachXayDungInput);
            }
            else
            {
                Update(keHoachXayDungInput);
            }
        }

        public void DeleteKeHoachXayDung(int id)
        {
            var keHoachXayDungEntity = keHoachXayDungRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (keHoachXayDungEntity != null)
            {
                keHoachXayDungEntity.IsDelete = true;
                keHoachXayDungRepository.Update(keHoachXayDungEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public KeHoachXayDungInput GetKeHoachXayDungForEdit(int id)
        {
            var keHoachXayDungEntity = keHoachXayDungRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (keHoachXayDungEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<KeHoachXayDungInput>(keHoachXayDungEntity);
        }

        public KeHoachXayDungForViewDto GetKeHoachXayDungForView(int id)
        {
            var keHoachXayDungEntity = keHoachXayDungRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (keHoachXayDungEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<KeHoachXayDungForViewDto>(keHoachXayDungEntity);
        }

        public PagedResultDto<KeHoachXayDungDto> GetKeHoachXayDungs(KeHoachXayDungFilter input)
        {
            var query = keHoachXayDungRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.MaKeHoach != null)
            {
                query = query.Where(x => x.MaKeHoach.ToLower().Equals(input.MaKeHoach));
            }

            // filter by value
            if (input.TenKeHoach != null)
            {
                query = query.Where(x => x.TenKeHoach.ToLower().Equals(input.TenKeHoach));
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
            return new PagedResultDto<KeHoachXayDungDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<KeHoachXayDungDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyKeHoachXayDung_KeHoachXayDung_Create)]
        private void Create(KeHoachXayDungInput keHoachXayDungInput)
        {
            var keHoachXayDungEntity = ObjectMapper.Map<KeHoachXayDung_N13>(keHoachXayDungInput);
            SetAuditInsert(keHoachXayDungEntity);
            keHoachXayDungRepository.Insert(keHoachXayDungEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyKeHoachXayDung_KeHoachXayDung_Edit)]
        private void Update(KeHoachXayDungInput keHoachXayDungInput)
        {
            var keHoachXayDungEntity = keHoachXayDungRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == keHoachXayDungInput.Id);
            if (keHoachXayDungEntity == null)
            {
            }
            ObjectMapper.Map(keHoachXayDungInput, keHoachXayDungEntity);
            SetAuditEdit(keHoachXayDungEntity);
            keHoachXayDungRepository.Update(keHoachXayDungEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
