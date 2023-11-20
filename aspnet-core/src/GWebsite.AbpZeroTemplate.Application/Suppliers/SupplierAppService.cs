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
using GWebsite.AbpZeroTemplate.Application.Share.Suppliers;
using GWebsite.AbpZeroTemplate.Application.Share.Suppliers.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Suppliers
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Supplier)]
    public class SupplierAppService : GWebsiteAppServiceBase, ISupplierAppService
    {
        private readonly IRepository<Supplier> supplierRepository;

        public SupplierAppService(IRepository<Supplier> supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        #region Public Method

        public void CreateOrEditSupplier(SupplierInput supplierInput)
        {
            if (supplierInput.Id == 0)
            {
                Create(supplierInput);
            }
            else
            {
                Update(supplierInput);
            }
        }

        public void DeleteSupplier(int id)
        {
            var supplierEntity = supplierRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (supplierEntity != null)
            {
                supplierEntity.IsDelete = true;
                supplierRepository.Update(supplierEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public SupplierInput GetSupplierForEdit(int id)
        {
            var supplierEntity = supplierRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (supplierEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<SupplierInput>(supplierEntity);
        }

        public SupplierForViewDto GetSupplierForView(int id)
        {
            var supplierEntity = supplierRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (supplierEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<SupplierForViewDto>(supplierEntity);
        }

        public PagedResultDto<SupplierDto> GetSuppliers(SupplierFilter input)
        {
            var query = supplierRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.SupplierName != null)
            {
                query = query.Where(x => x.SupplierName.ToLower().Equals(input.SupplierName));
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
            return new PagedResultDto<SupplierDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<SupplierDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Supplier_Create)]
        private void Create(SupplierInput supplierInput)
        {
            var supplierEntity = ObjectMapper.Map<Supplier>(supplierInput);
            SetAuditInsert(supplierEntity);
            supplierRepository.Insert(supplierEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Supplier_Edit)]
        private void Update(SupplierInput supplierInput)
        {
            var supplierEntity = supplierRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == supplierInput.Id);
            if (supplierEntity == null)
            {
            }
            ObjectMapper.Map(supplierInput, supplierEntity);
            SetAuditEdit(supplierEntity);
            supplierRepository.Update(supplierEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
