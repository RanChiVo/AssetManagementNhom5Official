using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.InsurranceTypes.Dto
{
    /// <summary>
    /// <model cref="InsurranceType"></model>
    /// </summary>
    public class InsurranceTypeInput : Entity<int>
    {
        public string InsurranceTypeId { get; set; }
        public string InsurranceTypeName { get; set; }
    }
}
