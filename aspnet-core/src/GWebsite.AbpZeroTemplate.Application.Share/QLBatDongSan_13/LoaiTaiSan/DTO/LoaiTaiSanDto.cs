using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiTaiSan.DTO
{
    public class LoaiTaiSanDto : Entity<int>
    {
        public string Name { get; set; }
    }
}
