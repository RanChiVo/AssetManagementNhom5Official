using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps;
using GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LoaiNhaCungCapController : GWebsiteControllerBase
    {
        private readonly ILoaiNhaCungCapAppService LoaiNhaCungCapAppService;

        public LoaiNhaCungCapController(ILoaiNhaCungCapAppService LoaiNhaCungCapAppService)
        {
            this.LoaiNhaCungCapAppService = LoaiNhaCungCapAppService;
        }

        [HttpGet]
        public PagedResultDto<LoaiNhaCungCapDto> GetLoaiNhaCungCapsByFilter(LoaiNhaCungCapFilter loaiNhaCungCapFilter)
        {
            return LoaiNhaCungCapAppService.GetLoaiNhaCungCaps(loaiNhaCungCapFilter);
        }

        [HttpGet]
        public LoaiNhaCungCapInput GetLoaiNhaCungCapForEdit(int id)
        {
            return LoaiNhaCungCapAppService.GetLoaiNhaCungCapForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditLoaiNhaCungCap([FromBody] LoaiNhaCungCapInput input)
        {
            LoaiNhaCungCapAppService.CreateOrEditLoaiNhaCungCap(input);
        }

        [HttpDelete("{id}")]
        public void DeleteLoaiNhaCungCap(int id)
        {
            LoaiNhaCungCapAppService.DeleteLoaiNhaCungCap(id);
        }

        [HttpGet]
        public LoaiNhaCungCapForViewDto GetLoaiNhaCungCapForView(int id)
        {
            return LoaiNhaCungCapAppService.GetLoaiNhaCungCapForView(id);
        }
    }
}
