using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GWebsite.AbpZeroTemplate.Core.Models;
namespace GWebsite.AbpZeroTemplate.Application.Share.NhaCungCapHangHoas.Dto
{
    public class NhaCungCapHangHoaOutput
    {
        public NhaCungCapHangHoaDto NhaCungCapHangHoa { get; set; }
        public List<NhaCungCapHangHoa> NhaCungCapHangHoas { get; set; }
        public NhaCungCapHangHoaOutput()
        {
            NhaCungCapHangHoas = new List<NhaCungCapHangHoa>();
        }
    }
}