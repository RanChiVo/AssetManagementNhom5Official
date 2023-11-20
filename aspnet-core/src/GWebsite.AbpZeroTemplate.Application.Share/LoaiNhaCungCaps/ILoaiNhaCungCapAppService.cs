using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps
{
    public interface ILoaiNhaCungCapAppService
    {
        void CreateOrEditLoaiNhaCungCap(LoaiNhaCungCapInput LoaiNhaCungCapInput);
        LoaiNhaCungCapInput GetLoaiNhaCungCapForEdit(int id);
        void DeleteLoaiNhaCungCap(int id);
        PagedResultDto<LoaiNhaCungCapDto> GetLoaiNhaCungCaps(LoaiNhaCungCapFilter input);
        LoaiNhaCungCapForViewDto GetLoaiNhaCungCapForView(int id);
    }
}
