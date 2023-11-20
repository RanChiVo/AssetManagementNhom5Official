using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.MucDichSuDungDat.DTO
{
    public class MucDichSuDungDatFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}
