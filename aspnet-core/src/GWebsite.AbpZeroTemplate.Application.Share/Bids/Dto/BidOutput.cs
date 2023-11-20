using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.Bids.Dto
{
    public class BidOutput
    {
        public BidDto Bid { get; set; }
        public List<ComboboxItemDto> Bids { get; set; }

        public BidOutput()
        {
            Bids = new List<ComboboxItemDto>();
        }
    }
}
