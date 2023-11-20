using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.PaymentDetails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GWebsite.AbpZeroTemplate.Application.Share.PaymentDetails
{
    public interface IPaymentDetailAppService
    {
        void CreateOrEditPaymentDetail(PaymentDetailInput PaymentDetailInput);
        PaymentDetailInput GetPaymentDetailForEdit(int id);
        void DeletePaymentDetail(int id);
        PagedResultDto<PaymentDetailDto> GetPaymentDetails(PaymentDetailFilter input);
        PaymentDetailForViewDto GetPaymentDetailForView(int id);
    }
}
