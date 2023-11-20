using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.CongTrinh_N13.DTO
{

    public interface ICongTrinhAppService
    {
        void CreateOrEditCongTrinh(CongTrinhInput CongTrinhInput);

        CongTrinhInput GetCongTrinhForEdit(int id);
        void DeleteCongTrinh(int id);
        PagedResultDto<CongTrinhDto> GetCongTrinhs(CongTrinhFilter input);
        PagedResultDto<CongTrinhDto> GetDsCongTrinhTheoDuAn(CongTrinhFilter input);
        PagedResultDto<CongTrinhDto> GetCongTrinhKhongThuocDuAn(CongTrinhFilter input);
        CongTrinhForViewDto GetCongTrinhForView(int id);
    }
}
