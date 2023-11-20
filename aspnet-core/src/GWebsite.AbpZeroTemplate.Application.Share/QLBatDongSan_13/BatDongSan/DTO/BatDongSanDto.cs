using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstas.BatDongSan.DTO
{
    public class BatDongSanDto : Entity<int>
    {
        public string MaBatDongSan { set; get; }

        public string MaPhongGiaoDich { set; get; }
        public string NgayMuaBatDongSan { set; get; }

        public float NguyenGiaTaiSan { set; get; }
        public string DiaChi { set; get; }
        public string MaTaiSan { set; get; }
        public string HienTrangBDS { set; get; }

        public string MaLoaiBDS { set; get; }

        public float ChieuDai { set; get; }

        public float ChieuRong { set; get; }

        public float DienTichDatNen { set; get; }

        public float DienTichXayDung { set; get; }

        public string MaTinhTrangSuDungDat { set; get; }
        public string MaTinhTrangXayDung { set; get; }
        public string CongNangSuDung { set; get; }

        public string KetCauNha { set; get; }

        public string RanhGioi { set; get; }

        public string MaHienTrangPhapLy { set; get; }

        public string MaLoaiSoHuu { set; get; }

        public string ChuSoHuu { set; get; }

        public string GhiChu { set; get; }

        public string FileDinhKem { set; get; }
    }
}
