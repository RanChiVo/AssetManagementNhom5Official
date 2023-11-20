using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalPlans;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalPlans.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace GWebsite.AbpZeroTemplate.Web.Core.DisposalPlans
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_DisposalPlan)]
    public class DisposalPlanAppService: GWebsiteAppServiceBase, IDisposalPlanAppService
    {
        private readonly IRepository<DisposalPlan> disposalPlanRepository;

        public DisposalPlanAppService(IRepository<DisposalPlan> disposalPlanRepository)
        {
            this.disposalPlanRepository = disposalPlanRepository;
        }

        #region Public Method

        public void CreateOrEditDisposalPlan(DisposalPlanInput disposalPlanInput)
        {
            if (disposalPlanInput.Id == 0)
            {
                Create(disposalPlanInput);
            }
            else
            {
                Update(disposalPlanInput);
            }
        }

        public void DeleteDisposalPlan(int id)
        {
            var disposalPlanEntity = disposalPlanRepository.GetAll().Where(x => !x.IsDelete && x.TinhTrang != "Đã Duyệt").SingleOrDefault(x => x.Id == id);
            if (disposalPlanEntity != null)
            {
                disposalPlanEntity.IsDelete = true;
                disposalPlanRepository.Update(disposalPlanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public DisposalPlanInput GetDisposalPlanForEdit(int id)
        {
            var disposalPlanEntity = disposalPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (disposalPlanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DisposalPlanInput>(disposalPlanEntity);
        }

        public DisposalPlanForViewDto GetDisposalPlanForView(int id)
        {
            var disposalPlanEntity = disposalPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (disposalPlanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DisposalPlanForViewDto>(disposalPlanEntity);
        }

        public PagedResultDto<DisposalPlanDto> GetDisposalPlans(DisposalPlanFilter input)
        {
            var query = disposalPlanRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.KhuVuc != null)
            {
                query = query.Where(x => x.KhuVuc.ToLower().Equals(input.KhuVuc));
            }

            if (input.PhongBan != null)
            {
                query = query.Where(x => x.PhongBan.ToLower().Equals(input.PhongBan));
            }

            if (input.MaKeHoach != null)
            {
                query = query.Where(x => x.MaKeHoach.ToLower().Equals(input.MaKeHoach));
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
            return new PagedResultDto<DisposalPlanDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<DisposalPlanDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(DisposalPlanInput disposalPlanInput)
        {
            var disposalPlanEntity = ObjectMapper.Map<DisposalPlan>(disposalPlanInput);
            SetAuditInsert(disposalPlanEntity);
            disposalPlanRepository.Insert(disposalPlanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(DisposalPlanInput disposalPlanInput)
        {
            var disposalPlanEntity = disposalPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == disposalPlanInput.Id);
            if (disposalPlanEntity == null)
            {
            }
            ObjectMapper.Map(disposalPlanInput, disposalPlanEntity);
            SetAuditEdit(disposalPlanEntity);
            disposalPlanRepository.Update(disposalPlanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
