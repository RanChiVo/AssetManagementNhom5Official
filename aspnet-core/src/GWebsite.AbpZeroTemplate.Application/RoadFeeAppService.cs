using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.RoadFeeVehicles;
using GWebsite.AbpZeroTemplate.Application.Share.RoadFeeVehicles.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.RoadFeeVehicles
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_RoadFeeVehicle)]
    public class RoadFeeVehicleAppService : GWebsiteAppServiceBase, IRoadFeeVehicleAppService
    {
        private readonly IRepository<RoadFeeVehicle> roadfeevehicleRepository;

        public RoadFeeVehicleAppService(IRepository<RoadFeeVehicle> roadfeeVehicleRepository)
        {
            this.roadfeevehicleRepository = roadfeeVehicleRepository;
        }

        #region Public Method

        public void CreateOrEditRoadFeeVehicle(RoadFeeVehicleInput roadfeevehicleInput)
        {
            if (roadfeevehicleInput.Id == 0)
            {
                Create(roadfeevehicleInput);
            }
            else
            {
                Update(roadfeevehicleInput);
            }
        }

        public void DeleteRoadFeeVehicle(int id)
        {
            var roadfeevehicleEntity = roadfeevehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (roadfeevehicleEntity != null)
            {
                roadfeevehicleEntity.IsDelete = true;
                roadfeevehicleRepository.Update(roadfeevehicleEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public RoadFeeVehicleInput GetRoadFeeVehicleForEdit(int id)
        {
            var roadfeevehicleEntity = roadfeevehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (roadfeevehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RoadFeeVehicleInput>(roadfeevehicleEntity);
        }

        public RoadFeeVehicleForViewDto GetRoadFeeVehicleForView(int id)
        {
            var roadfeevehicleEntity = roadfeevehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (roadfeevehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<RoadFeeVehicleForViewDto>(roadfeevehicleEntity);
        }

        public PagedResultDto<RoadFeeVehicleDto> GetRoadFeeVehicles(RoadFeeVehicleFilter input)
        {
            var query = roadfeevehicleRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.MaPhiDuongBo != null)
            {
                query = query.Where(x => x.MaPhiDuongBo.ToLower().Equals(input.MaPhiDuongBo));
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
            return new PagedResultDto<RoadFeeVehicleDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<RoadFeeVehicleDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_RoadFeeVehicle_Create)]
        private void Create(RoadFeeVehicleInput roadfeevehicleInput)
        {
            var roadfeevehicleEntity = ObjectMapper.Map<RoadFeeVehicle>(roadfeevehicleInput);
            SetAuditInsert(roadfeevehicleEntity);
            roadfeevehicleRepository.Insert(roadfeevehicleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_RoadFeeVehicle_Edit)]
        private void Update(RoadFeeVehicleInput roadfeevehicleInput)
        {
            var roadfeevehicleEntity = roadfeevehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == roadfeevehicleInput.Id);
            if (roadfeevehicleEntity == null)
            {
            }
            ObjectMapper.Map(roadfeevehicleInput, roadfeevehicleEntity);
            SetAuditEdit(roadfeevehicleEntity);
            roadfeevehicleRepository.Update(roadfeevehicleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}