using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Insurrances;
using GWebsite.AbpZeroTemplate.Application.Share.Insurrances.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Insurrances
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Insurrance)]
    public class InsurranceAppService : GWebsiteAppServiceBase, IInsurranceAppService
    {
        private readonly IRepository<Insurrance> insurranceRepository;
        private readonly IRepository<InsurranceType> insurrancetypeRepository;

        public InsurranceAppService(IRepository<Insurrance> insurranceRepository, IRepository<InsurranceType> insurrancetypeRepository)
        {
            this.insurranceRepository = insurranceRepository;
            this.insurrancetypeRepository = insurrancetypeRepository;
        }

        #region Public Method

        public void CreateOrEditInsurrance(InsurranceInput insurranceInput)
        {
            if (insurranceInput.Id == 0)
            {
                int nextid = insurranceRepository.GetAll().Where(x => !x.IsDelete).Count() + 1;
                insurranceInput.InsurranceId = "BH000" + nextid;
                Create(insurranceInput);
            }
            else
            {
                Update(insurranceInput);
            }
        }

        public void DeleteInsurrance(int id)
        {
            var insurranceEntity = insurranceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (insurranceEntity != null)
            {
                insurranceEntity.IsDelete = true;
                insurranceRepository.Update(insurranceEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public InsurranceInput GetInsurranceForEdit(int id)
        {
            var insurranceEntity = insurranceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (insurranceEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<InsurranceInput>(insurranceEntity);
        }

        public InsurranceForViewDto GetInsurranceForView(int id)
        {
            var insurranceEntity = insurranceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (insurranceEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<InsurranceForViewDto>(insurranceEntity);
        }

        public PagedResultDto<InsurranceDto> GetInsurrances(InsurranceFilter input)
        {
            var query = insurranceRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.Company != null)
            {
                query = query.Where(x => x.Company.ToLower().Equals(input.Company));
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
            return new PagedResultDto<InsurranceDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<InsurranceDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Insurrance_Create)]
        private void Create(InsurranceInput insurranceInput)
        {
            var insurranceEntity = ObjectMapper.Map<Insurrance>(insurranceInput);
            SetAuditInsert(insurranceEntity);
            insurranceRepository.Insert(insurranceEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Insurrance_Edit)]
        private void Update(InsurranceInput insurranceInput)
        {
            var insurranceEntity = insurranceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == insurranceInput.Id);
            if (insurranceEntity == null)
            {
            }
            ObjectMapper.Map(insurranceInput, insurranceEntity);
            SetAuditEdit(insurranceEntity);
            insurranceRepository.Update(insurranceEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
