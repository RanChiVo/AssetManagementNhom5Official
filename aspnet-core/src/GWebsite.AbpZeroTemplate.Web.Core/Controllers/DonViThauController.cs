using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DonViThauController : GWebsiteControllerBase
    {
        private readonly IDonViThauAppService donViThauAppService;

        public DonViThauController(IDonViThauAppService donViThauAppService)
        {
            this.donViThauAppService = donViThauAppService;
        }

        [HttpGet]
        public PagedResultDto<DonViThauDto> GetDonViThausByFilter(DonViThauFilter donViThauFilter)
        {
            return donViThauAppService.GetDonViThaus(donViThauFilter);
        }

        [HttpGet]
        public DonViThauInput GetDonViThauForEdit(int id)
        {
            return donViThauAppService.GetDonViThauForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditDonViThau([FromBody] DonViThauInput input)
        {
            donViThauAppService.CreateOrEditDonViThau(input);
        }

        [HttpDelete("{id}")]
        public void DeleteDonViThau(int id)
        {
            donViThauAppService.DeleteDonViThau(id);
        }

        [HttpGet]
        public DonViThauForViewDto GetDonViThauForView(int id)
        {
            return donViThauAppService.GetDonViThauForView(id);
        }
    }

}
