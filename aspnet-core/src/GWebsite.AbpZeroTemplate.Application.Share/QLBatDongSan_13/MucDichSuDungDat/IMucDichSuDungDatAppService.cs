using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.MucDichSuDungDat.DTO;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.MucDichSuDungDat
{
    public interface IMucDichSuDungDatAppService
    {
        void CreateOrEditMucDichSuDungDat(MucDichSuDungDatInput MucDichSuDungDatInput);
  
        MucDichSuDungDatInput GetMucDichSuDungDatForEdit(int id);
        void DeleteMucDichSuDungDat(int id);
        PagedResultDto<MucDichSuDungDatDto> GetMucDichSuDungDats(MucDichSuDungDatFilter input);
        MucDichSuDungDatForViewDto GetMucDichSuDungDatForView(int id);
    }
}
