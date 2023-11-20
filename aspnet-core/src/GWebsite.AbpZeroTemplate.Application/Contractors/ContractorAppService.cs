using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Contractors;
using GWebsite.AbpZeroTemplate.Application.Share.Contractors.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Contractors
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Contractor9)]
    public class ContractorAppService : GWebsiteAppServiceBase, IContractorAppService
    {
        private readonly IRepository<Contractors_9> ContractorRepository;

        public ContractorAppService(IRepository<Contractors_9> ContractorRepository)
        {
            this.ContractorRepository = ContractorRepository;
        }

        #region Public Method

        public void CreateOrEditContractor(ContractorInput ContractorInput)
        {
            if (ContractorInput.Id == 0)
            {
                Create(ContractorInput);
            }
            else
            {
                Update(ContractorInput);
            }
        }

        public void DeleteContractor(int id)
        {
            var ContractorEntity = ContractorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ContractorEntity != null)
            {
                ContractorEntity.IsDelete = true;
                ContractorRepository.Update(ContractorEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ContractorInput GetContractorForEdit(int id)
        {
            var ContractorEntity = ContractorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ContractorEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ContractorInput>(ContractorEntity);
        }

        public ContractorInput GetContractorForEditWithMaHoSoThau(string ma)
        {
            var ContractorEntity = ContractorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.MaHoSoThau == ma);
            if (ContractorEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ContractorInput>(ContractorEntity);
        }


        public ContractorForViewDto GetContractorForView(int id)
        {
            var ContractorEntity = ContractorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ContractorEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ContractorForViewDto>(ContractorEntity);
        }

        public PagedResultDto<ContractorDto> GetContractors(ContractorFilter input)
        {
            var query = ContractorRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaDonViThau != null)
            {
                query = query.Where(x => x.MaDonViThau.ToLower().Equals(input.MaDonViThau));
            }
            if (input.TenDonViThau != null)
            {
                query = query.Where(x => x.TenDonViThau.ToLower().Equals(input.TenDonViThau));
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
            return new PagedResultDto<ContractorDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ContractorDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Contractor9_Create)]
        private void Create(ContractorInput ContractorInput)
        {
            var ContractorEntity = ObjectMapper.Map<Contractors_9>(ContractorInput);
            SetAuditInsert(ContractorEntity);
            ContractorRepository.Insert(ContractorEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Contractor9_Edit)]
        private void Update(ContractorInput ContractorInput)
        {
            var ContractorEntity = ContractorRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == ContractorInput.Id);
            if (ContractorEntity == null)
            {
            }
            ObjectMapper.Map(ContractorInput, ContractorEntity);
            SetAuditEdit(ContractorEntity);
            ContractorRepository.Update(ContractorEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
