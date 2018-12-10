

namespace Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    public partial class QLWebDBEntities:DbContext
    {

        public QLWebDBEntities():base("name=QLWebDBEntities")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<BaoCaoTonKho> BaoCaoTonKhos { get; set; }
        public virtual DbSet<ChiTietPhieuBanHang> ChiTietPhieuBanHanges { get; set; }
        public virtual DbSet<ChiTietPhieuBaoHanh> ChiTietPhieuBaoHanhs { get; set; }
        public virtual DbSet<ChiTietPhieuDatHang> ChiTietPhieuDatHanges { get; set; }
        public virtual DbSet<ChiTietPhieuKiemKho> ChiTietPhieuKiemKhoes { get; set; }
        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhapes { get; set; }
        public virtual DbSet<ChiTietPhieuXuatKho> ChiTietPhieuXuatKhoes { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<LoaiHangHoa> LoaiHangHoas { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhanVien_Quyen> NhanVien_Quyens { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<PhieuBanHang> PhieuBanHangs { get; set; }
        public virtual DbSet<PhieuBaoHanh> PhieuBaoHanhs { get; set; }
        public virtual DbSet<PhieuChi> PhieuChis { get; set; }
        public virtual DbSet<PhieuDatHang> PhieuDatHangs { get; set; }
        public virtual DbSet<PhieuKiemKho> PhieuKiemKhos { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<PhieuXuatKho> PhieuXuatKhos { get; set; }
        public virtual DbSet<ThamSo> ThamSos { get; set; }

    }
}
