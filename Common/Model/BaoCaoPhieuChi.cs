namespace Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaoCaoPhieuChi")]
    public partial class BaoCaoPhieuChi
    {
        [Key]
        public int MaBaoCaoPhieuChi { get; set; }

        public DateTime NgayChi { get; set; }

        public string GhiChu { get; set; }

        public decimal TongTien { get; set; }

      
    }
}
