using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstates;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstates.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.RealEstates
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_RealEstate9)]
    public class RealEstateAppService : GWebsiteAppServiceBase, IRealEstateAppService
    {
        private readonly IRepository<RealEstate_9> realEstateRepository;

        public RealEstateAppService(IRepository<RealEstate_9> realEstateRepository)
        {
            this.realEstateRepository = realEstateRepository;
        }

        #region Public Method

        public void CreateOrEditRealEstate(RealEstateInput_9 realEstateInput)
        {
            if (realEstateInput.Id == 0)
            {
                Create(realEstateInput);
            }
            else
            {
                Update(realEstateInput);
            }
        }

        //public RealEstateDto_9 CreateOrEditRealEstate(RealEstateInput_9 realEstateInput)
        //{
        //    RealEstate_9 realEstateEntity = null;
        //    if (realEstateInput.Id == 0)
        //    {
        //        realEstateEntity = ObjectMapper.Map<RealEstate_9>(realEstateInput);
        //        SetAuditInsert(realEstateEntity);
        //        realEstateRepository.Insert(realEstateEntity);
        //        CurrentUnitOfWork.SaveChanges();
        //    }
        //    else
        //    {
        //        // Update
        //        realEstateEntity = realEstateRepository.GetAll().SingleOrDefault(x => x.Id == realEstateInput.Id);
        //        if (realEstateEntity == null)
        //        {
        //            return null;
        //        }
        //        ObjectMapper.Map(realEstateInput, realEstateEntity);
        //        SetAuditEdit(realEstateEntity);
        //        realEstateRepository.Update(realEstateEntity);
        //        CurrentUnitOfWork.SaveChanges();
        //    }

        //    return ObjectMapper.Map<RealEstateDto_9>(realEstateEntity);
        //}

        public void DeleteRealEstate(int id)
        {
            var realEstateEntity = realEstateRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (realEstateEntity != null)
            {
                realEstateEntity.IsDelete = true;
                realEstateRepository.Update(realEstateEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public RealEstateInput_9 GetRealEstateForEdit(int id)
        {
            var realEstateEntity = realEstateRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (realEstateEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RealEstateInput_9>(realEstateEntity);
        }

        public RealEstateInput_9 GetRealEstateForEditWithMTS(string mts)
        {
            var realEstateEntity = realEstateRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.MaTaiSan == mts);
            if (realEstateEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RealEstateInput_9>(realEstateEntity);
        }

        public RealEstateForViewDto_9 GetRealEstateForView(int id)
        {
            var realEstateEntity = realEstateRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (realEstateEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RealEstateForViewDto_9>(realEstateEntity);
        }

        public PagedResultDto<RealEstateDto_9> GetRealEstates(RealEstateFilter_9 input)
        {
            var query = realEstateRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaTaiSan != null)
            {
                query = query.Where(x => x.MaTaiSan.ToLower().Equals(input.MaTaiSan));
            }
            if (input.MaLoaiBatDongSan != null)
            {
                query = query.Where(x => x.MaLoaiBatDongSan.ToLower().Equals(input.MaLoaiBatDongSan));
            }
            if (input.MaBatDongSan != null)
            {
                query = query.Where(x => x.MaBatDongSan.ToLower().Equals(input.MaBatDongSan));
            }
            if (input.TinhTrangSuDung != null)
            {
                query = query.Where(x => x.TinhTrangSuDung.ToLower().Equals(input.TinhTrangSuDung));
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
            return new PagedResultDto<RealEstateDto_9>(
                totalCount,
                items.Select(item => ObjectMapper.Map<RealEstateDto_9>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_RealEstate9_Create)]
        private void Create(RealEstateInput_9 realEstateInput)
        {
            var realEstateEntity = ObjectMapper.Map<RealEstate_9>(realEstateInput);
            SetAuditInsert(realEstateEntity);
            realEstateRepository.Insert(realEstateEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_RealEstate9_Edit)]
        private void Update(RealEstateInput_9 realEstateInput)
        {
            var realEstateEntity = realEstateRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == realEstateInput.Id);
            if (realEstateEntity == null)
            {
            }
            ObjectMapper.Map(realEstateInput, realEstateEntity);
            SetAuditEdit(realEstateEntity);
            realEstateRepository.Update(realEstateEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
