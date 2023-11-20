using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HoSoThau_N13;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.HoSoThau_N13.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HoSoThauN13Controller : GWebsiteControllerBase
    {
        private readonly IHoSoThauN13AppService HoSoThauAppService;

        public HoSoThauN13Controller(IHoSoThauN13AppService hoSoThauFilter)
        {
            this.HoSoThauAppService = hoSoThauFilter;
        }

        [HttpGet]
        public PagedResultDto<HoSoThauN13Dto> GetHoSoThausByFilter(HoSoThauN13Filter hoSoThauFilter)
        {
            return HoSoThauAppService.GetHoSoThaus(hoSoThauFilter);
        }

        [HttpGet]
        public HoSoThauN13Input GetHoSoThauForEdit(int id)
        {
            return HoSoThauAppService.GetHoSoThauForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditHoSoThau([FromBody] HoSoThauN13Input input)
        {
            HoSoThauAppService.CreateOrEditHoSoThau(input);
        }

        [HttpDelete("{id}")]
        public void DeleteHoSoThau(int id)
        {
            HoSoThauAppService.DeleteHoSoThau(id);
        }

        [HttpGet]
        public HoSoThauN13ForViewDto GetHoSoThauForView(int id)
        {
            return HoSoThauAppService.GetHoSoThauForView(id);
        }
    }

}
