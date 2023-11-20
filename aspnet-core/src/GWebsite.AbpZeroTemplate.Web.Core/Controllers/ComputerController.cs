using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Computers;
using GWebsite.AbpZeroTemplate.Application.Share.Computers.Dto;
using GWebsite.AbpZeroTemplate.Web.Core.Computer;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ComputerController : GWebsiteControllerBase
    {
        private readonly IComputerAppService computerAppService;

        public ComputerController(IComputerAppService customerAppService)
        {
            this.computerAppService = customerAppService;
        }

        [HttpGet]
        public PagedResultDto<ComputerDto> GetComputersByFilter(ComputerFilter customerFilter)
        {
            return computerAppService.GetComputer(customerFilter);
        }

        [HttpGet]
        public ComputerInput GetComputerForEdit(int id)
        {
            return computerAppService.GetComputerForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditComputer ([FromBody] ComputerInput input)
        {
            computerAppService.CreateOrEditComputer(input);
        }

        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            computerAppService.DeleteComputer(id);
        }

        [HttpGet]
        public ComputerForViewDto GetComputerForView(int id)
        {
            return computerAppService.GetComputerForView(id);
        }


    }
}
