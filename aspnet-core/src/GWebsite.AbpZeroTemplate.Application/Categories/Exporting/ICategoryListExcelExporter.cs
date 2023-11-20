using System.Collections.Generic;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Categories.Exporting
{
    public interface ICategoryListExcelExporter
    {
        FileDto ExportToFile(List<CategoryDto> categoryListDtos);
    }
}
