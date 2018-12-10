using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("PhieuDatHang")]
public partial class PhieuDatHang
{
    [Key]
    public int SoPhieuDatHang { get; set; }


    public DateTime NgayDat { get; set; }

    public int MaNhanVien { get; set; }

    [StringLength(200)]
    public string TenKhachHang { get; set; }

    [StringLength(15)]
    public string SoDienThoai { get; set; }

    [StringLength(200)]
    public string Diachi { get; set; }

    [StringLength(30)]
    public string Email { get; set; }

    public int TongTien { get; set; }

    [StringLength(200)]
    public string HinhThucThanhToan { get; set; }

    public string Ghichu { get; set; }
    public DateTime NgayGiao { get; set; }
    
    public bool DaXacNhan { get; set; }
    public bool DaThanhToan { get; set; }
    public bool TrangThai { get; set; }




}
