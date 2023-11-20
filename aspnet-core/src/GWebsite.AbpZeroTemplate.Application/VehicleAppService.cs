using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Vehicles;
using GWebsite.AbpZeroTemplate.Application.Share.Vehicles.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Vehicles
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Vehicle)]
    public class VehicleAppService : GWebsiteAppServiceBase, IVehicleAppService
    {
        private readonly IRepository<Vehicle> vehicleRepository;
        private readonly IRepository<TypeVehicle> typevehicleRepository;
        private readonly IRepository<Asset_8> assetRepository;

        public VehicleAppService(IRepository<Vehicle> vehicleRepository, IRepository<TypeVehicle> typevehicleRepository, IRepository<Asset_8> assetRepository)
        {
            this.vehicleRepository = vehicleRepository;
            this.typevehicleRepository = typevehicleRepository;
            this.assetRepository = assetRepository;
        }

        #region Public Method

        public void CreateOrEditVehicle(VehicleInput vehicleInput,int selectedTS)
        {
            if (vehicleInput.Id == 0)
            {
                int nextid = vehicleRepository.GetAll().Where(x => !x.IsDelete).Count() + 1;
                vehicleInput.IdVehicle = "VH000" + nextid;
                Create(vehicleInput);
                // Lưu mã vehicle vào bảng tài sản , bằng cách edit tài sản
                UpdateTaiSan(selectedTS, vehicleInput.IdVehicle);
            }
            else
            {
                Update(vehicleInput);
            }
        }

        public void DeleteVehicle(int id)
        {
            var vehicleEntity = vehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleEntity != null)
            {
                var taiSanEntity = assetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.IdVehicle == vehicleEntity.IdVehicle);
                taiSanEntity.IdVehicle = null;
                vehicleEntity.IsDelete = true;
                vehicleRepository.Update(vehicleEntity);
                assetRepository.Update(taiSanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public VehicleInput GetVehicleForEdit(int id)
        {
            var vehicleEntity = vehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (vehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleInput>(vehicleEntity);
        }

        public VehicleForViewDto GetVehicleForView(int id)
        {
            var vehicleEntity = vehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);

            if (vehicleEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<VehicleForViewDto>(vehicleEntity);
        }

        public PagedResultDto<VehicleDto> GetVehicles(VehicleFilter input)
        {
            var query = vehicleRepository.GetAll().Where(x => !x.IsDelete);
            var tsquery=assetRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
            if (input.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(input.Name.ToLower()));
            }

    


            var listVehicle = from vh in query
                              join ts in tsquery
                              on vh.IdVehicle equals ts.IdVehicle
                              select new VehicleDto
                              {
                                  MaTaiSan = ts.MaTaiSan,
                                  TenTaiSan = ts.TenTaiSan,
                                  NguyenGiaTaiSan = ts.NguyenGiaTaiSan,
                                  IdTypeCar = vh.IdTypeCar,
                                  Color = vh.Color,
                                  Status = vh.Status,
                                  HostName = vh.HostName,
                                  Id = vh.Id,
                                  IdVehicle = vh.IdVehicle,
                                  MachineNumber = vh.MachineNumber,
                                  Model = vh.Model,
                                  Name = vh.Name,
                                  NameEngine = vh.NameEngine,
                                  Number = vh.Number,
                                  Price = vh.Price,
                                  SoKmDaDi=vh.SoKmDaDi,
                                  DinhMucNhienLieu=vh.DinhMucNhienLieu

                              };

            if (input.MaTaiSan != null)
            {
                listVehicle = listVehicle.Where(x => x.MaTaiSan.ToLower().Contains(input.MaTaiSan.ToLower()));
            }
            var totalCount = listVehicle.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                listVehicle = listVehicle.OrderBy(input.Sorting);
            }

            // paging
            var items = listVehicle.PageBy(input).ToList();

            // result
            return new PagedResultDto<VehicleDto>(
                totalCount,
               listVehicle.ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Vehicle_Create)]
        private void Create(VehicleInput vehicleInput)
        {
            var vehicleEntity = ObjectMapper.Map<Vehicle>(vehicleInput);
            SetAuditInsert(vehicleEntity);
            vehicleRepository.Insert(vehicleEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Vehicle_Edit)]
        private void Update(VehicleInput vehicleInput)
        {
            var vehicleEntity = vehicleRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == vehicleInput.Id);
            if (vehicleEntity == null)
            {
            }
            ObjectMapper.Map(vehicleInput, vehicleEntity);
            SetAuditEdit(vehicleEntity);
            vehicleRepository.Update(vehicleEntity);
           // CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Vehicle_Create)]
        private void UpdateTaiSan(int selectedTS,string maVehicle)
        {
            var taiSanEntity = assetRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == selectedTS);
            if (taiSanEntity == null)
            {
                return;
            }
            taiSanEntity.IdVehicle = maVehicle;
            // SetAuditEdit(taiSanEntity);
            assetRepository.Update(taiSanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}