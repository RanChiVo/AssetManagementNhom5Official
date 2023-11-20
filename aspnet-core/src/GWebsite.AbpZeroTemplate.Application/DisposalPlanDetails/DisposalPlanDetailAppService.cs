using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalPlanDetails;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalPlanDetails.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.DisposalPlanDetails
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_DisposalPlanDetail)]
    public class DisposalPlanDetailAppService: GWebsiteAppServiceBase, IDisposalPlanDetailAppService
    {
        private readonly IRepository<DisposalPlanDetail> disposalPlanRepository;

        public DisposalPlanDetailAppService(IRepository<DisposalPlanDetail> disposalPlanRepository)
        {
            this.disposalPlanRepository = disposalPlanRepository;
        }

        #region Public Method

        public void CreateOrEditDisposalPlanDetail(DisposalPlanDetailInput disposalPlanInput)
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

        public void DeleteDisposalPlanDetail(int id)
        {
            var disposalPlanEntity = disposalPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (disposalPlanEntity != null)
            {
                disposalPlanEntity.IsDelete = true;
                disposalPlanRepository.Update(disposalPlanEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public DisposalPlanDetailInput GetDisposalPlanDetailForEdit(int id)
        {
            var disposalPlanEntity = disposalPlanRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (disposalPlanEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DisposalPlanDetailInput>(disposalPlanEntity);
        }

        public PagedResultDto<DisposalPlanDetailDto> GetDisposalPlanDetails(DisposalPlanDetailFilter input)
        {
            var query = disposalPlanRepository.GetAll().Where(x => !x.IsDelete);
            // filter by value
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
            return new PagedResultDto<DisposalPlanDetailDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<DisposalPlanDetailDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
        private void Create(DisposalPlanDetailInput disposalPlanInput)
        {
            var disposalPlanEntity = ObjectMapper.Map<DisposalPlanDetail>(disposalPlanInput);
            SetAuditInsert(disposalPlanEntity);
            disposalPlanRepository.Insert(disposalPlanEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Edit)]
        private void Update(DisposalPlanDetailInput disposalPlanInput)
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
