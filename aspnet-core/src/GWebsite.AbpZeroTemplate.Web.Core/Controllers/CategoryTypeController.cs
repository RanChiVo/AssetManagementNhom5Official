using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes;
using GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CategoryTypeController : GWebsiteControllerBase
    {
        private readonly ICategoryTypeAppService typeService;

        public CategoryTypeController(ICategoryTypeAppService typeService)
        {
            this.typeService = typeService;
        }

        [HttpGet]
        public FileDto GetCategoryTypesToExcel(CategoryTypeFilter filter)
        {
            return typeService.GetCategoryTypesToExcel(filter);
        }

        [HttpGet]
        public PagedResultDto<CategoryTypeDto> GetCategoryTypesByFilter(CategoryTypeFilter categoryFilter)
        {
            return typeService.GetCategoryTypes(categoryFilter);
        }

        [HttpGet]
        public CategoryTypeInput GetCategoryTypeForEdit(int id)
        {
            return typeService.GetCategoryTypeForEdit(id);
        }

        [HttpPost]
        public void CreateCategoryType([FromBody] CategoryTypeInput input)
        {
            typeService.CreateCategoryType(input);
        }

        [HttpPut]
        public void EditCategoryType([FromBody] CategoryTypeInput input)
        {
            typeService.EditCategoryType(input);
        }

        [HttpDelete("{id}")]
        public void DeleteCategoryType(int id)
        {
            typeService.DeleteCategoryType(id);
        }

        [HttpGet]
        public CategoryTypeForViewDto GetCategoryTypeForView(int id)
        {
            return typeService.GetCategoryTypeForView(id);
        }
    }
}
