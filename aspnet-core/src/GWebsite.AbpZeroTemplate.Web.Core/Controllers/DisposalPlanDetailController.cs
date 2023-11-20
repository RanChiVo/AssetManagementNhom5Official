using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalPlanDetails;
using GWebsite.AbpZeroTemplate.Application.Share.DisposalPlanDetails.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DisposalPlanDetailController: GWebsiteAppServiceBase
    {
        private readonly IDisposalPlanDetailAppService disposalPlanDetailAppService;

        public DisposalPlanDetailController(IDisposalPlanDetailAppService disposalPlanDetailAppService)
        {
            this.disposalPlanDetailAppService = disposalPlanDetailAppService;
        }

        [HttpGet]
        public PagedResultDto<DisposalPlanDetailDto> GetDisposalPlanDetailsByFilter(DisposalPlanDetailFilter disposalPlanDetailFilter)
        {
            return disposalPlanDetailAppService.GetDisposalPlanDetails(disposalPlanDetailFilter);
        }

        [HttpGet]
        public DisposalPlanDetailInput GetDisposalPlanDetailForEdit(int id)
        {
            return disposalPlanDetailAppService.GetDisposalPlanDetailForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditDisposalPlanDetail([FromBody] DisposalPlanDetailInput input)
        {
            disposalPlanDetailAppService.CreateOrEditDisposalPlanDetail(input);
        }

        [HttpDelete("{id}")]
        public void DeleteDisposalPlanDetail(int id)
        {
            disposalPlanDetailAppService.DeleteDisposalPlanDetail(id);
        }
    }
}
