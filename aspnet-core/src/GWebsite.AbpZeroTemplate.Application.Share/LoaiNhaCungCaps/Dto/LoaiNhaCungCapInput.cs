using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.LoaiNhaCungCaps.Dto
{

    /// <summary>
    /// <model cref="LoaiNhaCungCap"></model>
    /// </summary>
    public class LoaiNhaCungCapInput : Entity <int>
    {
        public string MaLoaiNhaCungCap { get; set; }
        public string TenLoaiNhaCungCap { get; set; }
    }
}
