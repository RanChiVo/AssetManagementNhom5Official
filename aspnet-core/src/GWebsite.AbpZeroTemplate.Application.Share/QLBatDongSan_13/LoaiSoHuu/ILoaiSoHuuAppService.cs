using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiSoHuu.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiSoHuu
{
    public interface ILoaiSoHuuAppService
    {
        void CreateOrEditLoaiSoHuu(LoaiSoHuuInput LoaiSoHuuInput);
        LoaiSoHuuInput GetLoaiSoHuuForEdit(int id);
        void DeleteLoaiSoHuu(int id);
        PagedResultDto<LoaiSoHuuDto> GetLoaiSoHuus(LoaiSoHuuFilter input);
        LoaiSoHuuForViewDto GetLoaiSoHuuForView(int id);

    }
}
