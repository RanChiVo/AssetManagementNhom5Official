using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Plans;
using GWebsite.AbpZeroTemplate.Application.Share.Plans.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Plans
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Plan9)]
    public class PlanAppService : GWebsiteAppServiceBase, IPlanAppService
    {
        private readonly IRepository<Plan_9> PlanRepository;

        public PlanAppService(IRepository<Plan_9> PlanRepository)
        {
            this.PlanRepository = PlanRepository;
        }

        #region Public Method

        public void CreateOrEditPlan(PlanInput PlanInput)
        {
            if (PlanInput.Id == 0)
            {
                Create(PlanInput);
            }
            else
            {
                Update(PlanInput);
            }
        }

        public void DeletePlan(int id)
        {
            var PlanEntity = PlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (PlanEntity != null)
            {
                PlanEntity.IsDelete = true;
                PlanRepository.Update(PlanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public PlanInput GetPlanForEdit(int id)
        {
            var PlanEntity = PlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (PlanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<PlanInput>(PlanEntity);
        }


        public PlanForViewDto GetPlanForView(int id)
        {
            var PlanEntity = PlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (PlanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<PlanForViewDto>(PlanEntity);
        }

        public PagedResultDto<PlanDto> GetPlans(PlanFilter input)
        {
            var query = PlanRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaDonVi != null)
            {
                query = query.Where(x => x.MaDonVi.ToLower().Equals(input.MaDonVi));
            }
            if (input.MaKeHoach != null)
            {
                query = query.Where(x => x.MaKeHoach.ToLower().Equals(input.MaKeHoach));
            }
            if (input.NgayLapKeHoach != null)
            {
                query = query.Where(x => x.NgayLapKeHoach.ToLower().Equals(input.NgayLapKeHoach));
            }
            if (input.TenKeHoach != null)
            {
                query = query.Where(x => x.TenKeHoach.ToLower().Equals(input.TenKeHoach));
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
            return new PagedResultDto<PlanDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<PlanDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Plan9_Create)]
        private void Create(PlanInput PlanInput)
        {
            var PlanEntity = ObjectMapper.Map<Plan_9>(PlanInput);
            SetAuditInsert(PlanEntity);
            PlanRepository.Insert(PlanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Plan9_Edit)]
        private void Update(PlanInput PlanInput)
        {
            var PlanEntity = PlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == PlanInput.Id);
            if (PlanEntity == null)
            {
            }
            ObjectMapper.Map(PlanInput, PlanEntity);
            SetAuditEdit(PlanEntity);
            PlanRepository.Update(PlanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
