using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// class dùng để đổ dữ liệu từ sql vào combobox
namespace GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps.Dto
{
    public class LoaiNhaCungCapOutput
    {
        public LoaiNhaCungCapDto LoaiNhaCungCap { get; set; }
        public List<ComboboxItemDto> LoaiNhaCungCaps { get; set; }
        public LoaiNhaCungCapOutput()
        {
            LoaiNhaCungCaps = new List<ComboboxItemDto>();
        }
    }
}