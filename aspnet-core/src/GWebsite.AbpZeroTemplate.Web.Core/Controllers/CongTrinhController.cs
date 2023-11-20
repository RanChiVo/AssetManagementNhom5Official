using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.CongTrinh_N13.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{

    [Route("api/[controller]/[action]")]
    public class CongTrinhController : GWebsiteControllerBase
    {
        private readonly ICongTrinhAppService congTrinhAppService;

        public CongTrinhController(ICongTrinhAppService congTrinhAppService)
        {
            this.congTrinhAppService = congTrinhAppService;
        }

        [HttpGet]
        public PagedResultDto<CongTrinhDto> GetCongTrinhsByFilter(CongTrinhFilter congTrinhFilter)
        {
            return congTrinhAppService.GetCongTrinhs(congTrinhFilter);
        }
        [HttpGet]
        public PagedResultDto<CongTrinhDto> GetDsCongTrinhThuocDuAnByFilter(CongTrinhFilter congTrinhFilter)
        {
            return congTrinhAppService.GetDsCongTrinhTheoDuAn(congTrinhFilter);
        }
        [HttpGet]
        public PagedResultDto<CongTrinhDto> GetDsCongTrinhKhongThuocDuAnByFilter(CongTrinhFilter congTrinhFilter)
        {
            return congTrinhAppService.GetCongTrinhKhongThuocDuAn(congTrinhFilter);
        }


        [HttpGet]
        public CongTrinhInput GetCongTrinhForEdit(int id)
        {
            return congTrinhAppService.GetCongTrinhForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditCongTrinh([FromBody] CongTrinhInput input)
        {
            congTrinhAppService.CreateOrEditCongTrinh(input);
        }

        [HttpDelete("{id}")]
        public void DeleteCongTrinh(int id)
        {
            congTrinhAppService.DeleteCongTrinh(id);
        }

        [HttpGet]
        public CongTrinhForViewDto GetCongTrinhForView(int id)
        {
            return congTrinhAppService.GetCongTrinhForView(id);
        }
    }
}
