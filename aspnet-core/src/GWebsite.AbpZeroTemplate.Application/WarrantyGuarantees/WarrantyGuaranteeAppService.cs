using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.WarrantyGuarantees;
using GWebsite.AbpZeroTemplate.Application.Share.WarrantyGuarantees.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.WarrantyGuarantees
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_WarrantyGuarantee9)]
    public class WarrantyGuaranteeAppService : GWebsiteAppServiceBase, IWarrantyGuaranteeAppService
    {
        private readonly IRepository<WarrantyGuarantee> WarrantyGuaranteeRepository;

        public WarrantyGuaranteeAppService(IRepository<WarrantyGuarantee> WarrantyGuaranteeRepository)
        {
            this.WarrantyGuaranteeRepository = WarrantyGuaranteeRepository;
        }

        #region Public Method

        public void CreateOrEditWarrantyGuarantee(WarrantyGuaranteeInput WarrantyGuaranteeInput)
        {
            if (WarrantyGuaranteeInput.Id == 0)
            {
                Create(WarrantyGuaranteeInput);
            }
            else
            {
                Update(WarrantyGuaranteeInput);
            }
        }

        public void DeleteWarrantyGuarantee(int id)
        {
            var WarrantyGuaranteeEntity = WarrantyGuaranteeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (WarrantyGuaranteeEntity != null)
            {
                WarrantyGuaranteeEntity.IsDelete = true;
                WarrantyGuaranteeRepository.Update(WarrantyGuaranteeEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public WarrantyGuaranteeInput GetWarrantyGuaranteeForEdit(int id)
        {
            var WarrantyGuaranteeEntity = WarrantyGuaranteeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (WarrantyGuaranteeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<WarrantyGuaranteeInput>(WarrantyGuaranteeEntity);
        }


        public WarrantyGuaranteeForViewDto GetWarrantyGuaranteeForView(int id)
        {
            var WarrantyGuaranteeEntity = WarrantyGuaranteeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (WarrantyGuaranteeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<WarrantyGuaranteeForViewDto>(WarrantyGuaranteeEntity);
        }

        public PagedResultDto<WarrantyGuaranteeDto> GetWarrantyGuarantees(WarrantyGuaranteeFilter input)
        {
            var query = WarrantyGuaranteeRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaBaoLanhBaoHanh != null)
            {
                query = query.Where(x => x.MaBaoLanhBaoHanh.ToLower().Equals(input.MaBaoLanhBaoHanh));
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
            return new PagedResultDto<WarrantyGuaranteeDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<WarrantyGuaranteeDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_WarrantyGuarantee9_Create)]
        private void Create(WarrantyGuaranteeInput WarrantyGuaranteeInput)
        {
            var WarrantyGuaranteeEntity = ObjectMapper.Map<WarrantyGuarantee>(WarrantyGuaranteeInput);
            SetAuditInsert(WarrantyGuaranteeEntity);
            WarrantyGuaranteeRepository.Insert(WarrantyGuaranteeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_WarrantyGuarantee9_Edit)]
        private void Update(WarrantyGuaranteeInput WarrantyGuaranteeInput)
        {
            var WarrantyGuaranteeEntity = WarrantyGuaranteeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == WarrantyGuaranteeInput.Id);
            if (WarrantyGuaranteeEntity == null)
            {
            }
            ObjectMapper.Map(WarrantyGuaranteeInput, WarrantyGuaranteeEntity);
            SetAuditEdit(WarrantyGuaranteeEntity);
            WarrantyGuaranteeRepository.Update(WarrantyGuaranteeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
