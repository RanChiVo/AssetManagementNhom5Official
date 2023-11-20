using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.Suppliers.Dto
{
    public class SupplierOutput
    {
        public SupplierDto Supplier { get; set; }
        public List<ComboboxItemDto> Suppliers { get; set; }

        public SupplierOutput()
        {
            Suppliers = new List<ComboboxItemDto>();
        }
    }
}
