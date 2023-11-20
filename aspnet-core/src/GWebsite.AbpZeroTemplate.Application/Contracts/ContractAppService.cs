using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Bids;
using GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Suppliers;
using GWebsite.AbpZeroTemplate.Application.Share.Suppliers.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace GWebsite.AbpZeroTemplate.Web.Core.Contracts
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Contract)]
    public class ContractAppService : GWebsiteAppServiceBase, IContractAppService
    {
        private readonly IRepository<Contract> contractRepository;
        private readonly IRepository<Bid> bidRepository;
        private readonly IRepository<Supplier> supplierRepository;

        public ContractAppService(IRepository<Contract> contractRepository, IRepository<Bid> bidRepository, IRepository<Supplier> supplierRepository)
        {
            this.contractRepository = contractRepository;
            this.bidRepository = bidRepository;
            this.supplierRepository = supplierRepository;
        }

        #region Public Method

        public void CreateOrEditContract(ContractInput contractInput)
        {
            if (contractInput.Id == 0)
            {
                Create(contractInput);
            }
            else
            {
                Update(contractInput);
            }
        }

        public void DeleteContract(int id)
        {
            var contractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (contractEntity != null)
            {
                contractEntity.IsDelete = true;
                contractRepository.Update(contractEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ContractInput GetContractForEdit(int id)
        {
            var contractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (contractEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ContractInput>(contractEntity);
        }

        public ContractForViewDto GetContractForView(int id)
        {
            var contractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (contractEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ContractForViewDto>(contractEntity);
        }

        public PagedResultDto<ContractDto> GetContracts(ContractFilter input)
        {
            var query = contractRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.ContractName != null)
            {
                query = query.Where(x => x.ContractName.ToLower().Equals(input.ContractName));
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
            return new PagedResultDto<ContractDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ContractDto>(item)).ToList());
        }

        public async Task<BidOutput> GetBidComboboxForEditAsync(NullableIdDto input)
        {
            Bid hoSoThau = null;
            if (input.Id.HasValue && input.Id.Value > 0)
            {
                hoSoThau = await bidRepository.GetAsync(input.Id.Value);
            }
            var output = new BidOutput();

            output.Bid = hoSoThau != null
                ? ObjectMapper.Map<BidDto>(hoSoThau)
                : new BidDto();

            output.Bids = await bidRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.BidCode))
                .ToListAsync();

            return output;
        }

        public async Task<SupplierOutput> GetSupplierComboboxForEditAsync(NullableIdDto input)
        {
            Supplier nhaCungCap = null;
            if (input.Id.HasValue && input.Id.Value > 0)
            {
                nhaCungCap = await supplierRepository.GetAsync(input.Id.Value);
            }
            var output = new SupplierOutput();

            output.Supplier = nhaCungCap != null
                ? ObjectMapper.Map<SupplierDto>(nhaCungCap)
                : new SupplierDto();

            output.Suppliers = await supplierRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.SupplierName))
                .ToListAsync();

            return output;
        }

        public async Task<ContractOutput> GetContractComboboxForEditAsync(NullableIdDto input)
        {
            Contract hopDongThau = null;
            if (input.Id.HasValue && input.Id.Value > 0)
            {
                hopDongThau = await contractRepository.GetAsync(input.Id.Value);
            }
            var output = new ContractOutput();

            output.Contract = hopDongThau != null
                ? ObjectMapper.Map<ContractDto>(hopDongThau)
                : new ContractDto();

            output.Contracts = await contractRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.ContractCode))
                .ToListAsync();

            return output;
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Contract_Create)]
        private void Create(ContractInput contractInput)
        {
            var contractEntity = ObjectMapper.Map<Contract>(contractInput);
            SetAuditInsert(contractEntity);
            contractRepository.Insert(contractEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Contract_Edit)]
        private void Update(ContractInput contractInput)
        {
            var contractEntity = contractRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == contractInput.Id);
            if (contractEntity == null)
            {
            }
            ObjectMapper.Map(contractInput, contractEntity);
            SetAuditEdit(contractEntity);
            contractRepository.Update(contractEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
