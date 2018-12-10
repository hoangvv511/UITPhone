using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("ChiTietPhieuBanHang")]
public partial class ChiTietPhieuBanHang
{
    [Key]
    public int SoPhieuBanHang { get; set; }


    public int SoLuong { get; set; }

    [Key]
    public int MaHangHoa { get; set; }
    public int Gia { get; set; }
    public int ThanhTien { get; set; }

}
