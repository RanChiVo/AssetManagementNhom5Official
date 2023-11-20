using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.TypeVehicles;
using GWebsite.AbpZeroTemplate.Application.Share.TypeVehicles.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.TypeVehicles
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_TypeVehicle)]
    public class TypeVehicleAppService : GWebsiteAppServiceBase, ITypeVehicleAppService
    {
        private readonly IRepository<TypeVehicle> typevehicleRepository;

        public TypeVehicleAppService(IRepository<TypeVehicle> typevehicleRepository)
        {
            this.typevehicleRepository = typevehicleRepository;
        }

        #region Public Method

        public void CreateOrEditTypeVehicle(TypeVehicleInput typevehicleInput)
        {
            if (typevehicleInput.Id == 0)
            {
                Create(typevehicleInput);
            }
            else
            {
                Update(typevehicleInput);
            }
        }

        public void DeleteTypeVehicle(int id)
        {
            var typevehicleEntity = typevehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (typevehicleEntity != null)
            {
                typevehicleEntity.IsDelete = true;
                typevehicleRepository.Update(typevehicleEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public TypeVehicleInput GetTypeVehicleForEdit(int id)
        {
            var typevehicleEntity = typevehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (typevehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TypeVehicleInput>(typevehicleEntity);
        }

        public TypeVehicleForViewDto GetTypeVehicleForView(int id)
        {
            var typevehicleEntity = typevehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (typevehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<TypeVehicleForViewDto>(typevehicleEntity);
        }

     
        public PagedResultDto<TypeVehicleDto> GetTypeVehicles(TypeVehicleFilter input)
        {
            var query = typevehicleRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.IdTypeCar != null)
            {
                query = query.Where(x => x.NameTypeCar.ToLower().Equals(input.IdTypeCar));
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
            return new PagedResultDto<TypeVehicleDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<TypeVehicleDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_TypeVehicle_Create)]
        private void Create(TypeVehicleInput typevehicleInput)
        {
            var typevehicleEntity = ObjectMapper.Map<TypeVehicle>(typevehicleInput);
            SetAuditInsert(typevehicleEntity);
            typevehicleRepository.Insert(typevehicleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_TypeVehicle_Edit)]
        private void Update(TypeVehicleInput typevehicleInput)
        {
            var typevehicleEntity = typevehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == typevehicleInput.Id);
            if (typevehicleEntity == null)
            {
            }
            ObjectMapper.Map(typevehicleInput, typevehicleEntity);
            SetAuditEdit(typevehicleEntity);
            typevehicleRepository.Update(typevehicleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}