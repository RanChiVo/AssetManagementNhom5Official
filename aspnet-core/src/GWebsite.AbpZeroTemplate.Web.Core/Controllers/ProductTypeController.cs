using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductTypes;
using GWebsite.AbpZeroTemplate.Application.Share.ProductTypes.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductTypeController : GWebsiteControllerBase
    {
        private readonly IProductTypeAppService productTypeAppService;

        public ProductTypeController(IProductTypeAppService productTypeAppService)
        {
            this.productTypeAppService = productTypeAppService;
        }

        [HttpGet]
        public PagedResultDto<ProductTypeDto> GetProductTypesByFilter(ProductTypeFilter productTypeFilter)
        {
            return productTypeAppService.GetProductTypes(productTypeFilter);
        }

        [HttpGet]
        public ProductTypeInput GetProductTypeForEdit(int id)
        {
            return productTypeAppService.GetProductTypeForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditProductType([FromBody] ProductTypeInput input)
        {
            productTypeAppService.CreateOrEditProductType(input);
        }

        [HttpDelete("{id}")]
        public void DeleteProductType(int id)
        {
            productTypeAppService.DeleteProductType(id);
        }

        [HttpGet]
        public ProductTypeForViewDto GetProductTypeForView(int id)
        {
            return productTypeAppService.GetProductTypeForView(id);
        }
    }
}