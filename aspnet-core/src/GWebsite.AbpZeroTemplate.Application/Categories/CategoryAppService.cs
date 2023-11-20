using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Categories;
using GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;


using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GWebsite.AbpZeroTemplate.Application.Categories.Exporting;
using Abp.Extensions;

namespace GWebsite.AbpZeroTemplate.Web.Core.Categories
{
    [AbpAuthorize(GWebsitePermissions.Pages_Categories_General)]
    public class CategoryAppService : GWebsiteAppServiceBase, ICategoryAppService
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly CategoryListExcelExporter categoryListExcelExporter;

        public CategoryAppService(
            IRepository<Category> categoryRepository,
            CategoryListExcelExporter _categoryListExcelExporter)
        {
            this.categoryRepository = categoryRepository;
            this.categoryListExcelExporter = _categoryListExcelExporter;
        }

        #region Public Method

        public void CreateCategory(CategoryInput input)
        {
            Create(input);
        }

        public void EditCategory(CategoryInput input)
        {
            Update(input);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Categories_General_Delete)]
        public void DeleteCategory(int id)
        {
            var categoryEntity = categoryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (categoryEntity != null)
            {
                categoryEntity.IsDelete = true;
                categoryEntity.UpdatedDate = DateTime.Now;
                categoryEntity.UpdatedBy = GetCurrentUser().Name;
                categoryRepository.Update(categoryEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public CategoryInput GetCategoryForEdit(int id)
        {
            var categoryEntity = categoryRepository.GetAll().SingleOrDefault(x => x.Id == id);
            if (categoryEntity == null)
            {
                return null;
            }

            CategoryInput result = ObjectMapper.Map<CategoryInput>(categoryEntity);
            
            if (categoryEntity.IsDelete == false)
            {
                result.Status = "Active";
            }
            else
            {
                result.Status = "Inactive";
            }

            return result;
        }

        public CategoryForViewDto GetCategoryForView(int id)
        {
            var categoryEntity = categoryRepository.GetAll().SingleOrDefault(x => x.Id == id);
            if (categoryEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<CategoryForViewDto>(categoryEntity);
        }

        public PagedResultDto<CategoryDto> GetCategoriesByFilter(CategoryFilter input)
        {
            //var query = categoryRepository.GetAll();

            //// filter by type
            //if (input.CategoryType != null)
            //{
            //    query = query.Where(x => x.CategoryType.ToLower().Equals(input.CategoryType));
            //}

            //// filter by id
            //if (input.CategoryId != null)
            //{
            //    query = query.Where(x => x.CategoryId.ToLower().Contains(input.CategoryId));
            //}

            //// filter by Name
            //if (input.Name != null)
            //{
            //    query = query.Where(x => x.Name.ToLower().Contains(input.Name));
            //}

            //// filter by Symbol
            //if (input.Symbol != null)
            //{
            //    query = query.Where(x => x.Symbol.ToLower().Contains(input.Symbol));
            //}

            //// filter by Status
            //if (input.Status == "Active")
            //{
            //    query = query.Where(x => x.IsDelete == false);
            //}
            //else if (input.Status == "Inactive")
            //{
            //    query = query.Where(x => x.IsDelete == true);
            //}

            var query = CreateCategoriesQuery(input);

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();
            var resultItems = items.Select(item => ObjectMapper.Map<CategoryDto>(item)).ToList();

            for (int i = 0; i < resultItems.Count(); i++)
            {
                resultItems.ElementAt(i).Status = !items.ElementAt(i).IsDelete;
            }

            return new PagedResultDto<CategoryDto>(
                totalCount,
                resultItems);
        }

        public FileDto GetCategoriesToExcel(CategoryFilter input)
        {
            var categories = CreateCategoriesQuery(input)
                .AsNoTracking()
                .ToList();

            var categoryListDtos = categories.Select(item => ObjectMapper.Map<CategoryDto>(item)).ToList();

            return categoryListExcelExporter.ExportToFile(categoryListDtos);
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Categories_General_Create)]
        private void Create(CategoryInput input)
        {
            input.CategoryId = input.CategoryId + DateTime.Now.ToString("yyyyMMddHHmmss");

            var categoryEntity = ObjectMapper.Map<Category>(input);
            categoryEntity.CreatedDate = DateTime.Now;
            categoryEntity.CreatedBy = GetCurrentUser().Name;

            if (input.Status == "Active")
            {
                categoryEntity.IsDelete = false;
            }
            else if (input.Status == "Inactive")
            {
                categoryEntity.IsDelete = true;
            }

            categoryRepository.Insert(categoryEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Categories_General_Edit)]
        private void Update(CategoryInput categoryInput)
        {
            var categoryEntity = categoryRepository.GetAll().SingleOrDefault(x => x.Id == categoryInput.Id);
            if (categoryEntity == null)
            {
            }

            ObjectMapper.Map(categoryInput, categoryEntity);

            if (categoryInput.Status == "Active")
            {
                categoryEntity.IsDelete = false;
            }
            else if (categoryInput.Status == "Inactive")
            {
                categoryEntity.IsDelete = true;
            }

            categoryEntity.CreatedDate = DateTime.Now;
            categoryEntity.CreatedBy = GetCurrentUser().Name;
            categoryRepository.Update(categoryEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private IQueryable<Category> CreateCategoriesQuery(CategoryFilter input)
        {
            var query = categoryRepository.GetAll();

            query = query
                .WhereIf(!input.CategoryType.IsNullOrWhiteSpace(), x => x.CategoryType.ToLower().Equals(input.CategoryType))
                .WhereIf(!input.CategoryId.IsNullOrWhiteSpace(), x => x.CategoryId.ToLower().Contains(input.CategoryId))
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.ToLower().Contains(input.Name))
                .WhereIf(!input.Symbol.IsNullOrWhiteSpace(), x => x.Symbol.ToLower().Contains(input.Symbol))
                .WhereIf(input.Status == "Active", x => x.IsDelete == false)
                .WhereIf(input.Status == "Inactive", x => x.IsDelete == true)
                .WhereIf(!input.Description.IsNullOrWhiteSpace(), x => x.Description.ToLower().Contains(input.Description))
                .WhereIf(input.IsCreatedCheckedAll == false, x => (x.CreatedDate >= input.StartCreatedDate && x.CreatedDate <= input.EndCreatedDate))
                .WhereIf(!input.CreatedBy.IsNullOrWhiteSpace(), x => x.CreatedBy.ToLower().Contains(input.CreatedBy.ToLower()))
                .WhereIf(input.IsUpdatedCheckedAll == false, x => (x.UpdatedDate >= input.StartUpdatedDate && x.UpdatedDate <= input.EndUpdatedDate))
                .WhereIf(!input.UpdatedBy.IsNullOrWhiteSpace(), x => x.UpdatedBy.ToLower().Contains(input.UpdatedBy.ToLower()));
            return query;
        }

        #endregion
    }
}
