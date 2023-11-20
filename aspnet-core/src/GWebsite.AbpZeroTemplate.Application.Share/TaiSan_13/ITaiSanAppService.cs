using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.TaiSan_13.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.TaiSan_13
{
    public interface  ITaiSanAppService
    {
        void CreateOrEditTaiSan(TaiSanInput taiSanInput);

        TaiSanInput GetTaiSanForEdit(int id);
        void DeleteTaiSan(int id);
        PagedResultDto<TaiSanDto> GetTaiSans(TaiSanFilter input);
        TaiSanForViewDto GetTaiSanForView(int id);
    }
}
