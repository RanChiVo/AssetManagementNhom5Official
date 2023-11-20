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
using GWebsite.AbpZeroTemplate.Application.Share.GoodsInvoices;
using GWebsite.AbpZeroTemplate.Application.Share.GoodsInvoices.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts;
using GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace GWebsite.AbpZeroTemplate.Web.Core.GoodsInvoices
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_GoodsInvoice)]
    public class GoodsInvoiceAppService : GWebsiteAppServiceBase, IGoodsInvoiceAppService
    {
        private readonly IRepository<GoodsInvoice> goodsinvoiceRepository;
        private readonly IRepository<Contract> contractRepository;
        private readonly IRepository<Supplier> supplierRepository;
        private readonly IRepository<Goods> goodsRepository;

        public GoodsInvoiceAppService(IRepository<GoodsInvoice> goodsinvoiceRepository, IRepository<Contract> contractRepository, IRepository<Supplier> supplierRepository,
            IRepository<Goods> goodsRepository)
        {
            this.goodsinvoiceRepository = goodsinvoiceRepository;
            this.contractRepository = contractRepository;
            this.supplierRepository = supplierRepository;
            this.goodsRepository = goodsRepository;
        }

        #region Public Method

        public void CreateOrEditGoodsInvoice(GoodsInvoiceInput goodsinvoiceInput)
        {
            if (goodsinvoiceInput.Id == 0)
            {
                Create(goodsinvoiceInput);
            }
            else
            {
                Update(goodsinvoiceInput);
            }
        }

        public void DeleteGoodsInvoice(int id)
        {
            var goodsinvoiceEntity = goodsinvoiceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (goodsinvoiceEntity != null)
            {
                goodsinvoiceEntity.IsDelete = true;
                goodsinvoiceRepository.Update(goodsinvoiceEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public GoodsInvoiceInput GetGoodsInvoiceForEdit(int id)
        {
            var goodsinvoiceEntity = goodsinvoiceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (goodsinvoiceEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<GoodsInvoiceInput>(goodsinvoiceEntity);
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
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.ContractName))
                .ToListAsync();

            return output;
        }

        public GoodsInvoiceForViewDto GetGoodsInvoiceForView(int id)
        {
            var goodsinvoiceEntity = goodsinvoiceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (goodsinvoiceEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<GoodsInvoiceForViewDto>(goodsinvoiceEntity);
        }

        public PagedResultDto<GoodsInvoiceDto> GetGoodsInvoices(GoodsInvoiceFilter input)
        {
            var query = goodsinvoiceRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.POName != null)
            {
                query = query.Where(x => x.POName.ToLower().Equals(input.POName));
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
            return new PagedResultDto<GoodsInvoiceDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<GoodsInvoiceDto>(item)).ToList());
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

        public IList<GoodsContract> GetGoodsContract(string ContractCode)
        {
            var contracts = contractRepository.GetAll().Where(x => !x.IsDelete);
            var suppliers = supplierRepository.GetAll().Where(x => !x.IsDelete);
            var goods = goodsRepository.GetAll().Where(x => !x.IsDelete);
            var goodshopdong =  from a in contracts
                                  join b in suppliers on a.UnitAcceptedCode equals b.SupplierCode
                                  join c in goods on a.ContractCode equals c.ContractCode
                                where a.ContractCode == ContractCode
                                select new GoodsContract
                                {
                                      GoodsContractCode = a.ContractCode,
                                      GoodsName = c.GoodsName,
                                      Type = c.Type,
                                      Price = c.Price,
                                      SupplierName = b.SupplierName
                                  };
            if (goodshopdong == null)
            {
                return null;
            }
            return goodshopdong.ToList();
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_GoodsInvoice_Create)]
        private void Create(GoodsInvoiceInput goodsinvoiceInput)
        {
            var goodsinvoiceEntity = ObjectMapper.Map<GoodsInvoice>(goodsinvoiceInput);
            SetAuditInsert(goodsinvoiceEntity);
            goodsinvoiceRepository.Insert(goodsinvoiceEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_GoodsInvoice_Edit)]
        private void Update(GoodsInvoiceInput goodsinvoiceInput)
        {
            var goodsinvoiceEntity = goodsinvoiceRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == goodsinvoiceInput.Id);
            if (goodsinvoiceEntity == null)
            {
            }
            ObjectMapper.Map(goodsinvoiceInput, goodsinvoiceEntity);
            SetAuditEdit(goodsinvoiceEntity);
            goodsinvoiceRepository.Update(goodsinvoiceEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
