using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Suppliers;
using GWebsite.AbpZeroTemplate.Application.Share.Suppliers.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SupplierController : GWebsiteControllerBase
    {
        private readonly ISupplierAppService supplierAppService;

        public SupplierController(ISupplierAppService supplierAppService)
        {
            this.supplierAppService = supplierAppService;
        }

        [HttpGet]
        public PagedResultDto<SupplierDto> GetSuppliersByFilter(SupplierFilter supplierFilter)
        {
            return supplierAppService.GetSuppliers(supplierFilter);
        }

        [HttpGet]
        public SupplierInput GetSupplierForEdit(int id)
        {
            return supplierAppService.GetSupplierForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditSupplier([FromBody] SupplierInput input)
        {
            supplierAppService.CreateOrEditSupplier(input);
        }

        [HttpDelete("{id}")]
        public void DeleteSupplier(int id)
        {
            supplierAppService.DeleteSupplier(id);
        }

        [HttpGet]
        public SupplierForViewDto GetSupplierForView(int id)
        {
            return supplierAppService.GetSupplierForView(id);
        }
    }
}
