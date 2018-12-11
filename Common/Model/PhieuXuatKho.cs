using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


[Table("PhieuXuatKho")]
public partial class PhieuXuatKho
{
    [Key]
    public int SoPhieuXuatKho { get; set; }


    [Column("Name", TypeName = "date")]
    public DateTime NgayXuat { get; set; }


    public int MaNhanVien { get; set; }

    [StringLength(200)]
    public string LyDoXuat { get; set; }
    public decimal TongTien { get; set; }

    public DateTime NgayChinhSua { get; set; }


    public bool TrangThai { get; set; }
}
