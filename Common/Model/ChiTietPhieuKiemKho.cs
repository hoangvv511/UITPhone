using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

public partial class ChiTietPhieuKiemKho
{

    [Key]
    public int SoPhieuKiemKho { get; set; }
//
    public int SoLuongHienTai { get; set; }

    [Key]
    public int MaHangHoa { get; set; }
   
    public int SoLuongKiemTra { get; set; }
}
