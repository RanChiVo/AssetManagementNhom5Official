
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCapHangHoas;
using GWebsite.AbpZeroTemplate.Application.Share.NhaCungCapHangHoas.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps;
using GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace GWebsite.AbpZeroTemplate.Web.Core.NhaCungCapHangHoas
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_NhaCungCapHangHoa)]
    public class NhaCungCapHangHoaAppService : GWebsiteAppServiceBase, INhaCungCapHangHoaAppService
    {
        private readonly IRepository<NhaCungCapHangHoa> NhaCungCapHangHoaRepository;
        private readonly IRepository<LoaiNhaCungCap> LoaiNhaCungCapRepository;
       

        public NhaCungCapHangHoaAppService(IRepository<NhaCungCapHangHoa> NhaCungCapHangHoaRepository, IRepository<LoaiNhaCungCap> LoaiNhaCungCapRepository)
        {
            this.NhaCungCapHangHoaRepository = NhaCungCapHangHoaRepository;
            this.LoaiNhaCungCapRepository = LoaiNhaCungCapRepository;
        }

        #region Public Method

        public void CreateOrEditNhaCungCapHangHoa(NhaCungCapHangHoaInput NhaCungCapHangHoaInput)
        {
            if (NhaCungCapHangHoaInput.Id == 0)
            {
                Create(NhaCungCapHangHoaInput);
            }
            else
            {
                Update(NhaCungCapHangHoaInput);
            }
        }

        public void DeleteNhaCungCapHangHoa(int id)
        {
            var NhaCungCapHangHoaEntity = NhaCungCapHangHoaRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (NhaCungCapHangHoaEntity != null)
            {
                NhaCungCapHangHoaEntity.IsDelete = true;
                NhaCungCapHangHoaRepository.Update(NhaCungCapHangHoaEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }
        // dùng để đổ dữ liệu từ sql vào combobox LoaiNhaCungCapHangHoa
        // Cần khai báo thêm các thư viện để có thể sử dụng
        public async Task<LoaiNhaCungCapOutput> GetLoaiNhaCungCapComboboxForEditAsync(NullableIdDto input)
        {
            LoaiNhaCungCap loaiNhaCungCap = null;
            if (input.Id.HasValue && input.Id.Value > 0)
            {
                loaiNhaCungCap = await LoaiNhaCungCapRepository.GetAsync(input.Id.Value);
            }
            var output = new LoaiNhaCungCapOutput();

            output.LoaiNhaCungCap = loaiNhaCungCap != null
                ? ObjectMapper.Map<LoaiNhaCungCapDto>(loaiNhaCungCap)
                : new LoaiNhaCungCapDto();

            output.LoaiNhaCungCaps = await LoaiNhaCungCapRepository.GetAll()
                .Select(c => new ComboboxItemDto(c.Id.ToString(), c.TenLoaiNhaCungCap))
                .ToListAsync();

            return output;
        }
        public async Task<NhaCungCapHangHoaOutput> GetNhaCungCapComboboxForEditAsync(string maLoaiNhaCungCap)
        {
            NhaCungCapHangHoa nhaCungCapHangHoa = null;
            if (maLoaiNhaCungCap != null && maLoaiNhaCungCap.Length > 0)
            {
                nhaCungCapHangHoa = NhaCungCapHangHoaRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => String.Compare(x.MaLoaiNhaCungCap,maLoaiNhaCungCap)==1);
            }
            var output = new NhaCungCapHangHoaOutput();

            output.NhaCungCapHangHoa = nhaCungCapHangHoa != null
                ? ObjectMapper.Map<NhaCungCapHangHoaDto>(nhaCungCapHangHoa)
                : new NhaCungCapHangHoaDto();

            output.NhaCungCapHangHoas = await NhaCungCapHangHoaRepository.GetAll()
                .Select(c => new NhaCungCapHangHoa(c.MaNhaCungCap,c.TenNhaCungCap,c.MaLoaiNhaCungCap,c.DiaChi,c.Email,c.SoDienThoai,c.NguoiLienHe,c.HoatDong,c.GhiChu))
                .ToListAsync();

            return output;
        }
        public NhaCungCapHangHoaInput GetNhaCungCapHangHoaForEdit(int id)
        {
            var NhaCungCapHangHoaEntity = NhaCungCapHangHoaRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (NhaCungCapHangHoaEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<NhaCungCapHangHoaInput>(NhaCungCapHangHoaEntity);
        }
        public NhaCungCapHangHoaForViewDto GetNhaCungCapHangHoaForView(int id)
        {
            var NhaCungCapHangHoaEntity = NhaCungCapHangHoaRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (NhaCungCapHangHoaEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<NhaCungCapHangHoaForViewDto>(NhaCungCapHangHoaEntity);
        }
        public NhaCungCapHangHoaForViewDto GetNhaCungCapHangHoaForViewName(string maloainhacungcap)
        {
            var NhaCungCapHangHoaEntity = NhaCungCapHangHoaRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => String.Compare(x.MaLoaiNhaCungCap,maloainhacungcap) ==1);
            if (NhaCungCapHangHoaEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<NhaCungCapHangHoaForViewDto>(NhaCungCapHangHoaEntity);
        }
        public PagedResultDto<NhaCungCapHangHoaDto> GetNhaCungCapHangHoas(NhaCungCapHangHoaFilter input)
        {
            var query = NhaCungCapHangHoaRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaNhaCungCap != null)
            {
                query = query.Where(x => x.MaNhaCungCap.ToLower().Equals(input.MaNhaCungCap));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<NhaCungCapHangHoaDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<NhaCungCapHangHoaDto>(item)).ToList());
        }
        public PagedResultDto<NhaCungCapHangHoaDto> GetAllNhaCungCapHangHoas(NhaCungCapHangHoaFilterName input)
        {
            var query = NhaCungCapHangHoaRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.MaLoaiNhaCungCap != null)
            {
                query = query.Where(x => x.MaLoaiNhaCungCap.ToLower().Equals(input.MaLoaiNhaCungCap));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<NhaCungCapHangHoaDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<NhaCungCapHangHoaDto>(item)).ToList());
        }
        #endregion
        #region Private Method
        [AbpAuthorize(GWebsitePermissions.Pages_Administration_NhaCungCapHangHoa_Create)]
        private void Create(NhaCungCapHangHoaInput nhaCungCapHangHoaInput)
        {
            var NhaCungCapHangHoaEntity = ObjectMapper.Map<NhaCungCapHangHoa>(nhaCungCapHangHoaInput);
            SetAuditInsert(NhaCungCapHangHoaEntity);
            NhaCungCapHangHoaRepository.Insert(NhaCungCapHangHoaEntity);
            CurrentUnitOfWork.SaveChanges();
        }
        [AbpAuthorize(GWebsitePermissions.Pages_Administration_NhaCungCapHangHoa_Edit)]
        private void Update(NhaCungCapHangHoaInput nhaCungCapHangHoaInput)
        {
            var NhaCungCapHangHoaEntity = NhaCungCapHangHoaRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == nhaCungCapHangHoaInput.Id);
            if (NhaCungCapHangHoaEntity == null)
            {
            }
            ObjectMapper.Map(nhaCungCapHangHoaInput, NhaCungCapHangHoaEntity);
            SetAuditEdit(NhaCungCapHangHoaEntity);
            NhaCungCapHangHoaRepository.Update(NhaCungCapHangHoaEntity);
            CurrentUnitOfWork.SaveChanges();
           
        }
        #endregion
    }
}
