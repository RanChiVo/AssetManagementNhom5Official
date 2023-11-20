using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.SuaChuaBatDongSan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.SuaChuaSuaChuaBatDongSan
{
    public interface ISuaChuaBatDongSanAppService
    {
        void CreateOrEditSuaChuaBatDongSan(SuaChuaBatDongSanInput SuaChuaBatDongSanInput);

        SuaChuaBatDongSanInput GetSuaChuaBatDongSanForEdit(int id);
        void DeleteSuaChuaBatDongSan(int id);
        PagedResultDto<SuaChuaBatDongSanDto> GetSuaChuaBatDongSans(SuaChuaBatDongSanFilter input);
        SuaChuaBatDongSanForViewDto GetSuaChuaBatDongSanForView(int id);
    }
}
