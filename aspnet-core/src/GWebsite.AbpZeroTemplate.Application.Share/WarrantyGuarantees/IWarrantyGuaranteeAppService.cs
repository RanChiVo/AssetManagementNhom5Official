using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.WarrantyGuarantees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.WarrantyGuarantees
{
    public interface IWarrantyGuaranteeAppService
    {
        void CreateOrEditWarrantyGuarantee(WarrantyGuaranteeInput WarrantyGuaranteeInput);
        WarrantyGuaranteeInput GetWarrantyGuaranteeForEdit(int id);
        void DeleteWarrantyGuarantee(int id);
        PagedResultDto<WarrantyGuaranteeDto> GetWarrantyGuarantees(WarrantyGuaranteeFilter input);
        WarrantyGuaranteeForViewDto GetWarrantyGuaranteeForView(int id);
    }
}
