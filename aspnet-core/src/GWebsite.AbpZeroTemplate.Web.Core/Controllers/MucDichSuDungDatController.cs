using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.MucDichSuDungDat;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.MucDichSuDungDat.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{

    [Route("api/[controller]/[action]")]
    public class MucDichSuDungDatController : GWebsiteControllerBase
    {
        private readonly IMucDichSuDungDatAppService mucDichSuDungDatAppService;

        public MucDichSuDungDatController(IMucDichSuDungDatAppService mucDichSuDungDatAppService)
        {
            this.mucDichSuDungDatAppService = mucDichSuDungDatAppService;
        }

        [HttpGet]
        public PagedResultDto<MucDichSuDungDatDto> GetMucDichSuDungDatsByFilter(MucDichSuDungDatFilter mucDichSuDungDatFilter)
        {
            return mucDichSuDungDatAppService.GetMucDichSuDungDats(mucDichSuDungDatFilter);
        }

        [HttpGet]
        public MucDichSuDungDatInput GetMucDichSuDungDatForEdit(int id)
        {
            return mucDichSuDungDatAppService.GetMucDichSuDungDatForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditMucDichSuDungDat([FromBody] MucDichSuDungDatInput input)
        {
            mucDichSuDungDatAppService.CreateOrEditMucDichSuDungDat(input);
        }

        [HttpDelete("{id}")]
        public void DeleteMucDichSuDungDat(int id)
        {
            mucDichSuDungDatAppService.DeleteMucDichSuDungDat(id);
        }

        [HttpGet]
        public MucDichSuDungDatForViewDto GetMucDichSuDungDatForView(int id)
        {
            return mucDichSuDungDatAppService.GetMucDichSuDungDatForView(id);
        }
    }

}
