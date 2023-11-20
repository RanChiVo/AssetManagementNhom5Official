using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes;
using GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GWebsite.AbpZeroTemplate.Application.CategoryTypes.Exporting;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.CategoryTypes
{
    [AbpAuthorize(GWebsitePermissions.Pages_CategoryTypes_General)]
    public class CategoryTypeAppService : GWebsiteAppServiceBase, ICategoryTypeAppService
    {
        private readonly IRepository<CategoryType> typeRepository;
        private readonly CategoryTypeListExcelExporter typeListExcelExporter;

        public CategoryTypeAppService(
            IRepository<CategoryType> typeRepository,
            CategoryTypeListExcelExporter typeListExcelExporter)
        {
            this.typeRepository = typeRepository;
            this.typeListExcelExporter = typeListExcelExporter;
        }

        #region Public Method

        public void CreateCategoryType(CategoryTypeInput input)
        {
            Create(input);
        }

        public void EditCategoryType(CategoryTypeInput input)
        {
            Update(input);
        }

        [AbpAuthorize(GWebsitePermissions.Pages_CategoryTypes_General_Delete)]
        public void DeleteCategoryType(int id)
        {
            var categoryEntity = typeRepository.GetAll().SingleOrDefault(x => x.Id == id);
            if (categoryEntity != null)
            {
                categoryEntity.IsDelete = true;
                typeRepository.Update(categoryEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public CategoryTypeInput GetCategoryTypeForEdit(int id)
        {
            var categoryEntity = typeRepository.GetAll().SingleOrDefault(x => x.Id == id);
            if (categoryEntity == null)
            {
                return null;
            }
            var result = ObjectMapper.Map<CategoryTypeInput>(categoryEntity);

            if (categoryEntity.IsDelete == true)
            {
                result.Status = "Inactive";
            }
            else
            {
                result.Status = "Active";
            }

            return result;
        }

        public CategoryTypeForViewDto GetCategoryTypeForView(int id)
        {
            var categoryEntity = typeRepository.GetAll().SingleOrDefault(x => x.Id == id);
            if (categoryEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<CategoryTypeForViewDto>(categoryEntity);
        }

        public PagedResultDto<CategoryTypeDto> GetCategoryTypes(CategoryTypeFilter input)
        {
            var query = CreateCategoryTypesQuery(input);

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();
            var resultItems = items.Select(item => ObjectMapper.Map<CategoryTypeDto>(item)).ToList();

            for (int i = 0; i < resultItems.Count(); i++)
            {
                resultItems.ElementAt(i).Status = !items.ElementAt(i).IsDelete;
            }

            return new PagedResultDto<CategoryTypeDto>(
                totalCount,
                resultItems);
        }

        public FileDto GetCategoryTypesToExcel(CategoryTypeFilter input)
        {
            var types = CreateCategoryTypesQuery(input)
                .AsNoTracking()
                .ToList();

            var listTypeDto = types.Select(item => ObjectMapper.Map<CategoryTypeDto>(item)).ToList();

            return typeListExcelExporter.ExportToFile(listTypeDto);
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_CategoryTypes_General_Create)]
        private void Create(CategoryTypeInput categoryInput)
        {
            var categoryEntity = ObjectMapper.Map<CategoryType>(categoryInput);
            categoryEntity.CreatedDate = DateTime.Now;
            categoryEntity.CreatedBy = GetCurrentUser().Name;
            
            if (categoryInput.Status == "Active")
            {
                categoryEntity.IsDelete = false;
            }
            else if (categoryInput.Status == "Inactive")
            {
                categoryEntity.IsDelete = true;
            }

            typeRepository.Insert(categoryEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_CategoryTypes_General_Edit)]
        private void Update(CategoryTypeInput categoryInput)
        {
            var categoryEntity = typeRepository.GetAll().SingleOrDefault(x => x.Id == categoryInput.Id);
            if (categoryEntity == null)
            {
            }
            ObjectMapper.Map(categoryInput, categoryEntity);
            categoryEntity.UpdatedDate = DateTime.Now;
            categoryEntity.UpdatedBy = GetCurrentUser().Name;

            if (categoryInput.Status == "Active")
            {
                categoryEntity.IsDelete = false;
            }
            else if (categoryInput.Status == "Inactive")
            {
                categoryEntity.IsDelete = true;
            }

            typeRepository.Update(categoryEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private IQueryable<CategoryType> CreateCategoryTypesQuery(CategoryTypeFilter input)
        {
            var query = typeRepository.GetAll();

            query = query
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.ToLower().Contains(input.Name))
                .WhereIf(!input.PrefixWord.IsNullOrWhiteSpace(), x => x.PrefixWord.ToLower().Contains(input.PrefixWord))
                .WhereIf(input.Status == "Active", x => x.IsDelete == false)
                .WhereIf(input.Status == "Inactive", x => x.IsDelete == true)
                .WhereIf(!input.Description.IsNullOrWhiteSpace(), x => x.Description.ToLower().Contains(input.Description))
                .WhereIf(input.IsCreatedCheckedAll == false, x => (x.CreatedDate >= input.StartCreatedDate && x.CreatedDate <= input.EndCreatedDate))
                .WhereIf(!input.CreatedBy.IsNullOrWhiteSpace(), x => x.CreatedBy.ToLower().Contains(input.CreatedBy.ToLower()))
                .WhereIf(input.IsUpdatedCheckedAll == false, x => (x.UpdatedDate >= input.StartUpdatedDate && x.UpdatedDate <= input.EndUpdatedDate))
                .WhereIf(!input.CreatedBy.IsNullOrWhiteSpace(), x => x.UpdatedBy.ToLower().Contains(input.UpdatedBy.ToLower()));
            return query;
        }

        #endregion
    }
}
