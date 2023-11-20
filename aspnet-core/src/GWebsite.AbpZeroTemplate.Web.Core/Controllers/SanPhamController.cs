using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.SanPhams;
using GWebsite.AbpZeroTemplate.Application.Share.SanPhams.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SanPhamController : GWebsiteControllerBase
    {
        private readonly ISanPhamAppService productAppService;

        public SanPhamController(ISanPhamAppService productAppService)
        {
            this.productAppService = productAppService;
        }

        [HttpGet]
        public PagedResultDto<SanPhamDto> GetProductsByFilter(SanPhamFilter productFilter)
        {
            return productAppService.GetProducts(productFilter);
        }
        [HttpGet]
        public PagedResultDto<SanPhamDto> GetProductsByFilterType(SanPhamFilterType productFilterType)
        {
            return productAppService.GetProductTypes(productFilterType);
        }
        [HttpGet]
        public PagedResultDto<SanPhamDto> GetProductsByFilterName(SanPhamFilterName productFilterName)
        {
            return productAppService.GetProductNames(productFilterName);
        }
        [HttpGet]
        public SanPhamInput GetProductForEdit(int id)
        {
            return productAppService.GetProductForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditProduct([FromBody] SanPhamInput input)
        {
            productAppService.CreateOrEditProduct(input);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            productAppService.DeleteProduct(id);
        }

        [HttpGet]
        public SanPhamForViewDto GetProductForView(int id)
        {
            return productAppService.GetProductForView(id);
        }
    }
}