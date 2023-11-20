using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PaymentDetails;
using GWebsite.AbpZeroTemplate.Application.Share.PaymentDetails.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PaymentDetailController : GWebsiteControllerBase
    {
        private readonly IPaymentDetailAppService PaymentDetailAppService;

        public PaymentDetailController(IPaymentDetailAppService PaymentDetailAppService)
        {
            this.PaymentDetailAppService = PaymentDetailAppService;
        }

        [HttpGet]
        public PagedResultDto<PaymentDetailDto> GetPaymentDetailsByFilter(PaymentDetailFilter PaymentDetailFilter)
        {
            return PaymentDetailAppService.GetPaymentDetails(PaymentDetailFilter);
        }

        [HttpGet]
        public PaymentDetailInput GetPaymentDetailForEdit(int id)
        {
            return PaymentDetailAppService.GetPaymentDetailForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditPaymentDetail([FromBody] PaymentDetailInput input)
        {
            PaymentDetailAppService.CreateOrEditPaymentDetail(input);
        }

        [HttpDelete("{id}")]
        public void DeletePaymentDetail(int id)
        {
            PaymentDetailAppService.DeletePaymentDetail(id);
        }

        [HttpGet]
        public PaymentDetailForViewDto GetPaymentDetailForView(int id)
        {
            return PaymentDetailAppService.GetPaymentDetailForView(id);
        }
    }
}
