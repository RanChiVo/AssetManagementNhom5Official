using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlanDetails.Dto
{
    public class ConstructionPlanDetailDto :Entity<int>
    {
        public string MaCT { get; set; }
        public string TenCT { get; set; }
        public string DuKienXayDung { get; set; }
        public string DuKienHoanThanh { get; set; }
        public string ThoiGianThucHien { get; set; }
        public string KinhPhiDeXuat { get; set; }
        public string KinhPhiTrinh { get; set; }
        public string KinhPhiDuocDuyet { get; set; }
        public string GhiChu { get; set; }
        public string MaKeHoach { get; set; }
    }
}
