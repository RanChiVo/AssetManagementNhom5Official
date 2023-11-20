using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.OperateVehicles;
using GWebsite.AbpZeroTemplate.Application.Share.OperateVehicles.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.OperateVehicles
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_OperateVehicle)]
    public class OperateVehicleAppService : GWebsiteAppServiceBase, IOperateVehicleAppService
    {
        private readonly IRepository<OperateVehicle> operatevehicleRepository;
   
        public OperateVehicleAppService(IRepository<OperateVehicle> operateVehicleRepository)
        {
            this.operatevehicleRepository = operateVehicleRepository;
        }

        #region Public Method

        public void CreateOrEditOperateVehicle(OperateVehicleInput operatevehicleInput)
        {
            if (operatevehicleInput.Id == 0)
            {
                Create(operatevehicleInput);
            }
            else
            {
                Update(operatevehicleInput);
            }
        }

        public void DeleteOperateVehicle(int id)
        {
            var operatevehicleEntity = operatevehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (operatevehicleEntity != null)
            {
                operatevehicleEntity.IsDelete = true;
                operatevehicleRepository.Update(operatevehicleEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public OperateVehicleInput GetOperateVehicleForEdit(int id)
        {
            var operatevehicleEntity = operatevehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (operatevehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<OperateVehicleInput>(operatevehicleEntity);
        }

        public OperateVehicleForViewDto GetOperateVehicleForView(int id)
        {
            var operatevehicleEntity = operatevehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (operatevehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<OperateVehicleForViewDto>(operatevehicleEntity);
        }

        public PagedResultDto<OperateVehicleDto> GetOperateVehicles(OperateVehicleFilter input)
        {
            var query = operatevehicleRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.NgayVanHanh != null)
            {
                query = query.Where(x => x.NgayVanHanh.ToLower().Equals(input.NgayVanHanh));
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
            return new PagedResultDto<OperateVehicleDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<OperateVehicleDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_OperateVehicle_Create)]
        private void Create(OperateVehicleInput operatevehicleInput)
        {
            var operatevehicleEntity = ObjectMapper.Map<OperateVehicle>(operatevehicleInput);
            SetAuditInsert(operatevehicleEntity);
            operatevehicleRepository.Insert(operatevehicleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_OperateVehicle_Edit)]
        private void Update(OperateVehicleInput operatevehicleInput)
        {
            var operatevehicleEntity = operatevehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == operatevehicleInput.Id);
            if (operatevehicleEntity == null)
            {
            }
            ObjectMapper.Map(operatevehicleInput, operatevehicleEntity);
            SetAuditEdit(operatevehicleEntity);
            operatevehicleRepository.Update(operatevehicleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}