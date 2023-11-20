using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.GoodsList;
using GWebsite.AbpZeroTemplate.Application.Share.GoodsList.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class GoodsController : GWebsiteControllerBase
    {
        private readonly IGoodsAppService goodsAppService;

        public GoodsController(IGoodsAppService goodsAppService)
        {
            this.goodsAppService = goodsAppService;
        }

        [HttpGet]
        public PagedResultDto<GoodsDto> GetGoodsByFilter(GoodsFilter goodsFilter)
        {
            return goodsAppService.GetGoods(goodsFilter);
        }

        [HttpGet]
        public GoodsInput GetGoodsForEdit(int id)
        {
            return goodsAppService.GetGoodsForEdit(id);
        } 

        [HttpPost]
        public void CreateOrEditGoods([FromBody] GoodsInput input)
        {
            goodsAppService.CreateOrEditGoods(input);
        }

        [HttpDelete("{id}")]
        public void DeleteGoods(int id)
        {
            goodsAppService.DeleteGoods(id);
        }

        [HttpGet]
        public GoodsForViewDto GetGoodsForView(int id)
        {
            return goodsAppService.GetGoodsForView(id);
        }
    }
}
