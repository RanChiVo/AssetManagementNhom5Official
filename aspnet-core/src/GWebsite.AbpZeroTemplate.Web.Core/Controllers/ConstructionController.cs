using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Constructions;
using GWebsite.AbpZeroTemplate.Application.Share.Constructions.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ConstructionController : GWebsiteControllerBase
    {
        private readonly IConstructionAppService ConstructionAppService;

        public ConstructionController(IConstructionAppService ConstructionAppService)
        {
            this.ConstructionAppService = ConstructionAppService;
        }

        [HttpGet]
        public PagedResultDto<ConstructionDto> GetConstructionsByFilter(ConstructionFilter ConstructionFilter)
        {
            return ConstructionAppService.GetConstructions(ConstructionFilter);
        }

        [HttpGet]
        public ConstructionInput GetConstructionForEdit(int id)
        {
            return ConstructionAppService.GetConstructionForEdit(id);
        }

        [HttpGet]
        public ConstructionInput GetConstructionForEditWithMaCongTrinh(string id)
        {
            return ConstructionAppService.GetConstructionForEditWithMaCongTrinh(id);
        }

        [HttpPost]
        public void CreateOrEditConstruction([FromBody] ConstructionInput input)
        {
            ConstructionAppService.CreateOrEditConstruction(input);
        }

        [HttpDelete("{id}")]
        public void DeleteConstruction(int id)
        {
            ConstructionAppService.DeleteConstruction(id);
        }

        [HttpGet]
        public ConstructionForViewDto GetConstructionForView(int id)
        {
            return ConstructionAppService.GetConstructionForView(id);
        }
    }
}
