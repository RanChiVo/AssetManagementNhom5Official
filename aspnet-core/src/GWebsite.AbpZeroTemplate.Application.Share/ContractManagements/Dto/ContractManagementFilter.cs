using GSoft.AbpZeroTemplate.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.ContractManagements.Dto
{
    /// <summary>
    /// <model cref="ContractManagement"></model>
    /// </summary>
    public class ContractManagementFilter : PagedAndSortedInputDto
    {

        public string SoHopDong { get; set; }
        public string MaHoSoThau { get; set; }

        public string MaToTrinh { get; set; }
        public string MaCongTrinh { get; set; }
    }
}

