using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes.Dto;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes
{
    public interface ICategoryTypeAppService
    {
        void CreateCategoryType(CategoryTypeInput input);
        void EditCategoryType(CategoryTypeInput input);
        CategoryTypeInput GetCategoryTypeForEdit(int id);
        void DeleteCategoryType(int id);
        PagedResultDto<CategoryTypeDto> GetCategoryTypes(CategoryTypeFilter input);
        CategoryTypeForViewDto GetCategoryTypeForView(int id);
        FileDto GetCategoryTypesToExcel(CategoryTypeFilter input);
    }
}
