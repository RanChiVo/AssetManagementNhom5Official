using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HoSoThau_N13;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HoSoThau_N13.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models.QuanLyCongTrinh_N13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;

namespace GWebsite.AbpZeroTemplate.Web.Core.HoSoThau13
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau)]
    public class HoSoThauN13AppService : GWebsiteAppServiceBase, IHoSoThauN13AppService
    {
        private readonly IRepository<HoSoThau_N13> hoSoThauRepository;

        public HoSoThauN13AppService(IRepository<HoSoThau_N13> hoSoThauRepository)
        {
            this.hoSoThauRepository = hoSoThauRepository;
        }

        #region Public Method

        public void CreateOrEditHoSoThau(HoSoThauN13Input hoSoThauInput)
        {
            if (hoSoThauInput.Id == 0)
            {
                Create(hoSoThauInput);
            }
            else
            {
                Update(hoSoThauInput);
            }
        }

        public void DeleteHoSoThau(int id)
        {
            var hoSoThauEntity = hoSoThauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hoSoThauEntity != null)
            {
                hoSoThauEntity.IsDelete = true;
                hoSoThauRepository.Update(hoSoThauEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public HoSoThauN13Input GetHoSoThauForEdit(int id)
        {
            var hoSoThauEntity = hoSoThauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hoSoThauEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<HoSoThauN13Input>(hoSoThauEntity);
        }

        public HoSoThauN13ForViewDto GetHoSoThauForView(int id)
        {
            var hoSoThauEntity = hoSoThauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (hoSoThauEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<HoSoThauN13ForViewDto>(hoSoThauEntity);
        }

        public PagedResultDto<HoSoThauN13Dto> GetHoSoThaus(HoSoThauN13Filter input)
        {
            var query = hoSoThauRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.MaHoSoThau != null)
            {
                query = query.Where(x => x.MaHoSoThau.ToLower().Equals(input.MaHoSoThau));
            }

            // filter by value
            if (input.MaCongTrinh != null)
            {
                query = query.Where(x => x.MaCongTrinh.ToLower().Equals(input.MaCongTrinh));
            }
            // filter by value
            if (input.NgayNhapHoSoThau != null)
            {
                query = query.Where(x => x.NgayNhapHoSoThau.ToLower().Equals(input.NgayNhapHoSoThau));
            }
            // filter by value
            if (input.NgayHetHanNopHoSoThau != null)
            {
                query = query.Where(x => x.NgayHetHanNopHoSoThau.ToLower().Equals(input.NgayHetHanNopHoSoThau));
            }
            // filter by value
            if (input.HangMucThau != null)
            {
                query = query.Where(x => x.HangMucThau.ToLower().Equals(input.HangMucThau));
            }
            // filter by value
            if (input.MaHinhThucThau != null)
            {
                query = query.Where(x => x.MaHinhThucThau.ToLower().Equals(input.MaHinhThucThau));
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
            return new PagedResultDto<HoSoThauN13Dto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<HoSoThauN13Dto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau_Create)]
        private void Create(HoSoThauN13Input hoSoThauInput)
        {
            int nextID = hoSoThauRepository.GetAll().Count() + 1;
            hoSoThauInput.MaHoSoThau = "TS000" + nextID;
            var hoSoThauEntity = ObjectMapper.Map<HoSoThau_N13>(hoSoThauInput);
            SetAuditInsert(hoSoThauEntity);
            hoSoThauRepository.Insert(hoSoThauEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau_Edit)]
        private void Update(HoSoThauN13Input hoSoThauInput)
        {
            var hoSoThauEntity = hoSoThauRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == hoSoThauInput.Id);
            if (hoSoThauEntity == null)
            {
            }
            ObjectMapper.Map(hoSoThauInput, hoSoThauEntity);
            SetAuditEdit(hoSoThauEntity);
            hoSoThauRepository.Update(hoSoThauEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
