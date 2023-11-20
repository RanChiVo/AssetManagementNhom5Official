using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.Contracts.Dto
{
    public class ContractOutput
    {
        public ContractDto Contract { get; set; }
        public List<ComboboxItemDto> Contracts { get; set; }

        public ContractOutput()
        {
            Contracts = new List<ComboboxItemDto>();
        }
    }
}
