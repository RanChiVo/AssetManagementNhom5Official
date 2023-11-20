using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.ContractManagements.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GWebsite.AbpZeroTemplate.Application.Share.ContractManagements
{
    public interface IContractManagementAppService
    {
        void CreateOrEditContractManagement(ContractManagementInput ContractManagementInput);
        ContractManagementInput GetContractManagementForEdit(int id);
        void DeleteContractManagement(int id);
        PagedResultDto<ContractManagementDto> GetContractManagements(ContractManagementFilter input);
        ContractManagementForViewDto GetContractManagementForView(int id);
    }
}
