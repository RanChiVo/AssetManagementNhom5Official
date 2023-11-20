using System.Collections.Generic;
using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.CategoryTypes.Dto;

namespace GWebsite.AbpZeroTemplate.Application.CategoryTypes.Exporting
{
    public interface ICategoryTypeListExcelExporter
    {
        FileDto ExportToFile(List<CategoryTypeDto> categoryTypeListDtos);
    }
}
