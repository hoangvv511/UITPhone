using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("ChiTietPhieuNhap")]
public partial class ChiTietPhieuNhap
{
    [Key]
    public int SoPhieuNhap { get; set; }


    public int SoLuong { get; set; }

    [Key]
    public int MaHangHoa { get; set; }
    public int GiaNhap { get; set; }
    public int ThanhTien { get; set; }





}
