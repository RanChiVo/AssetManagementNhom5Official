using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.AssetGroups_05.Dto
{
    /// <summary>
    /// <model cref="AssetGroup_05"></model>
    /// </summary>
    public class AssetGroupFilter_05 : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}
