using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCapHangHoas.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.NhaCungCapHangHoas
{
    public interface INhaCungCapHangHoaAppService
    {
        void CreateOrEditNhaCungCapHangHoa(NhaCungCapHangHoaInput NhaCungCapHangHoaInput);
        NhaCungCapHangHoaInput GetNhaCungCapHangHoaForEdit(int id);
        void DeleteNhaCungCapHangHoa(int id);
        PagedResultDto<NhaCungCapHangHoaDto> GetNhaCungCapHangHoas(NhaCungCapHangHoaFilter input);
        PagedResultDto<NhaCungCapHangHoaDto> GetAllNhaCungCapHangHoas(NhaCungCapHangHoaFilterName input);
        NhaCungCapHangHoaForViewDto GetNhaCungCapHangHoaForView(int id);
        NhaCungCapHangHoaForViewDto GetNhaCungCapHangHoaForViewName(string maloainhacungcap);
        // dùng để đổ dữ liệu từ sql vào combobox
        Task<LoaiNhaCungCapOutput> GetLoaiNhaCungCapComboboxForEditAsync(NullableIdDto input);
        Task<NhaCungCapHangHoaOutput> GetNhaCungCapComboboxForEditAsync(string  maloainhacungcap);
     
    }
}

