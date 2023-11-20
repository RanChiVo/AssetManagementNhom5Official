using Abp.Authorization;
using Abp.Domain.Repositories;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.SanPhams;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.SanPhams.Dto;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;


namespace GWebsite.AbpZeroTemplate.Web.Core.SanPhams
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Product)]
    public class SanPhamAppService : GWebsiteAppServiceBase, ISanPhamAppService
    {
        private readonly IRepository<SanPham> ProductRepository;

        public SanPhamAppService(IRepository<SanPham> ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        #region Public Method

        public void CreateOrEditProduct(SanPhamInput productInput)
        {
            if (productInput.Id == 0)
            {
                Create(productInput);
            }
            else
            {
                Update(productInput);
            }
        }

        public void DeleteProduct(int id)
        {
            var ProductEntity = ProductRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ProductEntity != null)
            {
                ProductEntity.IsDelete = true;
                ProductRepository.Update(ProductEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public SanPhamInput GetProductForEdit(int id)
        {
            var ProductEntity = ProductRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ProductEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<SanPhamInput>(ProductEntity);
        }

        public SanPhamForViewDto GetProductForView(int id)
        {
            var ProductEntity = ProductRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ProductEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<SanPhamForViewDto>(ProductEntity);
        }

        public PagedResultDto<SanPhamDto> GetProducts(SanPhamFilter input)
        {
            var query = ProductRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaSanPham != null)
            {
                query = query.Where(x => x.MaSanPham.ToLower().Equals(input.MaSanPham));
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
            return new PagedResultDto<SanPhamDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<SanPhamDto>(item)).ToList());
        }
        public PagedResultDto<SanPhamDto> GetProductTypes(SanPhamFilterType input)
        {
            var query = ProductRepository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<SanPhamDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<SanPhamDto>(item)).ToList());
        }
        public PagedResultDto<SanPhamDto> GetProductNames(SanPhamFilterName input)
        {
            var query = ProductRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaNhaCungCap != null)
            {
                query = query.Where(x => x.MaNhaCungCap.ToLower().Equals(input.MaNhaCungCap));
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
            return new PagedResultDto<SanPhamDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<SanPhamDto>(item)).ToList());
        }
        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Product_Create)]
        private void Create(SanPhamInput productInput)
        {
            var ProductEntity = ObjectMapper.Map<SanPham>(productInput);
            SetAuditInsert(ProductEntity);
            ProductRepository.Insert(ProductEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Product_Edit)]
        private void Update(SanPhamInput productInput)
        {
            var ProductEntity = ProductRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == productInput.Id);
            if (ProductEntity == null)
            {
            }
            ObjectMapper.Map(productInput, ProductEntity);
            SetAuditEdit(ProductEntity);
            ProductRepository.Update(ProductEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
