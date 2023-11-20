using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.KeHoachXayDung_N13.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.KeHoachXayDung_N13
{
    public interface IKeHoachXayDungAppService
    {
        void CreateOrEditKeHoachXayDung(KeHoachXayDungInput KeHoachXayDungInput);

        KeHoachXayDungInput GetKeHoachXayDungForEdit(int id);
        void DeleteKeHoachXayDung(int id);
        PagedResultDto<KeHoachXayDungDto> GetKeHoachXayDungs(KeHoachXayDungFilter input);
        KeHoachXayDungForViewDto GetKeHoachXayDungForView(int id);
    }
}
