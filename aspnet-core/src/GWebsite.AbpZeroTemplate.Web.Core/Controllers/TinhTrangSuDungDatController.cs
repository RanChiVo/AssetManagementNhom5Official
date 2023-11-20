using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangSuDungDat;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.TinhTrangSuDungDat.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{

    [Route("api/[controller]/[action]")]
    public class TinhTrangSuDungDatController : GWebsiteControllerBase
    {
        private readonly ITinhTrangSuDungDatAppService tinhTrangSuDungDatAppService;

        public TinhTrangSuDungDatController(ITinhTrangSuDungDatAppService tinhTrangSuDungDatAppService)
        {
            this.tinhTrangSuDungDatAppService = tinhTrangSuDungDatAppService;
        }

        [HttpGet]
        public PagedResultDto<TinhTrangSuDungDatDto> GetTinhTrangSuDungDatsByFilter(TinhTrangSuDungDatFilter tinhTrangSuDungDatFilter)
        {
            return tinhTrangSuDungDatAppService.GetTinhTrangSuDungDats(tinhTrangSuDungDatFilter);
        }

        [HttpGet]
        public TinhTrangSuDungDatInput GetTinhTrangSuDungDatForEdit(int id)
        {
            return tinhTrangSuDungDatAppService.GetTinhTrangSuDungDatForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditTinhTrangSuDungDat([FromBody] TinhTrangSuDungDatInput input)
        {
            tinhTrangSuDungDatAppService.CreateOrEditTinhTrangSuDungDat(input);
        }

        [HttpDelete("{id}")]
        public void DeleteTinhTrangSuDungDat(int id)
        {
            tinhTrangSuDungDatAppService.DeleteTinhTrangSuDungDat(id);
        }

        [HttpGet]
        public TinhTrangSuDungDatForViewDto GetTinhTrangSuDungDatForView(int id)
        {
            return tinhTrangSuDungDatAppService.GetTinhTrangSuDungDatForView(id);
        }
    }

}
