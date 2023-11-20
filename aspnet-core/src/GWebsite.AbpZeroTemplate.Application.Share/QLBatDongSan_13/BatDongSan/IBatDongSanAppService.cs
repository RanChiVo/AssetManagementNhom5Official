using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.BatDongSan.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.KhuVuc.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.BatDongSan
{
    public interface IBatDongSanAppService
    {
        void CreateOrEditBatDongSan(BatDongSanInput BatDongSanInput,int idTaiSan=0);

        BatDongSanInput GetBatDongSanForEdit(int id);
        void DeleteBatDongSan(int id);
        PagedResultDto<BatDongSanDto> GetBatDongSans(BatDongSanFilter input);
        BatDongSanForViewDto GetBatDongSanForView(int id);
    }
}
