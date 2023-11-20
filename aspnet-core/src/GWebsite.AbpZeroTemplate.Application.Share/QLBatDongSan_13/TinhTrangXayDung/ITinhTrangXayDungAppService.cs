using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangXayDung.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangXayDung
{
    public interface ITinhTrangXayDungAppService
    {
        void CreateOrEditTinhTrangXayDung(TinhTrangXayDungInput TinhTrangXayDungInput);
  
        TinhTrangXayDungInput GetTinhTrangXayDungForEdit(int id);
        void DeleteTinhTrangXayDung(int id);
        PagedResultDto<TinhTrangXayDungDto> GetTinhTrangXayDungs(TinhTrangXayDungFilter input);
        TinhTrangXayDungForViewDto GetTinhTrangXayDungForView(int id);
    }
}
