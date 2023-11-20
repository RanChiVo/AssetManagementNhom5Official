using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ModelVehicles;
using GWebsite.AbpZeroTemplate.Application.Share.ModelVehicles.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.ModelVehicles
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_ModelVehicle)]
    public class ModelVehicleAppService : GWebsiteAppServiceBase, IModelVehicleAppService
    {
        private readonly IRepository<ModelVehicle> modelvehicleRepository;

        public ModelVehicleAppService(IRepository<ModelVehicle> modelvehicleRepository)
        {
            this.modelvehicleRepository = modelvehicleRepository;
        }

        #region Public Method

        public void CreateOrEditModelVehicle(ModelVehicleInput modelvehicleInput)
        {
            if (modelvehicleInput.Id == 0)
            {
                Create(modelvehicleInput);
            }
            else
            {
                Update(modelvehicleInput);
            }
        }

        public void DeleteModelVehicle(int id)
        {
            var modelvehicleEntity = modelvehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (modelvehicleEntity != null)
            {
                modelvehicleEntity.IsDelete = true;
                modelvehicleRepository.Update(modelvehicleEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ModelVehicleInput GetModelVehicleForEdit(int id)
        {
            var modelvehicleEntity = modelvehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (modelvehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ModelVehicleInput>(modelvehicleEntity);
        }

        public ModelVehicleForViewDto GetModelVehicleForView(int id)
        {
            var modelvehicleEntity = modelvehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (modelvehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ModelVehicleForViewDto>(modelvehicleEntity);
        }

        public PagedResultDto<ModelVehicleDto> GetModelVehicles(ModelVehicleFilter input)
        {
            var query = modelvehicleRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.IdModel != null)
            {
                query = query.Where(x => x.IdModel.ToLower().Equals(input.IdModel));
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
            return new PagedResultDto<ModelVehicleDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ModelVehicleDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ModelVehicle_Create)]
        private void Create(ModelVehicleInput modelvehicleInput)
        {
            var modelvehicleEntity = ObjectMapper.Map<ModelVehicle>(modelvehicleInput);
            SetAuditInsert(modelvehicleEntity);
            modelvehicleRepository.Insert(modelvehicleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ModelVehicle_Edit)]
        private void Update(ModelVehicleInput modelvehicleInput)
        {
            var modelvehicleEntity = modelvehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == modelvehicleInput.Id);
            if (modelvehicleEntity == null)
            {
            }
            ObjectMapper.Map(modelvehicleInput, modelvehicleEntity);
            SetAuditEdit(modelvehicleEntity);
            modelvehicleRepository.Update(modelvehicleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}