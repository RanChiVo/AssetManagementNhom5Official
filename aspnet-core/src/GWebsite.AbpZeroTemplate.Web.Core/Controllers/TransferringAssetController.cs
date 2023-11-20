using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.MainDto;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchAssetDto;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchAssetUnitDto;
using GWebsite.AbpZeroTemplate.Application.Share.TransferringAssets.SearchUserDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]

    public class TransferringAssetController : GWebsiteControllerBase
    {
        private readonly ITransferringAssetAppService transferringAssetAppService;

        public TransferringAssetController(ITransferringAssetAppService transferringAssetAppService)
        {
            this.transferringAssetAppService = transferringAssetAppService;
        }

        [HttpGet]
        public PagedResultDto<TransferringAssetDataOutputForList> GetTransferringAssetsInAngular(TransferringAssetFilter input)
        {
            return transferringAssetAppService.GetTransferringAssets(input);
        }

        [HttpGet]
        public TransferringAssetDataInput GetTransferringAssetForEditInAngular(int id)
        {
            return transferringAssetAppService.GetTransferringAssetForEdit(id);
        }
        
        [HttpGet]
        public TransferringAssetDataOutputForInput GetTransferringAssetDetailForInputInAngular(string assetId)
        {
            return transferringAssetAppService.GetTransferringAssetDetailForInput(assetId);
        }

        [HttpGet]
        public TransferringAssetDataOutputDetail GetTransferringAssetDetailInAngular(int Id)
        {
            return transferringAssetAppService.GetTransferringAssetDetail(Id);
        }

        [HttpPost]
        public void CreateOrEditTransferringAssetInAngular([FromBody] TransferringAssetDataInput transferringAssetDataInput)
        {
            transferringAssetAppService.CreateOrEditTransferringAsset(transferringAssetDataInput);
        }

        [HttpGet]
        public SearchAssetInitData GetAssetInitDataInAngular()
        {
            return transferringAssetAppService.GetAssetInitData();
        }

        [HttpGet]
        public PagedResultDto<SearchAssetDataOutput> GetAssetsInAngular(SearchAssetFilter input)
        {
            return transferringAssetAppService.GetAssets(input);
        }

        [HttpGet]
        public SearchAssetUnitInitData GetAssetUnitInitDataInAngular(long? assetRegion)
        {
            return transferringAssetAppService.GetAssetUnitInitData(assetRegion);
        }

        [HttpGet]
        public PagedResultDto<SearchAssetUnitDataOutput> GetAssetUnitsInAngular(SearchAssetUnitFilter input)
        {
            return transferringAssetAppService.GetAssetUnits(input);
        }

        [HttpGet]
        public SearchAssetUnitDataOutput GetAssetUnitDetailInAngular(long assetUnitID)
        {
            return transferringAssetAppService.GetAssetUnitDetail(assetUnitID);
        }

        [HttpGet]
        public PagedResultDto<SearchAssetUserDataOutput> GetAssetUsersInAngular(SearchAssetUserFilter input)
        {
            return transferringAssetAppService.GetAssetUsers(input);
        }

        [HttpGet]
        public SearchAssetUserDataOutput GetAssetUserDetailInAngular(long assetUserId)
        {
            return transferringAssetAppService.GetAssetUserDetail(assetUserId);
        }
        

    }


}