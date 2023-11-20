using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Asset11s.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Asset11s
{
    public interface IAsset11AppService
    {
        void CreateOrEditAsset11(Asset11Input asset11Input);
        Asset11Input GetAsset11ForEdit(int id);
        void DeleteAsset11(int id);
        PagedResultDto<Asset11Dto> GetAsset11s(Asset11Filter input);
        Asset11ForViewDto GetAsset11ForView(int id);
        void Accounting(); // hoach toan
        void Depreciating(); // khau hao
    }
}
