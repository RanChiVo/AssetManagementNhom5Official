using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ContractGuarantees;
using GWebsite.AbpZeroTemplate.Application.Share.ContractGuarantees.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.ContractGuarantees
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_ContractGuarantee9)]
    public class ContractGuaranteeAppService : GWebsiteAppServiceBase, IContractGuaranteeAppService
    {
        private readonly IRepository<ContractGuarantee> ContractGuaranteeRepository;

        public ContractGuaranteeAppService(IRepository<ContractGuarantee> ContractGuaranteeRepository)
        {
            this.ContractGuaranteeRepository = ContractGuaranteeRepository;
        }

        #region Public Method

        public void CreateOrEditContractGuarantee(ContractGuaranteeInput ContractGuaranteeInput)
        {
            if (ContractGuaranteeInput.Id == 0)
            {
                Create(ContractGuaranteeInput);
            }
            else
            {
                Update(ContractGuaranteeInput);
            }
        }

        public void DeleteContractGuarantee(int id)
        {
            var ContractGuaranteeEntity = ContractGuaranteeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ContractGuaranteeEntity != null)
            {
                ContractGuaranteeEntity.IsDelete = true;
                ContractGuaranteeRepository.Update(ContractGuaranteeEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ContractGuaranteeInput GetContractGuaranteeForEdit(int id)
        {
            var ContractGuaranteeEntity = ContractGuaranteeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ContractGuaranteeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ContractGuaranteeInput>(ContractGuaranteeEntity);
        }


        public ContractGuaranteeForViewDto GetContractGuaranteeForView(int id)
        {
            var ContractGuaranteeEntity = ContractGuaranteeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ContractGuaranteeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ContractGuaranteeForViewDto>(ContractGuaranteeEntity);
        }

        public PagedResultDto<ContractGuaranteeDto> GetContractGuarantees(ContractGuaranteeFilter input)
        {
            var query = ContractGuaranteeRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaBaoLanhHopDong != null)
            {
                query = query.Where(x => x.MaBaoLanhHopDong.ToLower().Equals(input.MaBaoLanhHopDong));
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
            return new PagedResultDto<ContractGuaranteeDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ContractGuaranteeDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ContractGuarantee9_Create)]
        private void Create(ContractGuaranteeInput ContractGuaranteeInput)
        {
            var ContractGuaranteeEntity = ObjectMapper.Map<ContractGuarantee>(ContractGuaranteeInput);
            SetAuditInsert(ContractGuaranteeEntity);
            ContractGuaranteeRepository.Insert(ContractGuaranteeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ContractGuarantee9_Edit)]
        private void Update(ContractGuaranteeInput ContractGuaranteeInput)
        {
            var ContractGuaranteeEntity = ContractGuaranteeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == ContractGuaranteeInput.Id);
            if (ContractGuaranteeEntity == null)
            {
            }
            ObjectMapper.Map(ContractGuaranteeInput, ContractGuaranteeEntity);
            SetAuditEdit(ContractGuaranteeEntity);
            ContractGuaranteeRepository.Update(ContractGuaranteeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
