using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.HienTrangPhapLy;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.HienTrangPhapLy.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.HienTrangPhapLys
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_HienTrangPhapLy)]
    public class HienTrangPhapLyAppService : GWebsiteAppServiceBase, IHienTrangPhapLyAppService
    {
        private readonly IRepository<HienTrangPhapLy> hienTrangPhapLyRepository;

        public HienTrangPhapLyAppService(IRepository<HienTrangPhapLy> hienTrangPhapLyRepository)
        {
            this.hienTrangPhapLyRepository = hienTrangPhapLyRepository;
        }

        #region Public Method

        public void CreateOrEditHienTrangPhapLy(HienTrangPhapLyInput hienTrangPhapLyInput)
        {
            if (hienTrangPhapLyInput.Id == 0)
            {
                Create(hienTrangPhapLyInput);
            }
            else
            {
                Update(hienTrangPhapLyInput);
            }
        }

        public void DeleteHienTrangPhapLy(int id)
        {
            var hienTrangPhapLyEntity = hienTrangPhapLyRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hienTrangPhapLyEntity != null)
            {
                hienTrangPhapLyEntity.IsDelete = true;
                hienTrangPhapLyRepository.Update(hienTrangPhapLyEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public HienTrangPhapLyInput GetHienTrangPhapLyForEdit(int id)
        {
            var hienTrangPhapLyEntity = hienTrangPhapLyRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hienTrangPhapLyEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<HienTrangPhapLyInput>(hienTrangPhapLyEntity);
        }

        public HienTrangPhapLyForViewDto GetHienTrangPhapLyForView(int id)
        {
            var hienTrangPhapLyEntity = hienTrangPhapLyRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hienTrangPhapLyEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<HienTrangPhapLyForViewDto>(hienTrangPhapLyEntity);
        }

        public PagedResultDto<HienTrangPhapLyDto> GetHienTrangPhapLys(HienTrangPhapLyFilter input)
        {
            var query = hienTrangPhapLyRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<HienTrangPhapLyDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<HienTrangPhapLyDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_HienTrangPhapLy_Create)]
        private void Create(HienTrangPhapLyInput hienTrangPhapLyInput)
        {
            var hienTrangPhapLyEntity = ObjectMapper.Map<HienTrangPhapLy>(hienTrangPhapLyInput);
            SetAuditInsert(hienTrangPhapLyEntity);
            hienTrangPhapLyRepository.Insert(hienTrangPhapLyEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_HienTrangPhapLy_Edit)]
        private void Update(HienTrangPhapLyInput hienTrangPhapLyInput)
        {
            var hienTrangPhapLyEntity = hienTrangPhapLyRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == hienTrangPhapLyInput.Id);
            if (hienTrangPhapLyEntity == null)
            {
            }
            ObjectMapper.Map(hienTrangPhapLyInput, hienTrangPhapLyEntity);
            SetAuditEdit(hienTrangPhapLyEntity);
            hienTrangPhapLyRepository.Update(hienTrangPhapLyEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
