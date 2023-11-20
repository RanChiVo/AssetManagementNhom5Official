using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.SuaChuaBatDongSan.DTO;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.SuaChuaSuaChuaBatDongSan;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SuaChuaBatDongSanController : GWebsiteControllerBase
    {
        private readonly ISuaChuaBatDongSanAppService suachuabatdongsanAppService;

        public SuaChuaBatDongSanController(ISuaChuaBatDongSanAppService suachuabatdongsanAppService)
        {
            this.suachuabatdongsanAppService = suachuabatdongsanAppService;
        }

        [HttpGet]
        public PagedResultDto<SuaChuaBatDongSanDto> GetSuaChuaBatDongSansByFilter(SuaChuaBatDongSanFilter suachuabatdongsanFilter)
        {
            return suachuabatdongsanAppService.GetSuaChuaBatDongSans(suachuabatdongsanFilter);
        }

        [HttpGet]
        public int ThemAPI()
        {
            return 1;
        }


        [HttpGet]
        public SuaChuaBatDongSanInput GetSuaChuaBatDongSanForEdit(int id)
        {
            return suachuabatdongsanAppService.GetSuaChuaBatDongSanForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditSuaChuaBatDongSan([FromBody] SuaChuaBatDongSanInput input)
        {
            suachuabatdongsanAppService.CreateOrEditSuaChuaBatDongSan(input);
        }

        [HttpDelete("{id}")]
        public void DeleteSuaChuaBatDongSan(int id)
        {
            suachuabatdongsanAppService.DeleteSuaChuaBatDongSan(id);
        }

        [HttpGet]
        public SuaChuaBatDongSanForViewDto GetSuaChuaBatDongSanForView(int id)
        {
            return suachuabatdongsanAppService.GetSuaChuaBatDongSanForView(id);
        }
    }
}
