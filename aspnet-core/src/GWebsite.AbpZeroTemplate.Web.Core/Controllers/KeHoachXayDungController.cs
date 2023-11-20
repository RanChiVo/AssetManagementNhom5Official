using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.KeHoachXayDung_N13;
using GWebsite.AbpZeroTemplate.Application.Share.KeHoachXayDung_N13.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class KeHoachXayDungController : GWebsiteControllerBase
    {
        private readonly IKeHoachXayDungAppService keHoachXayDungAppService;

        public KeHoachXayDungController(IKeHoachXayDungAppService keHoachXayDungAppService)
        {
            this.keHoachXayDungAppService = keHoachXayDungAppService;
        }

        [HttpGet]
        public PagedResultDto<KeHoachXayDungDto> GetKeHoachXayDungsByFilter(KeHoachXayDungFilter keHoachXayDungFilter)
        {
            return keHoachXayDungAppService.GetKeHoachXayDungs(keHoachXayDungFilter);
        }

        [HttpGet]
        public KeHoachXayDungInput GetKeHoachXayDungForEdit(int id)
        {
            return keHoachXayDungAppService.GetKeHoachXayDungForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditKeHoachXayDung([FromBody] KeHoachXayDungInput input)
        {
            keHoachXayDungAppService.CreateOrEditKeHoachXayDung(input);
        }

        [HttpDelete("{id}")]
        public void DeleteKeHoachXayDung(int id)
        {
            keHoachXayDungAppService.DeleteKeHoachXayDung(id);
        }

        [HttpGet]
        public KeHoachXayDungForViewDto GetKeHoachXayDungForView(int id)
        {
            return keHoachXayDungAppService.GetKeHoachXayDungForView(id);
        }
    }
}
