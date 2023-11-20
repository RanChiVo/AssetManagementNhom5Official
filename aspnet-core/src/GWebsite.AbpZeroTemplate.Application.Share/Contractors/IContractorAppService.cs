using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Contractors.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GWebsite.AbpZeroTemplate.Application.Share.Contractors
{
    public interface IContractorAppService
    {
        void CreateOrEditContractor(ContractorInput ContractorInput);
        ContractorInput GetContractorForEdit(int id);
        ContractorInput GetContractorForEditWithMaHoSoThau(string ma);
        void DeleteContractor(int id);
        PagedResultDto<ContractorDto> GetContractors(ContractorFilter input);
        ContractorForViewDto GetContractorForView(int id);
    }
}
