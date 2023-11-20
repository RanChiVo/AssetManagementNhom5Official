using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Credit11s;
using GWebsite.AbpZeroTemplate.Application.Share.Credit11s.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class Credit11Controller : GWebsiteControllerBase
    {
        private readonly ICredit11AppService credit11AppService;

        public Credit11Controller(ICredit11AppService credit11AppService)
        {
            this.credit11AppService = credit11AppService;
        }

        [HttpGet]
        public PagedResultDto<Credit11Dto> GetCredit11sByFilter(Credit11Filter credit11Filter)
        {
            return credit11AppService.GetCredit11s(credit11Filter);
        }

        [HttpGet]
        public Credit11Input GetCredit11ForEdit(int id)
        {
            return credit11AppService.GetCredit11ForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditCredit11([FromBody] Credit11Input input)
        {
            credit11AppService.CreateOrEditCredit11(input);
        }

        [HttpDelete("{id}")]
        public void DeleteCredit11(int id)
        {
            credit11AppService.DeleteCredit11(id);
        }

        [HttpGet]
        public Credit11ForViewDto GetCredit11ForView(int id)
        {
            return credit11AppService.GetCredit11ForView(id);
        }
    }
}
