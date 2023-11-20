using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.NhomTaiSan.DTO
{
    public class NhomTaiSanInput : Entity<int>
    {
        public string Name { get; set; }
    }
}
