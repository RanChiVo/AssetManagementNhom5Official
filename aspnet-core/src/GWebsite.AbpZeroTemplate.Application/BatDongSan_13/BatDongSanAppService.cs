using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.BatDongSan;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.BatDongSan.DTO;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using GWebsite.AbpZeroTemplate.Core.Models.TaiSan13;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSan_13.Dto;

namespace GWebsite.AbpZeroTemplate.Web.Core.BatDongSans
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_BatDongSan)]
    public class BatDongSanAppService : GWebsiteAppServiceBase, IBatDongSanAppService
    {
        private readonly IRepository<BatDongSan> batdongsanRepository;
        private readonly IRepository<LoaiBatDongSan> loaiBDSRepos;
        private readonly IRepository<TaiSan_13> taisanRepos;
        private readonly IRepository<LoaiSoHuu> loaishRepos;
        public BatDongSanAppService(IRepository<BatDongSan> batdongsanRepository, IRepository<LoaiBatDongSan> loaiBDSRepos, IRepository<TaiSan_13> taisanRepos, IRepository<LoaiSoHuu> loaishRepos)
        {
            this.batdongsanRepository = batdongsanRepository;
            this.loaiBDSRepos = loaiBDSRepos;
            this.taisanRepos = taisanRepos;
            this.loaishRepos = loaishRepos;
        }

        #region Public Method

        public void CreateOrEditBatDongSan(BatDongSanInput batdongsanInput,int idTaiSan)
        {
            if (batdongsanInput.Id == 0)
            {
                batdongsanInput.MaBatDongSan = "BDS0000" + DateTime.Now.ToString("yyyyMMddHHmmss");
                Create(batdongsanInput);
                UpdateTaiSan(idTaiSan, batdongsanInput.MaBatDongSan);
            }
            else
            {
                Update(batdongsanInput);
            }
        }

        public void DeleteBatDongSan(int id)
        {
            var batdongsanEntity = batdongsanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (batdongsanEntity != null)
            {
                batdongsanEntity.IsDelete = true;
                batdongsanRepository.Update(batdongsanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public BatDongSanInput GetBatDongSanForEdit(int id)
        {
            var batdongsanEntity = batdongsanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (batdongsanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<BatDongSanInput>(batdongsanEntity);
        }

        public BatDongSanForViewDto GetBatDongSanForView(int id)
        {
            var batdongsanEntity = batdongsanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (batdongsanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<BatDongSanForViewDto>(batdongsanEntity);
        }

        public PagedResultDto<BatDongSanDto> GetBatDongSans(BatDongSanFilter input)
        {
            var query = batdongsanRepository.GetAll().Where(x => !x.IsDelete);

            var lquery = loaiBDSRepos.GetAll().Where(x => !x.IsDelete);
            var lshquery = loaishRepos.GetAll().Where(x => !x.IsDelete);
            var tsquery = taisanRepos.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.MaBatDongSan != null)
            {
                query = query.Where(x => x.MaBatDongSan.ToLower().Equals(input.MaBatDongSan));
            }


            // filter by maTaisan
            if (input.MaTaiSan != null)
            {
                query = query.Where(x => x.MaTaiSan.ToLower().Equals(input.MaTaiSan));
            }

            // filter by loai bds
            if (input.MaLoaiBDS != null)
            {
                query = query.Where(x => x.MaLoaiBDS.ToLower().Equals(input.MaLoaiBDS));
            }





            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input);
            var lbds = lquery;
           

            var jointTable = from i in items
                             join a in lbds
                             on Int32.Parse(i.MaLoaiBDS) equals  a.Id
                             join lsh in lshquery
                             on Int32.Parse(i.MaLoaiSoHuu) equals lsh.Id
                             join t in tsquery
                             on i.MaTaiSan equals t.MaTaiSan
                             select new BatDongSanDto
                             {
                                 MaBatDongSan = i.MaBatDongSan,
                                 DienTichDatNen = i.DienTichDatNen,
                                 DiaChi = t.DiaChi,
                                 DienTichXayDung = i.DienTichXayDung,
                                 ChieuDai = i.ChieuDai,
                                 ChieuRong = i.ChieuRong,
                                 ChuSoHuu = i.ChuSoHuu,
                                 CongNangSuDung = i.CongNangSuDung,
                                 FileDinhKem = i.FileDinhKem,
                                 HienTrangBDS = i.HienTrangBDS,
                                 MaLoaiBDS = a.Name,
                                 MaPhongGiaoDich = i.MaPhongGiaoDich,
                                 MaTinhTrangSuDungDat = i.MaTinhTrangSuDungDat,
                                 MaTinhTrangXayDung = i.MaTinhTrangXayDung,
                                 NgayMuaBatDongSan = i.NgayMuaBatDongSan,
                                 GhiChu = i.GhiChu,
                                 Id = i.Id,
                                 KetCauNha = i.KetCauNha,
                                 MaHienTrangPhapLy = i.MaHienTrangPhapLy,
                                 MaLoaiSoHuu = lsh.Name,
                                 MaTaiSan = i.MaTaiSan,
                                 NguyenGiaTaiSan = t.NguyenGiaTaiSan,
                                 RanhGioi = i.RanhGioi,
                             };



            var list = jointTable.PageBy(input).ToList();

            // result
            return new PagedResultDto<BatDongSanDto>(
                totalCount,
                jointTable.ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_BatDongSan_Create)]
        private void Create(BatDongSanInput batdongsanInput)
        {
           
            var batdongsanEntity = ObjectMapper.Map<BatDongSan>(batdongsanInput);
            SetAuditInsert(batdongsanEntity);
            batdongsanRepository.Insert(batdongsanEntity);
          //  CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_QuanLyBatDongSan_BatDongSan_Edit)]
        private void Update(BatDongSanInput batdongsanInput)
        {
            var batdongsanEntity = batdongsanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == batdongsanInput.Id);

            ObjectMapper.Map(batdongsanEntity, batdongsanInput);
            SetAuditEdit(batdongsanEntity);
            batdongsanRepository.Update(batdongsanEntity);
            CurrentUnitOfWork.SaveChanges();
        }
        private void UpdateTaiSan(int idTaiSan,string maBDS)
        {
            
            var taiSanEntity = taisanRepos.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == idTaiSan);
            if (taiSanEntity == null)
            {
                return;
            }
            taiSanEntity.MaBatDongSan = maBDS;
           // SetAuditEdit(taiSanEntity);
            taisanRepos.Update(taiSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }
        #endregion
    }
}
