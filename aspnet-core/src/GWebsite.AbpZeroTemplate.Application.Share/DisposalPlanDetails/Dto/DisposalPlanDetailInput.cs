using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Application.Share.DisposalPlanDetails.Dto
{
    public class DisposalPlanDetailInput: Entity<int>
    {
        public string MaTS { get; set; }
        public string TenTS { get; set; }
        public float NguyenGia { get; set; }
        public float GiaTriConLai { get; set; }
        public float GiaDuKien { get; set; }
        public string TinhTrangTS { get; set; }
        public string HinhThuc { get; set; }
        public int ThangDuKien { get; set; }
        public string MaKeHoach { get; set; }
    }
}
