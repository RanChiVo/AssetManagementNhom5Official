using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HoSoThau_N13.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HoSoThau_N13
{
    public interface IHoSoThauN13AppService
    {
        void CreateOrEditHoSoThau(HoSoThauN13Input taiSanInput);

        HoSoThauN13Input GetHoSoThauForEdit(int id);
        void DeleteHoSoThau(int id);
        PagedResultDto<HoSoThauN13Dto> GetHoSoThaus(HoSoThauN13Filter input);
        HoSoThauN13ForViewDto GetHoSoThauForView(int id);
    }
}
