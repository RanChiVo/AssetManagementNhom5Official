using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.GoodsList.Dto
{
    public class GoodsOutput
    {
        public GoodsDto Goods { get; set; }
        public List<ComboboxItemDto> GoodsList { get; set; }

        public GoodsOutput()
        {
            GoodsList = new List<ComboboxItemDto>();
        }
    }
}
