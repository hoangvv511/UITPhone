using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

public partial class NhanVien_Quyen
{

    [Key]
    public int MaChucVu { get; set; }

    [Key]
    [StringLength(50)]
    public string MaQuyen { get; set; }


    [StringLength(100)]
    public string ChuThich { get; set; } 

    //
}
