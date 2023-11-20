using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.HienTrangPhapLy.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.HienTrangPhapLy
{
    public interface IHienTrangPhapLyAppService
    {
        void CreateOrEditHienTrangPhapLy(HienTrangPhapLyInput HienTrangPhapLyInput);
  
        HienTrangPhapLyInput GetHienTrangPhapLyForEdit(int id);
        void DeleteHienTrangPhapLy(int id);
        PagedResultDto<HienTrangPhapLyDto> GetHienTrangPhapLys(HienTrangPhapLyFilter input);
        HienTrangPhapLyForViewDto GetHienTrangPhapLyForView(int id);
    }
}
