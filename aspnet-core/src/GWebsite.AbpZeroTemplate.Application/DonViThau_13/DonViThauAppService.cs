using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models.QuanLyCongTrinh_N13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau;

namespace GWebsite.AbpZeroTemplate.Web.Core.DonViThau_13
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau)]
    public class DonViThauAppService : GWebsiteAppServiceBase, IDonViThauAppService
    {
        private readonly IRepository<DonViThau_N13> taiSanRepository;

        public DonViThauAppService(IRepository<DonViThau_N13> taiSanRepository)
        {
            this.taiSanRepository = taiSanRepository;
        }

        #region Public Method

        public void CreateOrEditDonViThau(DonViThauInput taiSanInput)
        {
            if (taiSanInput.Id == 0)
            {
                Create(taiSanInput);
            }
            else
            {
                Update(taiSanInput);
            }
        }

        public void DeleteDonViThau(int id)
        {
            var taiSanEntity = taiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (taiSanEntity != null)
            {
                taiSanEntity.IsDelete = true;
                taiSanRepository.Update(taiSanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public DonViThauInput GetDonViThauForEdit(int id)
        {
            var taiSanEntity = taiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (taiSanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DonViThauInput>(taiSanEntity);
        }

        public DonViThauForViewDto GetDonViThauForView(int id)
        {
            var taiSanEntity = taiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (taiSanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DonViThauForViewDto>(taiSanEntity);
        }

        public PagedResultDto<DonViThauDto> GetDonViThaus(DonViThauFilter input)
        {
            var query = taiSanRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.MaDonViThau != null)
            {
                query = query.Where(x => x.MaDonViThau.ToLower().Equals(input.MaDonViThau));
            }

            // filter by value
            if (input.MaGoiThau != null)
            {
                query = query.Where(x => x.MaGoiThau.ToLower().Equals(input.MaGoiThau));
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
            return new PagedResultDto<DonViThauDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<DonViThauDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau_Create)]
        private void Create(DonViThauInput taiSanInput)
        {
            int nextID = taiSanRepository.GetAll().Count() + 1;
            taiSanInput.MaDonViThau = "TS000" + nextID;
            var taiSanEntity = ObjectMapper.Map<DonViThau_N13>(taiSanInput);
            SetAuditInsert(taiSanEntity);
            taiSanRepository.Insert(taiSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyCongTrinhDoDang_HoSoThau_Edit)]
        private void Update(DonViThauInput taiSanInput)
        {
            var taiSanEntity = taiSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == taiSanInput.Id);
            if (taiSanEntity == null)
            {
            }
            ObjectMapper.Map(taiSanInput, taiSanEntity);
            SetAuditEdit(taiSanEntity);
            taiSanRepository.Update(taiSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
