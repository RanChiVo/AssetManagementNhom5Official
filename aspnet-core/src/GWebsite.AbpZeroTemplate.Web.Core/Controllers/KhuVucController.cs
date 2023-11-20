using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.KhuVuc;
using GWebsite.AbpZeroTemplate.Application.Share.RealEstas.KhuVuc.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{

    [Route("api/[controller]/[action]")]
    public class KhuVucController : GWebsiteControllerBase
    {
        private readonly IKhuVucAppService khuVucAppService;

        public KhuVucController(IKhuVucAppService khuVucAppService)
        {
            this.khuVucAppService = khuVucAppService;
        }

        [HttpGet]
        public PagedResultDto<KhuVucDto> GetKhuVucsByFilter(KhuVucFilter khuVucFilter)
        {
            return khuVucAppService.GetKhuVucs(khuVucFilter);
        }

        [HttpGet]
        public KhuVucInput GetKhuVucForEdit(int id)
        {
            return khuVucAppService.GetKhuVucForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditKhuVuc([FromBody] KhuVucInput input)
        {
            khuVucAppService.CreateOrEditKhuVuc(input);
        }

        [HttpDelete("{id}")]
        public void DeleteKhuVuc(int id)
        {
            khuVucAppService.DeleteKhuVuc(id);
        }

        [HttpGet]
        public KhuVucForViewDto GetKhuVucForView(int id)
        {
            return khuVucAppService.GetKhuVucForView(id);
        }
    }

}
