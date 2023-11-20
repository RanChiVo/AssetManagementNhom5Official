using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Debit11s;
using GWebsite.AbpZeroTemplate.Application.Share.Debit11s.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class Debit11Controller : GWebsiteControllerBase
    {
        private readonly IDebit11AppService debit11AppService;

        public Debit11Controller(IDebit11AppService debit11AppService)
        {
            this.debit11AppService = debit11AppService;
        }

        [HttpGet]
        public PagedResultDto<Debit11Dto> GetDebit11sByFilter(Debit11Filter debit11Filter)
        {
            return debit11AppService.GetDebit11s(debit11Filter);
        }

        [HttpGet]
        public Debit11Input GetDebit11ForEdit(int id)
        {
            return debit11AppService.GetDebit11ForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditDebit11([FromBody] Debit11Input input)
        {
            debit11AppService.CreateOrEditDebit11(input);
        }

        [HttpDelete("{id}")]
        public void DeleteDebit11(int id)
        {
            debit11AppService.DeleteDebit11(id);
        }

        [HttpGet]
        public Debit11ForViewDto GetDebit11ForView(int id)
        {
            return debit11AppService.GetDebit11ForView(id);
        }
    }
}
