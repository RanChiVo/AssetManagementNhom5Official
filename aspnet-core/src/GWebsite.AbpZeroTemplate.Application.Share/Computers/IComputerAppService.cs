using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Computers.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Computers
{
    public interface IComputerAppService
    {
        void CreateOrEditComputer(ComputerInput computerInput);
        ComputerInput GetComputerForEdit(int id);
        void DeleteComputer(int id);
        PagedResultDto<ComputerDto> GetComputer(ComputerFilter input);
        ComputerForViewDto GetComputerForView(int id);
    }
}
