using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.ProductTypes;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductTypes.Dto;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;


namespace GWebsite.AbpZeroTemplate.Web.Core.ProductTypes
{

    [AbpAuthorize(GWebsitePermissions.Pages_Administration_ProductType)]
    public class ProductTypeAppService : GWebsiteAppServiceBase, IProductTypeAppService
    {
        private readonly IRepository<ProductType> ProductTypeRepository;

        public ProductTypeAppService(IRepository<ProductType> ProductTypeRepository)
        {
            this.ProductTypeRepository = ProductTypeRepository;
        }

        #region Public Method

        public void CreateOrEditProductType(ProductTypeInput productTypeInput)
        {
            if (productTypeInput.Id == 0)
            {
                Create(productTypeInput);
            }
            else
            {
                Update(productTypeInput);
            }
        }

        public void DeleteProductType(int id)
        {
            var ProductTypeEntity = ProductTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ProductTypeEntity != null)
            {
                ProductTypeEntity.IsDelete = true;
                ProductTypeRepository.Update(ProductTypeEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ProductTypeInput GetProductTypeForEdit(int id)
        {
            var ProductTypeEntity = ProductTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ProductTypeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ProductTypeInput>(ProductTypeEntity);
        }

        public ProductTypeForViewDto GetProductTypeForView(int id)
        {
            var ProductTypeEntity = ProductTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ProductTypeEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ProductTypeForViewDto>(ProductTypeEntity);
        }

        public PagedResultDto<ProductTypeDto> GetProductTypes(ProductTypeFilter input)
        {
            var query = ProductTypeRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaLoaiSanPham != null)
            {
                query = query.Where(x => x.MaLoaiSanPham.ToLower().Equals(input.MaLoaiSanPham));
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
            return new PagedResultDto<ProductTypeDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ProductTypeDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ProductType_Create)]
        private void Create(ProductTypeInput productTypeInput)
        {
            var ProductTypeEntity = ObjectMapper.Map<ProductType>(productTypeInput);
            SetAuditInsert(ProductTypeEntity);
            ProductTypeRepository.Insert(ProductTypeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_ProductType_Edit)]
        private void Update(ProductTypeInput productTypeInput)
        {
            var ProductTypeEntity = ProductTypeRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == productTypeInput.Id);
            if (ProductTypeEntity == null)
            {
            }
            ObjectMapper.Map(productTypeInput, ProductTypeEntity);
            SetAuditEdit(ProductTypeEntity);
            ProductTypeRepository.Update(ProductTypeEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}

