using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.SanPhams.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.SanPhams
{
    public interface ISanPhamAppService
    {
        void CreateOrEditProduct(SanPhamInput productInput);
        SanPhamInput GetProductForEdit(int id);
        void DeleteProduct(int id);
        PagedResultDto<SanPhamDto> GetProducts(SanPhamFilter input);
        PagedResultDto<SanPhamDto> GetProductTypes(SanPhamFilterType input);
        PagedResultDto<SanPhamDto> GetProductNames(SanPhamFilterName input);
        SanPhamForViewDto GetProductForView(int id);
    }
}
