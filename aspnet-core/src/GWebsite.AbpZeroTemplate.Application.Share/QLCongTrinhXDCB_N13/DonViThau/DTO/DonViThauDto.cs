using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.QLCongTrinhXDCB_N13.DonViThau.DTO
{
    public class DonViThauDto : Entity<int>
    {
        public string MaDonViThau { set; get; }
        public string MaGoiThau { set; get; }
        public string TenDonViThamGiaThau { set; get; }

        public string NgayNopHoSoThau { set; get; }

        public string GiaChaoThau { set; get; }

        public string HinhThucBaoLanh { set; get; }

        public string SoChungThuBaoLanh { set; get; }

        public string TaiNganHang { set; get; }
        public bool IsTrungThau { set; get; }

        public string FileDinhKem { set; get; }

    }
}
