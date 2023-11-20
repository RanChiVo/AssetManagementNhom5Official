using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.GoodsList.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.GoodsList
{
    public interface IGoodsAppService
    {
        void CreateOrEditGoods(GoodsInput goodsInput);
        GoodsInput GetGoodsForEdit(int id);
        void DeleteGoods(int id);
        PagedResultDto<GoodsDto> GetGoods(GoodsFilter input);
        GoodsForViewDto GetGoodsForView(int id);
    }
}
