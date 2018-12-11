

namespace Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

<<<<<<< HEAD
[Table("PhieuXuatKho")]
public partial class PhieuXuatKho
{
    [Key]
    public int SoPhieuXuatKho { get; set; }
=======

    [Table("PhieuXuatKho")]
    public partial class PhieuXuatKho

    {

        public PhieuXuatKho()
        {
            ChiTietPhieuXuatKhos = new HashSet<ChiTietPhieuXuatKho>();
        }

        public virtual ICollection<ChiTietPhieuXuatKho> ChiTietPhieuXuatKhos { get; set; }
        [Key]
        public int SoPhieuXuatKho { get; set; }
>>>>>>> 08ac57c19a6a4e40010110db25f55a98f0113a8f


        [Column("Name", TypeName = "date")]
        public DateTime NgayXuat { get; set; }


        public int MaNhanVien { get; set; }

        [StringLength(200)]
        public string LyDoXuat { get; set; }
        public decimal TongTien { get; set; }

        public DateTime NgayChinhSua { get; set; }


        public bool TrangThai { get; set; }
    }
}