using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.BrandVehicles;
using GWebsite.AbpZeroTemplate.Application.Share.BrandVehicles.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.BrandVehicles
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_BrandVehicle)]
    public class BrandVehicleAppService : GWebsiteAppServiceBase, IBrandVehicleAppService
    {
        private readonly IRepository<BrandVehicle> brandvehicleRepository;

        public BrandVehicleAppService(IRepository<BrandVehicle> brandvehicleRepository)
        {
            this.brandvehicleRepository = brandvehicleRepository;
        }

        #region Public Method

        public void CreateOrEditBrandVehicle(BrandVehicleInput brandvehicleInput)
        {
            if (brandvehicleInput.Id == 0)
            {
                Create(brandvehicleInput);
            }
            else
            {
                Update(brandvehicleInput);
            }
        }

        public void DeleteBrandVehicle(int id)
        {
            var brandvehicleEntity = brandvehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (brandvehicleEntity != null)
            {
                brandvehicleEntity.IsDelete = true;
                brandvehicleRepository.Update(brandvehicleEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public BrandVehicleInput GetBrandVehicleForEdit(int id)
        {
            var brandvehicleEntity = brandvehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (brandvehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<BrandVehicleInput>(brandvehicleEntity);
        }

        public BrandVehicleForViewDto GetBrandVehicleForView(int id)
        {
            var brandvehicleEntity = brandvehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (brandvehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<BrandVehicleForViewDto>(brandvehicleEntity);
        }

        public PagedResultDto<BrandVehicleDto> GetBrandVehicles(BrandVehicleFilter input)
        {
            var query = brandvehicleRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.IdVehicle != null)
            {
                query = query.Where(x => x.IdVehicle.ToLower().Equals(input.IdVehicle));
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
            return new PagedResultDto<BrandVehicleDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<BrandVehicleDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_BrandVehicle_Create)]
        private void Create(BrandVehicleInput brandvehicleInput)
        {
            var brandvehicleEntity = ObjectMapper.Map<BrandVehicle>(brandvehicleInput);
            SetAuditInsert(brandvehicleEntity);
            brandvehicleRepository.Insert(brandvehicleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_BrandVehicle_Edit)]
        private void Update(BrandVehicleInput brandvehicleInput)
        {
            var brandvehicleEntity = brandvehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == brandvehicleInput.Id);
            if (brandvehicleEntity == null)
            {
            }
            ObjectMapper.Map(brandvehicleInput, brandvehicleEntity);
            SetAuditEdit(brandvehicleEntity);
            brandvehicleRepository.Update(brandvehicleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}