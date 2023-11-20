using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AssetTypes_05.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetTypes_05
{
   public interface IAssetTypeAppService_05
    {
        AssetTypeViewDto_05 GetAssetTypeForView(int id);
        PagedResultDto<AssetTypeDto_05> GetAssetTypes();
    }
}
