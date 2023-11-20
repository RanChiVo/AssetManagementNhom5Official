using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Constructions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GWebsite.AbpZeroTemplate.Application.Share.Constructions
{
    public interface IConstructionAppService
    {
        void CreateOrEditConstruction(ConstructionInput ConstructiongInput);
        ConstructionInput GetConstructionForEdit(int id);
        ConstructionInput GetConstructionForEditWithMaCongTrinh(string ma);
        void DeleteConstruction(int id);
        PagedResultDto<ConstructionDto> GetConstructions(ConstructionFilter input);
        ConstructionForViewDto GetConstructionForView(int id);
    }
}
