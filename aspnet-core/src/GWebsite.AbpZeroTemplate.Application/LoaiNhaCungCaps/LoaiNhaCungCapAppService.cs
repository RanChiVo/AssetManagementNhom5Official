using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps.Dto;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace GWebsite.AbpZeroTemplate.Web.Core.LoaiNhaCungCaps
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_LoaiNhaCungCap)]
    public class LoaiNhaCungCapAppService : GWebsiteAppServiceBase, ILoaiNhaCungCapAppService
    {
        private readonly IRepository<LoaiNhaCungCap> LoaiNhaCungCapRepository;

        public LoaiNhaCungCapAppService(IRepository<LoaiNhaCungCap> LoaiNhaCungCapRepository)
        {
            this.LoaiNhaCungCapRepository = LoaiNhaCungCapRepository;
        }

        #region Public Method

        public void CreateOrEditLoaiNhaCungCap(LoaiNhaCungCapInput loaiNhaCungCapInput)
        {
            if (loaiNhaCungCapInput.Id == 0)
            {
                Create(loaiNhaCungCapInput);
            }
            else
            {
                Update(loaiNhaCungCapInput);
            }
        }

        public void DeleteLoaiNhaCungCap(int id)
        {
            var LoaiNhaCungCapEntity = LoaiNhaCungCapRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (LoaiNhaCungCapEntity != null)
            {
                LoaiNhaCungCapEntity.IsDelete = true;
                LoaiNhaCungCapRepository.Update(LoaiNhaCungCapEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public LoaiNhaCungCapInput GetLoaiNhaCungCapForEdit(int id)
        {
            var LoaiNhaCungCapEntity = LoaiNhaCungCapRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (LoaiNhaCungCapEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LoaiNhaCungCapInput>(LoaiNhaCungCapEntity);
        }

        public LoaiNhaCungCapForViewDto GetLoaiNhaCungCapForView(int id)
        {
            var LoaiNhaCungCapEntity = LoaiNhaCungCapRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (LoaiNhaCungCapEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<LoaiNhaCungCapForViewDto>(LoaiNhaCungCapEntity);
        }

        public PagedResultDto<LoaiNhaCungCapDto> GetLoaiNhaCungCaps(LoaiNhaCungCapFilter input)
        {
            var query = LoaiNhaCungCapRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaLoaiNhaCungCap != null)
            {
                query = query.Where(x => x.MaLoaiNhaCungCap.ToLower().Equals(input.MaLoaiNhaCungCap));
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
            return new PagedResultDto<LoaiNhaCungCapDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<LoaiNhaCungCapDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_LoaiNhaCungCap_Create)]
        private void Create(LoaiNhaCungCapInput loaiNhaCungCapInput)
        {
            var LoaiNhaCungCapEntity = ObjectMapper.Map<LoaiNhaCungCap>(loaiNhaCungCapInput);
            SetAuditInsert(LoaiNhaCungCapEntity);
            LoaiNhaCungCapRepository.Insert(LoaiNhaCungCapEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_LoaiNhaCungCap_Edit)]
        private void Update(LoaiNhaCungCapInput loaiNhaCungCapInput)
        {
            var LoaiNhaCungCapEntity = LoaiNhaCungCapRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == loaiNhaCungCapInput.Id);
            if (LoaiNhaCungCapEntity == null)
            {
            }
            ObjectMapper.Map(loaiNhaCungCapInput, LoaiNhaCungCapEntity);
            SetAuditEdit(LoaiNhaCungCapEntity);
            LoaiNhaCungCapRepository.Update(LoaiNhaCungCapEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
