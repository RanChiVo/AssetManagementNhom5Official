using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ContractManagements;
using GWebsite.AbpZeroTemplate.Application.Share.ContractManagements.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.ContractManagements
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_ContractManagement9)]
    public class ContractManagementAppService : GWebsiteAppServiceBase, IContractManagementAppService
    {
        private readonly IRepository<ContractManagement> ContractManagementRepository;

        public ContractManagementAppService(IRepository<ContractManagement> ContractManagementRepository)
        {
            this.ContractManagementRepository = ContractManagementRepository;
        }

        #region Public Method

        public void CreateOrEditContractManagement(ContractManagementInput ContractManagementInput)
        {
            if (ContractManagementInput.Id == 0)
            {
                Create(ContractManagementInput);
            }
            else
            {
                Update(ContractManagementInput);
            }
        }

        public void DeleteContractManagement(int id)
        {
            var ContractManagementEntity = ContractManagementRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ContractManagementEntity != null)
            {
                ContractManagementEntity.IsDelete = true;
                ContractManagementRepository.Update(ContractManagementEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ContractManagementInput GetContractManagementForEdit(int id)
        {
            var ContractManagementEntity = ContractManagementRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ContractManagementEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ContractManagementInput>(ContractManagementEntity);
        }


        public ContractManagementForViewDto GetContractManagementForView(int id)
        {
            var ContractManagementEntity = ContractManagementRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ContractManagementEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ContractManagementForViewDto>(ContractManagementEntity);
        }

        public PagedResultDto<ContractManagementDto> GetContractManagements(ContractManagementFilter input)
        {
            var query = ContractManagementRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.SoHopDong != null)
            {
                query = query.Where(x => x.SoHopDong.ToLower().Equals(input.SoHopDong));
            }
            if (input.MaHoSoThau != null)
            {
                query = query.Where(x => x.MaHoSoThau.ToLower().Equals(input.MaHoSoThau));
            }
            if (input.MaToTrinh != null)
            {
                query = query.Where(x => x.MaToTrinh.ToLower().Equals(input.MaToTrinh));
            }
            if (input.MaCongTrinh != null)
            {
                query = query.Where(x => x.MaCongTrinh.ToLower().Equals(input.MaCongTrinh));
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
            return new PagedResultDto<ContractManagementDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ContractManagementDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ContractManagement9_Create)]
        private void Create(ContractManagementInput ContractManagementInput)
        {
            var ContractManagementEntity = ObjectMapper.Map<ContractManagement>(ContractManagementInput);
            SetAuditInsert(ContractManagementEntity);
            ContractManagementRepository.Insert(ContractManagementEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ContractManagement9_Edit)]
        private void Update(ContractManagementInput ContractManagementInput)
        {
            var ContractManagementEntity = ContractManagementRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == ContractManagementInput.Id);
            if (ContractManagementEntity == null)
            {
            }
            ObjectMapper.Map(ContractManagementInput, ContractManagementEntity);
            SetAuditEdit(ContractManagementEntity);
            ContractManagementRepository.Update(ContractManagementEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
