


namespace Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("ChiTietPhieuXuatKho")]
    public partial class ChiTietPhieuXuatKho
    {
        [Key]
        public int SoPhieuXuatKho { get; set; }


        public int SoLuong { get; set; }

        [Key]
        public int MaHangHoa { get; set; }
        public decimal Gia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}