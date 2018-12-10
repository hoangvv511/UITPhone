using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("PhieuKiemKho")]
public partial class PhieuKiemKho
{
    [Key]
    public int SoPhieuKiemKho { get; set; }


    public DateTime NgayKiemKho { get; set; }
    

    public int MaNhanVien { get; set; }





    [StringLength(200)]
    public string Ghichu { get; set; }
    
    public DateTime NgayChinhSua { get; set; }


    public bool TrangThai { get; set; }
}
