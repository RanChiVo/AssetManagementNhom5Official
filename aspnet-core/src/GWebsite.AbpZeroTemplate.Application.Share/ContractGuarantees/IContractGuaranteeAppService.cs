using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractGuarantees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GWebsite.AbpZeroTemplate.Application.Share.ContractGuarantees
{
    public interface IContractGuaranteeAppService
    {
        void CreateOrEditContractGuarantee(ContractGuaranteeInput ContractGuaranteegInput);
        ContractGuaranteeInput GetContractGuaranteeForEdit(int id);
        void DeleteContractGuarantee(int id);
        PagedResultDto<ContractGuaranteeDto> GetContractGuarantees(ContractGuaranteeFilter input);
        ContractGuaranteeForViewDto GetContractGuaranteeForView(int id);
    }
}
