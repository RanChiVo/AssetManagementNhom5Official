using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangSuDungDat.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangSuDungDat
{
    public interface ITinhTrangSuDungDatAppService
    {
        void CreateOrEditTinhTrangSuDungDat(TinhTrangSuDungDatInput TinhTrangSuDungDatInput);

        TinhTrangSuDungDatInput GetTinhTrangSuDungDatForEdit(int id);
        void DeleteTinhTrangSuDungDat(int id);
        PagedResultDto<TinhTrangSuDungDatDto> GetTinhTrangSuDungDats(TinhTrangSuDungDatFilter input);
        TinhTrangSuDungDatForViewDto GetTinhTrangSuDungDatForView(int id);
    }
}
