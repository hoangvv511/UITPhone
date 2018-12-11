namespace Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuBaoHanh")]
    public partial class ChiTietPhieuBaoHanh
    {

        [Key]
        public int SoPhieuBaoHanh { get; set; }

        [Key]
        public int MaHangHoa { get; set; }


        public int SoLuong { get; set; }

        [StringLength(200)]
        public string NoiDungBaoHanh { get; set; }
        public decimal Gia { get; set; }
        public decimal ThanhTien { get; set; }
        [StringLength(200)]
        public string GhiChu { get; set; }

    }
}
