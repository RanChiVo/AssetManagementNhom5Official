using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.SuaChuaBatDongSan.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.SuaChuaSuaChuaBatDongSan;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models.RealEstasAsset.QuanLyBDS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using GWebsite.AbpZeroTemplate.Core.Models.TaiSan13;

namespace GWebsite.AbpZeroTemplate.Web.Core.SuaChuaBatDongSans
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_SuaChuaBatDongSan)]
    public class SuaChuaBatDongSanAppService : GWebsiteAppServiceBase, ISuaChuaBatDongSanAppService
    {
        private readonly IRepository<SuaChuaBatDongSan> suaChuaBatDongSanRepository;
        private readonly IRepository<TaiSan_13> taisanRepos;
        public SuaChuaBatDongSanAppService(IRepository<SuaChuaBatDongSan> suaChuaBatDongSanRepository,IRepository<TaiSan_13> taisanRepos)
        {
            this.suaChuaBatDongSanRepository = suaChuaBatDongSanRepository;
            this.taisanRepos = taisanRepos;
        }

        #region Public Method

        public void CreateOrEditSuaChuaBatDongSan(SuaChuaBatDongSanInput suaChuaBatDongSanInput)
        {
            if (suaChuaBatDongSanInput.Id == 0)
            {
                Create(suaChuaBatDongSanInput);
            }
            else
            {
                Update(suaChuaBatDongSanInput);
            }
        }

        public void DeleteSuaChuaBatDongSan(int id)
        {
            var suaChuaBatDongSanEntity = suaChuaBatDongSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (suaChuaBatDongSanEntity != null)
            {
                suaChuaBatDongSanEntity.IsDelete = true;
                suaChuaBatDongSanRepository.Update(suaChuaBatDongSanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public SuaChuaBatDongSanInput GetSuaChuaBatDongSanForEdit(int id)
        {
            var suaChuaBatDongSanEntity = suaChuaBatDongSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (suaChuaBatDongSanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<SuaChuaBatDongSanInput>(suaChuaBatDongSanEntity);
        }

        public SuaChuaBatDongSanForViewDto GetSuaChuaBatDongSanForView(int id)
        {
            var suaChuaBatDongSanEntity = suaChuaBatDongSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (suaChuaBatDongSanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<SuaChuaBatDongSanForViewDto>(suaChuaBatDongSanEntity);
        }

        public PagedResultDto<SuaChuaBatDongSanDto> GetSuaChuaBatDongSans(SuaChuaBatDongSanFilter input)
        {
            var query = suaChuaBatDongSanRepository.GetAll().Where(x => !x.IsDelete);
            var lquery = taisanRepos.GetAll().Where(x => !x.IsDelete);
            // filter by ngaydexuat
            if (input.NgayDeXuat != null)
            {
                query = query.Where(x => x.NgayDeXuat.ToLower().Equals(input.NgayDeXuat));
            }
            if (input.NgaySuaXong != null)
            {
                query = query.Where(x => x.NgaySuaXong.ToLower().Equals(input.NgaySuaXong));
            }

            if (input.MaTaiSan != null)
            {
                query = query.Where(x => x.MaTaiSan.ToLower().Equals(input.MaTaiSan));
            }




            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();


            var jointable = from sc in query
                            join ts in lquery
                            on sc.MaTaiSan equals ts.MaTaiSan
                            select new SuaChuaBatDongSanDto
                            {
                                Id = sc.Id,
                                MaTaiSan = sc.MaTaiSan,
                                TenTaiSan = ts.TenTaiSan,
                                NgayDeXuat = sc.NgayDeXuat,
                                NgaySuaXong = sc.NgaySuaXong,
                                ChiPhiDuKien = sc.ChiPhiDuKien,
                                ChiPhiSuaChuaThucTe = sc.ChiPhiSuaChuaThucTe,
                                NguoiDeXuat = sc.NguoiDeXuat,
                                NhanVienPhuTrach = sc.NhanVienPhuTrach,
                                TrangThaiSuaChua = sc.TrangThaiSuaChua,


                            };

            // result
            return new PagedResultDto<SuaChuaBatDongSanDto>(
                totalCount,
               jointable.ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_SuaChuaBatDongSan_Create)]
        private void Create(SuaChuaBatDongSanInput suaChuaBatDongSanInput)
        {
            suaChuaBatDongSanInput.MaSuaChuaBatDongSan = "SC" +suaChuaBatDongSanInput.MaTaiSan ;
            var suaChuaBatDongSanEntity = ObjectMapper.Map<SuaChuaBatDongSan>(suaChuaBatDongSanInput);
            SetAuditInsert(suaChuaBatDongSanEntity);
            suaChuaBatDongSanRepository.Insert(suaChuaBatDongSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_SuaChuaBatDongSan_Edit)]
        private void Update(SuaChuaBatDongSanInput suaChuaBatDongSanInput)
        {
            var suaChuaBatDongSanEntity = suaChuaBatDongSanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == suaChuaBatDongSanInput.Id);
            if (suaChuaBatDongSanEntity == null)
            {
            }
            ObjectMapper.Map(suaChuaBatDongSanInput, suaChuaBatDongSanEntity);
            SetAuditEdit(suaChuaBatDongSanEntity);
            suaChuaBatDongSanRepository.Update(suaChuaBatDongSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
