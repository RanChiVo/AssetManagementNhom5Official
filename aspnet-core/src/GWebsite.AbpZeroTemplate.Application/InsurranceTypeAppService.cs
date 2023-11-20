using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.InsurranceTypes;
using GWebsite.AbpZeroTemplate.Application.Share.InsurranceTypes.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.InsurranceTypes
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_InsurranceType)]
    public class InsurranceTypeAppService : GWebsiteAppServiceBase, IInsurranceTypeAppService
    {
        private readonly IRepository<InsurranceType> insurrancetypeRepository;

        public InsurranceTypeAppService(IRepository<InsurranceType> insurrancetypeRepository)
        {
            this.insurrancetypeRepository = insurrancetypeRepository;
        }

        #region Public Method

        public void CreateOrEditInsurranceType(InsurranceTypeInput insurrancetypeInput)
        {
            if (insurrancetypeInput.Id == 0)
            {
                Create(insurrancetypeInput);
            }
            else
            {
                Update(insurrancetypeInput);
            }
        }

        public void DeleteInsurranceType(int id)
        {
            var insurrancetypeEntity = insurrancetypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (insurrancetypeEntity != null)
            {
                insurrancetypeEntity.IsDelete = true;
                insurrancetypeRepository.Update(insurrancetypeEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public InsurranceTypeInput GetInsurranceTypeForEdit(int id)
        {
            var insurrancetypeEntity = insurrancetypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (insurrancetypeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<InsurranceTypeInput>(insurrancetypeEntity);
        }

        public InsurranceTypeForViewDto GetInsurranceTypeForView(int id)
        {
            var insurrancetypeEntity = insurrancetypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (insurrancetypeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<InsurranceTypeForViewDto>(insurrancetypeEntity);
        }

        public PagedResultDto<InsurranceTypeDto> GetInsurranceTypes(InsurranceTypeFilter input)
        {
            var query = insurrancetypeRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.InsurranceTypeName != null)
            {
                query = query.Where(x => x.InsurranceTypeName.ToLower().Equals(input.InsurranceTypeName));
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
            return new PagedResultDto<InsurranceTypeDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<InsurranceTypeDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_InsurranceType_Create)]
        private void Create(InsurranceTypeInput insurrancetypeInput)
        {
            var insurrancetypeEntity = ObjectMapper.Map<InsurranceType>(insurrancetypeInput);
            SetAuditInsert(insurrancetypeEntity);
            insurrancetypeRepository.Insert(insurrancetypeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_InsurranceType_Edit)]
        private void Update(InsurranceTypeInput insurrancetypeInput)
        {
            var insurrancetypeEntity = insurrancetypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == insurrancetypeInput.Id);
            if (insurrancetypeEntity == null)
            {
            }
            ObjectMapper.Map(insurrancetypeInput, insurrancetypeEntity);
            SetAuditEdit(insurrancetypeEntity);
            insurrancetypeRepository.Update(insurrancetypeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
