using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstateRepairs;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstateRepairs.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.RealEstateRepairs
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_RealEstateRepair9)]
    public class RealEstateRepairAppService : GWebsiteAppServiceBase, IRealEstateRepairAppService
    {
        private readonly IRepository<RealEstateRepair_9> RealEstateRepairRepository;

        public RealEstateRepairAppService(IRepository<RealEstateRepair_9> RealEstateRepairRepository)
        {
            this.RealEstateRepairRepository = RealEstateRepairRepository;
        }

        #region Public Method

        public void CreateOrEditRealEstateRepair(RealEstateRepairInput_9 RealEstateRepairInput)
        {
            if (RealEstateRepairInput.Id == 0)
            {
                Create(RealEstateRepairInput);
            }
            else
            {
                Update(RealEstateRepairInput);
            }
        }

        public void DeleteRealEstateRepair(int id)
        {
            var RealEstateRepairEntity = RealEstateRepairRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (RealEstateRepairEntity != null)
            {
                RealEstateRepairEntity.IsDelete = true;
                RealEstateRepairRepository.Update(RealEstateRepairEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public RealEstateRepairInput_9 GetRealEstateRepairForEdit(int id)
        {
            var RealEstateRepairEntity = RealEstateRepairRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (RealEstateRepairEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RealEstateRepairInput_9>(RealEstateRepairEntity);
        }



        public RealEstateRepairForViewDto_9 GetRealEstateRepairForView(int id)
        {
            var RealEstateRepairEntity = RealEstateRepairRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (RealEstateRepairEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RealEstateRepairForViewDto_9>(RealEstateRepairEntity);
        }

        public PagedResultDto<RealEstateRepairDto_9> GetRealEstateRepairs(RealEstateRepairFilter_9 input)
        {
            var query = RealEstateRepairRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaTaiSan != null)
            {
                query = query.Where(x => x.MaTaiSan.ToLower().Equals(input.MaTaiSan));
            }
            if (input.TenTaiSan != null)
            {
                query = query.Where(x => x.TenTaiSan.ToLower().Equals(input.TenTaiSan));
            }
            if (input.NguoiDeXuat != null)
            {
                query = query.Where(x => x.NguoiDeXuat.ToLower().Equals(input.NguoiDeXuat));
            }
            if (input.NgayDeXuat != null)
            {
                query = query.Where(x => x.NgayDeXuat.ToLower().Equals(input.NgayDeXuat));
            }

            if (input.NgaySuaChuaXong != null)
            {
                query = query.Where(x => x.NgayDeXuat.ToLower().Equals(input.NgayDeXuat));
            }

            if (input.TrangThaiDuyet != null)
            {
                query = query.Where(x => x.TrangThaiDuyet.ToLower().Equals(input.TrangThaiDuyet));
            }
            if (input.NhanVienPhuTrach != null)
            {
                query = query.Where(x => x.NhanVienPhuTrach.ToLower().Equals(input.NhanVienPhuTrach));
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
            return new PagedResultDto<RealEstateRepairDto_9>(
                totalCount,
                items.Select(item => ObjectMapper.Map<RealEstateRepairDto_9>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_RealEstateRepair9_Create)]
        private void Create(RealEstateRepairInput_9 RealEstateRepairInput)
        {
            var RealEstateRepairEntity = ObjectMapper.Map<RealEstateRepair_9>(RealEstateRepairInput);
            SetAuditInsert(RealEstateRepairEntity);
            RealEstateRepairRepository.Insert(RealEstateRepairEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_RealEstateRepair9_Edit)]
        private void Update(RealEstateRepairInput_9 RealEstateRepairInput)
        {
            var RealEstateRepairEntity = RealEstateRepairRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == RealEstateRepairInput.Id);
            if (RealEstateRepairEntity == null)
            {
            }
            ObjectMapper.Map(RealEstateRepairInput, RealEstateRepairEntity);
            SetAuditEdit(RealEstateRepairEntity);
            RealEstateRepairRepository.Update(RealEstateRepairEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
