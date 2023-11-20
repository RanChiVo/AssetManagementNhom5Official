using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.HienTrangPhapLy;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.HienTrangPhapLy.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{

    [Route("api/[controller]/[action]")]
    public class HienTrangPhapLyController : GWebsiteControllerBase
    {
        private readonly IHienTrangPhapLyAppService hienTrangPhapLyAppService;

        public HienTrangPhapLyController(IHienTrangPhapLyAppService hienTrangPhapLyAppService)
        {
            this.hienTrangPhapLyAppService = hienTrangPhapLyAppService;
        }

        [HttpGet]
        public PagedResultDto<HienTrangPhapLyDto> GetHienTrangPhapLysByFilter(HienTrangPhapLyFilter hienTrangPhapLyFilter)
        {
            return hienTrangPhapLyAppService.GetHienTrangPhapLys(hienTrangPhapLyFilter);
        }

        [HttpGet]
        public HienTrangPhapLyInput GetHienTrangPhapLyForEdit(int id)
        {
            return hienTrangPhapLyAppService.GetHienTrangPhapLyForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditHienTrangPhapLy([FromBody] HienTrangPhapLyInput input)
        {
            hienTrangPhapLyAppService.CreateOrEditHienTrangPhapLy(input);
        }

        [HttpDelete("{id}")]
        public void DeleteHienTrangPhapLy(int id)
        {
            hienTrangPhapLyAppService.DeleteHienTrangPhapLy(id);
        }

        [HttpGet]
        public HienTrangPhapLyForViewDto GetHienTrangPhapLyForView(int id)
        {
            return hienTrangPhapLyAppService.GetHienTrangPhapLyForView(id);
        }
    }

}
