using GWebsite.AbpZeroTemplate.Core.Models;
using System;

namespace GWebsite.AbpZeroTemplate.Application.Share.RealEstates.Dto
{
    /// <summary>
    /// <model cref="RealEstate_9"></model>
    /// </summary>
    public class RealEstateForViewDto_9
    {

        #region Thông tin tài sản
        public string MaTaiSan { get; set; }
        public string TenTaiSan { get; set; }
        public string LoaiTaiSan { get; set; }
        public string NhomTaiSan { get; set; }
        public string ThongTin { get; set; }
        public string NgayBDKhauHao { get; set; }
        public string SoThangKhauHao { get; set; }
        public string NgayKTKhauHao { get; set; }
        public string NguyenGia { get; set; }
        public string GiaTriKhauHao { get; set; }
        public string GiaTriKhauHaoConLai { get; set; }
        public string NguoiSuDung { get; set; }
        public string TinhTrangTaiSan { get; set; }
        public string DonViSuDung { get; set; }
        public string TinhTrangKhauHao { get; set; }

        #endregion

        #region Thông tin bất động sản
        public string MaBatDongSan { get; set; }
        public string HienTrang { get; set; }
        public string MaLoaiBatDongSan { get; set; }
        public float ChieuDai { get; set; }
        public float ChieuRong { get; set; }
        public float DienTichDat { get; set; }

        public string NgayMuaBatDongSan { get; set; }
        public string ThoiHanSuDung { get; set; }
        public string TinhTrangSuDung { get; set; }
        public string KetCauNha { get; set; }
        public string RanhGioi { get; set; }
        public string TrangThaiDuyet { get; set; }
        public string TinhTrangPhapLy { get; set; }
        public string NguonGocTaiSan { get; set; }
        public string FileDinhKem { get; set; }
        #endregion
    }
}
