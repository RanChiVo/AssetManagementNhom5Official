using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlanDetails;
using GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlanDetails.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ConstructionPlanDetailController : GWebsiteControllerBase
    {
        private readonly IConstructionPlanDetailAppService constructionPlanAppService;

        public ConstructionPlanDetailController(IConstructionPlanDetailAppService constructionPlanAppService)
        {
            this.constructionPlanAppService = constructionPlanAppService;
        }

        [HttpGet]
        public PagedResultDto<ConstructionPlanDetailDto> GetConstructionPlansByFilter(ConstructionPlanDetailFilter constructionPlanFilter)
        { 
            return constructionPlanAppService.GetConstructionPlanDetails(constructionPlanFilter);
        }

        [HttpGet]
        public ConstructionPlanDetailInput GetConstructionPlanDetailForEdit(int id)
        {
            return constructionPlanAppService.GetConstructionPlanDetailForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditConstructionPlanDetail([FromBody] ConstructionPlanDetailInput input)
        {
        constructionPlanAppService.CreateOrEditConstructionPlanDetail(input);
        }

        [HttpDelete("{id}")]
        public void DeleteConstructionPlanDetail(int id)
        {
        constructionPlanAppService.DeleteConstructionPlanDetail(id);
        }
    }
}
