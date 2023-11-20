using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;


namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.MucDichSuDungDat.DTO
{
    public class MucDichSuDungDatInput : Entity<int>
    {
        public string Name { get; set; }
    }
}
