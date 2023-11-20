using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Constructions;
using GWebsite.AbpZeroTemplate.Application.Share.Constructions.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Constructions
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Construction9)]
    public class ConstructionAppService : GWebsiteAppServiceBase, IConstructionAppService
    {
        private readonly IRepository<Construction_9> ConstructionRepository;

        public ConstructionAppService(IRepository<Construction_9> ConstructionRepository)
        {
            this.ConstructionRepository = ConstructionRepository;
        }

        #region Public Method

        public void CreateOrEditConstruction(ConstructionInput ConstructionInput)
        {
            if (ConstructionInput.Id == 0)
            {
                Create(ConstructionInput);
            }
            else
            {
                Update(ConstructionInput);
            }
        }

        public void DeleteConstruction(int id)
        {
            var ConstructionEntity = ConstructionRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ConstructionEntity != null)
            {
                ConstructionEntity.IsDelete = true;
                ConstructionRepository.Update(ConstructionEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ConstructionInput GetConstructionForEdit(int id)
        {
            var ConstructionEntity = ConstructionRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ConstructionEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ConstructionInput>(ConstructionEntity);
        }

        public ConstructionInput GetConstructionForEditWithMaCongTrinh(string maCongTrinh)
        {
            var ConstructionEntity = ConstructionRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.MaCongTrinh == maCongTrinh);
            if (ConstructionEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ConstructionInput>(ConstructionEntity);
        }

        


        public ConstructionForViewDto GetConstructionForView(int id)
        {
            var ConstructionEntity = ConstructionRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ConstructionEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ConstructionForViewDto>(ConstructionEntity);
        }

        public PagedResultDto<ConstructionDto> GetConstructions(ConstructionFilter input)
        {
            var query = ConstructionRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaCongTrinh != null)
            {
                query = query.Where(x => x.MaCongTrinh.ToLower().Equals(input.MaCongTrinh));
            }
            if (input.MaKeHoach != null)
            {
                query = query.Where(x => x.MaKeHoach.ToLower().Equals(input.MaKeHoach));
            }
            if (input.NgayThucThiThucTe != null)
            {
                query = query.Where(x => x.NgayThucThiThucTe.ToLower().Equals(input.NgayThucThiThucTe));
            }
            if (input.TenCongTrinh != null)
            {
                query = query.Where(x => x.TenCongTrinh.ToLower().Equals(input.TenCongTrinh));
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
            return new PagedResultDto<ConstructionDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ConstructionDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Construction9_Create)]
        private void Create(ConstructionInput ConstructionInput)
        {
            var ConstructionEntity = ObjectMapper.Map<Construction_9>(ConstructionInput);
            SetAuditInsert(ConstructionEntity);
            ConstructionRepository.Insert(ConstructionEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Construction9_Edit)]
        private void Update(ConstructionInput ConstructionInput)
        {
            var ConstructionEntity = ConstructionRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == ConstructionInput.Id);
            if (ConstructionEntity == null)
            {
            }
            ObjectMapper.Map(ConstructionInput, ConstructionEntity);
            SetAuditEdit(ConstructionEntity);
            ConstructionRepository.Update(ConstructionEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
