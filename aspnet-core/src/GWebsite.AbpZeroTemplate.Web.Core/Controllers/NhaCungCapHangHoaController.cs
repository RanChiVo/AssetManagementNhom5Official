using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCapHangHoas;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCapHangHoas.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps;
using GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps.Dto;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class NhaCungCapHangHoaController : GWebsiteControllerBase
    {
        private readonly INhaCungCapHangHoaAppService NhaCungCapHangHoaAppService;

        public NhaCungCapHangHoaController(INhaCungCapHangHoaAppService NhaCungCapHangHoaAppService)
        {
            this.NhaCungCapHangHoaAppService = NhaCungCapHangHoaAppService;
        }

        [HttpGet]
        public PagedResultDto<NhaCungCapHangHoaDto> GetNhaCungCapHangHoasByFilter(NhaCungCapHangHoaFilter nhaCungCapHangHoaFilter)
        {
            return NhaCungCapHangHoaAppService.GetNhaCungCapHangHoas(nhaCungCapHangHoaFilter);
        }

        [HttpGet]
        public PagedResultDto<NhaCungCapHangHoaDto> GetAllNhaCungCapHangHoasByFilter(NhaCungCapHangHoaFilterName nhaCungCapHangHoaFilterName)
        {
            return NhaCungCapHangHoaAppService.GetAllNhaCungCapHangHoas(nhaCungCapHangHoaFilterName);
        }

        [HttpGet]
        public NhaCungCapHangHoaInput GetNhaCungCapHangHoaForEdit(int id)
        {
            return NhaCungCapHangHoaAppService.GetNhaCungCapHangHoaForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditNhaCungCapHangHoa([FromBody] NhaCungCapHangHoaInput input)
        {
            NhaCungCapHangHoaAppService.CreateOrEditNhaCungCapHangHoa(input);
        }

        [HttpDelete("{id}")]
        public void DeleteNhaCungCapHangHoa(int id)
        {
            NhaCungCapHangHoaAppService.DeleteNhaCungCapHangHoa(id);
        }

        [HttpGet]
        public NhaCungCapHangHoaForViewDto GetNhaCungCapHangHoaForView(int id)
        {
            return NhaCungCapHangHoaAppService.GetNhaCungCapHangHoaForView(id);
        }
        [HttpGet]
        public NhaCungCapHangHoaForViewDto GetNhaCungCapHangHoaForViewName(string maloainhacungcap)
        {
            return NhaCungCapHangHoaAppService.GetNhaCungCapHangHoaForViewName(maloainhacungcap);
        }
        // dùng để đổ dữ liệu từ sql vào combobox LoaiNhaCungCapHangHoa
        [HttpGet]
        public async Task<LoaiNhaCungCapOutput> GetLoaiNhaCungCapComboboxForEditAsync(int id)
        {
            return await NhaCungCapHangHoaAppService.GetLoaiNhaCungCapComboboxForEditAsync(new NullableIdDto() { Id = id });
        }

        [HttpGet]
        public async Task<NhaCungCapHangHoaOutput> GetNhaCungCapComboboxForEditAsync(string maLoaiNhaCungCap)
        {
            return await NhaCungCapHangHoaAppService.GetNhaCungCapComboboxForEditAsync(maLoaiNhaCungCap);
        }
    }
}
