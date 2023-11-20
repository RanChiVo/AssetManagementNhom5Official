using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.LoaiTaiSan.DTO
{
    public class LoaiTaiSanInput : Entity<int>
    {
        public string Name { get; set; }
    }
}
