using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau
{
    public interface  IDonViThauAppService
    {
        void CreateOrEditDonViThau(DonViThauInput taiSanInput);

        DonViThauInput GetDonViThauForEdit(int id);
        void DeleteDonViThau(int id);
        PagedResultDto<DonViThauDto> GetDonViThaus(DonViThauFilter input);
        DonViThauForViewDto GetDonViThauForView(int id);
    }
}
