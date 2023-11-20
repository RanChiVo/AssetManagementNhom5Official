using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.KhuVuc.DTO;
namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.KhuVuc
{
    public interface IKhuVucAppService
    {
        void CreateOrEditKhuVuc(KhuVucInput KhuVucInput);
  
        KhuVucInput GetKhuVucForEdit(int id);
        void DeleteKhuVuc(int id);
        PagedResultDto<KhuVucDto> GetKhuVucs(KhuVucFilter input);
        KhuVucForViewDto GetKhuVucForView(int id);
    }
}
