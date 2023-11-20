using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiBatDongSan;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiBatDongSan.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{

        [Route("api/[controller]/[action]")]
        public class LoaiBatDongSanController : GWebsiteControllerBase
        {
            private readonly ILoaiBatDongSanAppService loaiBatDongSanAppService;

            public LoaiBatDongSanController(ILoaiBatDongSanAppService loaiBatDongSanAppService)
            {
                this.loaiBatDongSanAppService = loaiBatDongSanAppService;
            }

            [HttpGet]
            public PagedResultDto<LoaiBatDongSanDto> GetLoaiBatDongSansByFilter(LoaiBatDongSanFilter loaiBatDongSanFilter)
            {
                return loaiBatDongSanAppService.GetLoaiBatDongSans(loaiBatDongSanFilter);
            }

            [HttpGet]
            public LoaiBatDongSanInput GetLoaiBatDongSanForEdit(int id)
            {
                return loaiBatDongSanAppService.GetLoaiBatDongSanForEdit(id);
            }

            [HttpPost]
            public void CreateOrEditLoaiBatDongSan([FromBody] LoaiBatDongSanInput input)
            {
                loaiBatDongSanAppService.CreateOrEditLoaiBatDongSan(input);
            }

            [HttpDelete("{id}")]
            public void DeleteLoaiBatDongSan(int id)
            {
                loaiBatDongSanAppService.DeleteLoaiBatDongSan(id);
            }

            [HttpGet]
            public LoaiBatDongSanForViewDto GetLoaiBatDongSanForView(int id)
            {
                return loaiBatDongSanAppService.GetLoaiBatDongSanForView(id);
            }
        }
    
}
