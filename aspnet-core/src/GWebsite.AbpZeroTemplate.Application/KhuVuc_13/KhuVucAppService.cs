using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.KhuVuc;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.KhuVuc.DTO;

namespace GWebsite.AbpZeroTemplate.Web.Core.KhuVucs
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_KhuVuc)]
    public class KhuVucAppService : GWebsiteAppServiceBase, IKhuVucAppService
    {
        private readonly IRepository<KhuVuc> khuVucRepository;
        public KhuVucAppService(IRepository<KhuVuc> khuVucRepository)
        {
            this.khuVucRepository = khuVucRepository;
        }

        #region Public Method

        public void CreateOrEditKhuVuc(KhuVucInput khuVucInput)
        {
            if (khuVucInput.Id == 0)
            {
                Create(khuVucInput);
            }
            else
            {
                Update(khuVucInput);
            }
        }

        public void DeleteKhuVuc(int id)
        {
            var khuVucEntity = khuVucRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (khuVucEntity != null)
            {
                khuVucEntity.IsDelete = true;
                khuVucRepository.Update(khuVucEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public KhuVucInput GetKhuVucForEdit(int id)
        {
            var khuVucEntity = khuVucRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (khuVucEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<KhuVucInput>(khuVucEntity);
        }

        public KhuVucForViewDto GetKhuVucForView(int id)
        {
            var khuVucEntity = khuVucRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (khuVucEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<KhuVucForViewDto>(khuVucEntity);
        }

        public PagedResultDto<KhuVucDto> GetKhuVucs(KhuVucFilter input)
        {
            var query = khuVucRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<KhuVucDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<KhuVucDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_KhuVuc_Create)]
        private void Create(KhuVucInput khuVucInput)
        {
            var khuVucEntity = ObjectMapper.Map<KhuVuc>(khuVucInput);
            SetAuditInsert(khuVucEntity);
            khuVucRepository.Insert(khuVucEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_KhuVuc_Edit)]
        private void Update(KhuVucInput khuVucInput)
        {
            var khuVucEntity = khuVucRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == khuVucInput.Id);
            if (khuVucEntity == null)
            {
            }
            ObjectMapper.Map(khuVucInput, khuVucEntity);
            SetAuditEdit(khuVucEntity);
            khuVucRepository.Update(khuVucEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
