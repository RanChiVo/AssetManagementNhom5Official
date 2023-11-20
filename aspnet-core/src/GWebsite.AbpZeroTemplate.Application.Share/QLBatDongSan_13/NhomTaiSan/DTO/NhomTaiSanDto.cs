using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.NhomTaiSan.DTO
{
    public class NhomTaiSanDto : Entity<int>
    {
        public string Name { get; set; }
    }
}
