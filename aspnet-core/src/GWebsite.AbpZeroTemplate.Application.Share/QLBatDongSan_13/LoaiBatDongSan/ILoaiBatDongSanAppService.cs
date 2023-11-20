using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiBatDongSan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiBatDongSan
{
    public interface ILoaiBatDongSanAppService
    {
        void CreateOrEditLoaiBatDongSan(LoaiBatDongSanInput LoaiBatDongSanInput);
        LoaiBatDongSanInput GetLoaiBatDongSanForEdit(int id);
        void DeleteLoaiBatDongSan(int id);
        PagedResultDto<LoaiBatDongSanDto> GetLoaiBatDongSans(LoaiBatDongSanFilter input);
        LoaiBatDongSanForViewDto GetLoaiBatDongSanForView(int id);
    }
}
