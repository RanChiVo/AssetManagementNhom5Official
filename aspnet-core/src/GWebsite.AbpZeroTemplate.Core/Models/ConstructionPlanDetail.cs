﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class ConstructionPlanDetail : FullAuditModel
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
