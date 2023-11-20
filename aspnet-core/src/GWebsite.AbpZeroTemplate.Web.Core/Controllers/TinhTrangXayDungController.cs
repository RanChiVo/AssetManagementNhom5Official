using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangXayDung;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangXayDung.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{

    [Route("api/[controller]/[action]")]
    public class TinhTrangXayDungController : GWebsiteControllerBase
    {
        private readonly ITinhTrangXayDungAppService kinhTrangXayDungAppService;

        public TinhTrangXayDungController(ITinhTrangXayDungAppService kinhTrangXayDungAppService)
        {
            this.kinhTrangXayDungAppService = kinhTrangXayDungAppService;
        }

        [HttpGet]
        public PagedResultDto<TinhTrangXayDungDto> GetTinhTrangXayDungsByFilter(TinhTrangXayDungFilter kinhTrangXayDungFilter)
        {
            return kinhTrangXayDungAppService.GetTinhTrangXayDungs(kinhTrangXayDungFilter);
        }

        [HttpGet]
        public TinhTrangXayDungInput GetTinhTrangXayDungForEdit(int id)
        {
            return kinhTrangXayDungAppService.GetTinhTrangXayDungForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditTinhTrangXayDung([FromBody] TinhTrangXayDungInput input)
        {
            kinhTrangXayDungAppService.CreateOrEditTinhTrangXayDung(input);
        }

        [HttpDelete("{id}")]
        public void DeleteTinhTrangXayDung(int id)
        {
            kinhTrangXayDungAppService.DeleteTinhTrangXayDung(id);
        }

        [HttpGet]
        public TinhTrangXayDungForViewDto GetTinhTrangXayDungForView(int id)
        {
            return kinhTrangXayDungAppService.GetTinhTrangXayDungForView(id);
        }
    }

}
