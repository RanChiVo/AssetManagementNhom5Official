using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiSoHuu;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiSoHuu.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{

    [Route("api/[controller]/[action]")]
    public class LoaiSoHuuController : GWebsiteControllerBase
    {
        private readonly ILoaiSoHuuAppService loaiSoHuuAppService;

        public LoaiSoHuuController(ILoaiSoHuuAppService loaiSoHuuAppService)
        {
            this.loaiSoHuuAppService = loaiSoHuuAppService;
        }

        [HttpGet]
        public PagedResultDto<LoaiSoHuuDto> GetLoaiSoHuusByFilter(LoaiSoHuuFilter loaiSoHuuFilter)
        {
            return loaiSoHuuAppService.GetLoaiSoHuus(loaiSoHuuFilter);
        }

        [HttpGet]
        public LoaiSoHuuInput GetLoaiSoHuuForEdit(int id)
        {
            return loaiSoHuuAppService.GetLoaiSoHuuForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditLoaiSoHuu([FromBody] LoaiSoHuuInput input)
        {
            loaiSoHuuAppService.CreateOrEditLoaiSoHuu(input);
        }

        [HttpDelete("{id}")]
        public void DeleteLoaiSoHuu(int id)
        {
            loaiSoHuuAppService.DeleteLoaiSoHuu(id);
        }

        [HttpGet]
        public LoaiSoHuuForViewDto GetLoaiSoHuuForView(int id)
        {
            return loaiSoHuuAppService.GetLoaiSoHuuForView(id);
        }
    }
}
