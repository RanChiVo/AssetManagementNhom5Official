using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.MainDto;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchAssetDto;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchAssetUnitDto;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchUserDto;

namespace GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets
{
    public interface ITransferringAssetAppService
    {
        void CreateOrEditTransferringAsset(TransferringAssetDataInput transferringAssetDataInput);

        TransferringAssetDataInput GetTransferringAssetForEdit(int id);
        TransferringAssetDataOutputForInput GetTransferringAssetDetailForInput(string assetId);
        TransferringAssetDataOutputDetail GetTransferringAssetDetail(int Id);
        PagedResultDto<TransferringAssetDataOutputForList> GetTransferringAssets(TransferringAssetFilter input);

        SearchAssetInitData GetAssetInitData();
        PagedResultDto<SearchAssetDataOutput> GetAssets(SearchAssetFilter input);

        SearchAssetUnitInitData GetAssetUnitInitData(long? assetRegion);
        PagedResultDto<SearchAssetUnitDataOutput> GetAssetUnits(SearchAssetUnitFilter input);
        SearchAssetUnitDataOutput GetAssetUnitDetail(long assetUnitID);

        PagedResultDto<SearchAssetUserDataOutput> GetAssetUsers(SearchAssetUserFilter input);
        SearchAssetUserDataOutput GetAssetUserDetail(long assetUserId);
    }
}
