using Abp.Application.Services.Dto;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Categories;
using GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CategoryController : GWebsiteControllerBase
    {
        private readonly ICategoryAppService categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            this.categoryAppService = categoryAppService;
        }

        [HttpGet]
        public FileDto GetCategoriesToExcel(CategoryFilter categoryFilter)
        {
            return categoryAppService.GetCategoriesToExcel(categoryFilter);
        }

        [HttpGet]
        public PagedResultDto<CategoryDto> GetCategoriesByFilter(CategoryFilter categoryFilter)
        {
            return categoryAppService.GetCategoriesByFilter(categoryFilter);
        }

        [HttpGet]
        public CategoryInput GetCategoryForEdit(int id)
        {
            return categoryAppService.GetCategoryForEdit(id);
        }

        [HttpPost]
        public void CreateCategory([FromBody] CategoryInput input)
        {
            categoryAppService.CreateCategory(input);
        }

        [HttpPut]
        public void EditCategory([FromBody] CategoryInput input)
        {
            categoryAppService.EditCategory(input);
        }

        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            categoryAppService.DeleteCategory(id);
        }

        [HttpGet]
        public CategoryForViewDto GetCategoryForView(int id)
        {
            return categoryAppService.GetCategoryForView(id);
        }
    }
}
