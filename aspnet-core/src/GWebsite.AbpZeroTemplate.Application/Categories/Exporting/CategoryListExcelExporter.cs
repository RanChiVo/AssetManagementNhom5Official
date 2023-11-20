using System.Collections.Generic;
using Abp.Extensions;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto;
using GWebsite.AbpZeroTemplate.DataExporting.Excel.EpPlus;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Categories.Exporting
{
    public class CategoryListExcelExporter : EpPlusExcelExporterBase, ICategoryListExcelExporter
    {
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public CategoryListExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<CategoryDto> categoryListDtos)
        {
            return CreateExcelPackage(
                "Categories.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.Workbook.Worksheets.Add(L("Categories"));
                    sheet.OutLineApplyStyle = true;

                    AddHeader(
                        sheet,
                        L("CategoryId"),
                        L("Name"),
                        L("CategoryType"),
                        L("Symbol"),
                        L("Description"),
                        L("Status"),
                        L("CreatedDate"),
                        L("CreatedBy"),
                        L("UpdatedDate"),
                        L("UpdatedBy")
                    );

                    AddObjects(
                        sheet, 2, categoryListDtos,
                        _ => _.CategoryId,
                        _ => _.Name,
                        _ => _.CategoryType,
                        _ => _.Symbol,
                        _ => _.Description,
                        _ => _.Status ? "Inactive" : "Active",
                        _ => _.CreatedDate,
                        _ => _.CreatedBy,
                        _ => _.UpdatedDate,
                        _ => _.UpdatedBy
                        );

                    var createdDateColumn = sheet.Column(7);
                    createdDateColumn.Style.Numberformat.Format = "dd-mm-yyyy hh:mm:ss";

                    var updatedDateColumn = sheet.Column(9);
                    updatedDateColumn.Style.Numberformat.Format = "dd-mm-yyyy hh:mm:ss";

                    for (var i = 1; i <= 10; i++)
                    {
                        if (i == 5)
                            continue;

                        sheet.Column(i).AutoFit();
                    }
                });
        }
    }
}