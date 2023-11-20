using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.KhuVuc.DTO
{
    public class KhuVucInput : Entity<int>
    {
        public string Name { get; set; }
    }
}
