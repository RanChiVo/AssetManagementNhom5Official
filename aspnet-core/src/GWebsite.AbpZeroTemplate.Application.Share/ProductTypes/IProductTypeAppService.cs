using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ProductTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ProductTypes
{
    public interface IProductTypeAppService
    {
        void CreateOrEditProductType(ProductTypeInput productTypeInput);
        ProductTypeInput GetProductTypeForEdit(int id);
        void DeleteProductType(int id);
        PagedResultDto<ProductTypeDto> GetProductTypes(ProductTypeFilter input);
        ProductTypeForViewDto GetProductTypeForView(int id);
    }
}
