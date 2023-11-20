using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.PaymentDetails;
using GWebsite.AbpZeroTemplate.Application.Share.PaymentDetails.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.PaymentDetails
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_PaymentDetail9)]
    public class PaymentDetailAppService : GWebsiteAppServiceBase, IPaymentDetailAppService
    {
        private readonly IRepository<PaymentDetails_9> PaymentDetailRepository;

        public PaymentDetailAppService(IRepository<PaymentDetails_9> PaymentDetailRepository)
        {
            this.PaymentDetailRepository = PaymentDetailRepository;
        }

        #region Public Method

        public void CreateOrEditPaymentDetail(PaymentDetailInput PaymentDetailInput)
        {
            if (PaymentDetailInput.Id == 0)
            {
                Create(PaymentDetailInput);
            }
            else
            {
                Update(PaymentDetailInput);
            }
        }

        public void DeletePaymentDetail(int id)
        {
            var PaymentDetailEntity = PaymentDetailRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (PaymentDetailEntity != null)
            {
                PaymentDetailEntity.IsDelete = true;
                PaymentDetailRepository.Update(PaymentDetailEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public PaymentDetailInput GetPaymentDetailForEdit(int id)
        {
            var PaymentDetailEntity = PaymentDetailRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (PaymentDetailEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<PaymentDetailInput>(PaymentDetailEntity);
        }


        public PaymentDetailForViewDto GetPaymentDetailForView(int id)
        {
            var PaymentDetailEntity = PaymentDetailRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (PaymentDetailEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<PaymentDetailForViewDto>(PaymentDetailEntity);
        }

        public PagedResultDto<PaymentDetailDto> GetPaymentDetails(PaymentDetailFilter input)
        {
            var query = PaymentDetailRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.DaThanhToan != null)
            {
                query = query.Where(x => x.DaThanhToan.ToLower().Equals(input.DaThanhToan));
            }


            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<PaymentDetailDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<PaymentDetailDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_PaymentDetail9_Create)]
        private void Create(PaymentDetailInput PaymentDetailInput)
        {
            var PaymentDetailEntity = ObjectMapper.Map<PaymentDetails_9>(PaymentDetailInput);
            SetAuditInsert(PaymentDetailEntity);
            PaymentDetailRepository.Insert(PaymentDetailEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_PaymentDetail9_Edit)]
        private void Update(PaymentDetailInput PaymentDetailInput)
        {
            var PaymentDetailEntity = PaymentDetailRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == PaymentDetailInput.Id);
            if (PaymentDetailEntity == null)
            {
            }
            ObjectMapper.Map(PaymentDetailInput, PaymentDetailEntity);
            SetAuditEdit(PaymentDetailEntity);
            PaymentDetailRepository.Update(PaymentDetailEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
