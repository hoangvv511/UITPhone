using Common.Model;
using Data.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class BaoCaoBanHangBusiness
    {
        QLWebDBEntities dbContext;
        private readonly BaoCaoTonKhoReponsitory _baoCaoTonKhoRepo;
        private readonly PhieuKiemKhoReponsitory _phieuKiemKhoRepo;

        private readonly ChiTietPhieuKiemKhoReponsitory _chiTietPhieuKiemKhoRepo;
        private readonly NhanVienReponsitory _nhanVienRepo;
        private readonly HangHoaReponsitory _hangHoaRepo;
        private NhanVienBusiness _nhanVienBus;

        public BaoCaoBanHangBusiness()
        {
            dbContext = new QLWebDBEntities();
            _phieuKiemKhoRepo = new PhieuKiemKhoReponsitory(dbContext);
            _nhanVienRepo = new NhanVienReponsitory(dbContext);
            _hangHoaRepo = new HangHoaReponsitory(dbContext);
            _chiTietPhieuKiemKhoRepo = new ChiTietPhieuKiemKhoReponsitory(dbContext);
            _nhanVienBus = new NhanVienBusiness();
        }

        public IList<BaoCaoBanHangBusiness> SearchDanhSachBaoCaoBanHang(int thang, int nam, string userName)
        {
            IQueryable<PhieuKiemKho> danhSachPhieuKiemKho = _phieuKiemKhoRepo.GetAll();
            IQueryable<BaoCaoTonKho> danhSachBaoCaoTonKho = _baoCaoTonKhoRepo.GetAll();
            IQueryable<HangHoa> danhSachHangHoa = _hangHoaRepo.GetAll();

            //List<BaoCaoTonKhoViewModel> all = new List<BaoCaoTonKhoViewModel>();
            List<BaoCaoBanHangBusiness> allForManager = new List<BaoCaoBanHangBusiness>();

            //    if (!string.IsNullOrEmpty(thang.ToString()))
            //    {
            //        allForManager = (from baocaotonkho in danhSachBaoCaoTonKho
            //                         join hanghoa in _hangHoaRepo.GetAll()
            //                         on baocaotonkho.MaHangHoa equals hanghoa.MaHangHoa
            //                         where (hanghoa.MaHangHoa.ToString().Contains(thang.ToString()))
            //                         select new
            //                         {
            //                             MaBaoCaoKho = baocaotonkho.MaBaoCaoTonKho,
            //                             SoLuongTonDau = hanghoa.SoLuongTon,
            //                             TenNhanVien = nhanvien.TenNhanvien,
            //                             TrangThai = phieukiemkho.TrangThai,
            //                             ChuThich = phieukiemkho.GhiChu,

            //                         }).AsEnumerable().Select(x => new KiemKhoViewModel()
            //                         {
            //                             soPhieuKiemKho = x.SoPhieuKiemKho,
            //                             ngayKiemKho = x.NgayKiemKho,
            //                             tenNhanVien = x.TenNhanVien,
            //                             trangThai = x.TrangThai,
            //                             ghiChu = x.ChuThich,
            //                         }).OrderByDescending(x => x.soPhieuKiemKho).ToList();
            //        return allForManager;
            //    }
            //    if (!string.IsNullOrEmpty(trangthai))
            //    {
            //        allForManager = (from phieukiemkho in danhSachPhieuKiemKho
            //                         join nhanvien in _nhanVienRepo.GetAll()
            //                         on phieukiemkho.MaNhanVien equals nhanvien.MaNhanVien
            //                         where phieukiemkho.TrangThai.ToString().Equals(trangthai)
            //                         select new
            //                         {
            //                             SoPhieuKiemKho = phieukiemkho.SoPhieuKiemKho,
            //                             NgayKiemKho = phieukiemkho.NgayKiemKho,
            //                             TenNhanVien = nhanvien.TenNhanvien,
            //                             TrangThai = phieukiemkho.TrangThai,
            //                             ChuThich = phieukiemkho.GhiChu,

            //                         }).AsEnumerable().Select(x => new KiemKhoViewModel()
            //                         {
            //                             soPhieuKiemKho = x.SoPhieuKiemKho,
            //                             ngayKiemKho = x.NgayKiemKho,
            //                             tenNhanVien = x.TenNhanVien,
            //                             trangThai = x.TrangThai,
            //                             ghiChu = x.ChuThich,
            //                         }).OrderByDescending(x => x.soPhieuKiemKho).ToList();
            //        return allForManager;
            //    }

            //allForManager = (from baocaotonkho in danhSachBaoCaoTonKho
            //                 join nhanvien in _nhanVienRepo.GetAll()
            //                 on phieukiemkho.MaHangHoa equals nhanvien.MaNhanVien
            //                 where phieukiemkho.Thang.Equals("7")
            //                 select new
            //                 {
            //                     SoPhieuKiemKho = phieukiemkho.SoLuongNhap,
            //                     NgayKiemKho = phieukiemkho.SoLuongNhap,
            //                     TenNhanVien = nhanvien.TenNhanvien,

            //                     ChuThich = phieukiemkho.SoLuongXuat,

            //                 }).AsEnumerable().Select(x => new BaoCaoTonKhoViewModel()
            //                 {
            //                     soLuongTonCuoi = x.SoPhieuKiemKho,
            //                     soLuongTonDau = x.SoPhieuKiemKho,
            //                     soLuongXuat = x.SoPhieuKiemKho

            //                 }).OrderByDescending(x => x.soLuongNhap).ToList();
            return allForManager;


        }

        // public int LoadSoPhieuKiemKho()
        //{
        //    var soPhieuKiemKho = from phieukiemkho in _phieuKiemKhoRepo.GetAll()
        //                         orderby phieukiemkho.SoPhieuKiemKho descending
        //                         select phieukiemkho.SoPhieuKiemKho;

        //    int demSoPhieu = _phieuKiemKhoRepo.GetAll().Count();
        //    if (demSoPhieu == 0)
        //    {
        //        return 1;
        //    }
        //    return (soPhieuKiemKho.First() + 1);


        //public async Task Create(BaoCaoTonKhoViewModel O)
        //{
        //    PhieuKiemKho order = new PhieuKiemKho
        //    {
        //        SoPhieuKiemKho = O.soPhieuKiemKho,
        //        NgayKiemKho = DateTime.Now,
        //        MaNhanVien = O.maNhanVien,
        //        TrangThai = true,
        //        GhiChu = O.ghiChu,
        //        NgayChinhSua = DateTime.Now,
        //    };
        //    foreach (var i in O.chiTietPhieuKiemKho)
        //    {
        //        order.ChiTietPhieuKiemKhos.Add(i);
        //    }
        //    await _phieuKiemKhoRepo.InsertAsync(order);
        //}

        //public IEnumerable<BaoCaoTonKhoViewModel> thongTinChiTietPhieuKiemKhoTheoMa(int soPhieuKiemKho)
        //{
        //    IQueryable<ChiTietPhieuKiemKho> dsPhieuKiemKho = _chiTietPhieuKiemKhoRepo.GetAll();

        //    var all = (from chitietphieukiemkho in dsPhieuKiemKho
        //               join hanghoa in _hangHoaRepo.GetAll()
        //               on chitietphieukiemkho.MaHangHoa equals hanghoa.MaHangHoa
        //               select new
        //               {
        //                   SoPhieuKiemKho = chitietphieukiemkho.SoPhieuKiemKho,
        //                   MaHangHoa = hanghoa.MaHangHoa,
        //                   SoLuongHienTai = chitietphieukiemkho.SoLuongHienTai,
        //                   SoLuongKiemTra = chitietphieukiemkho.SoLuongKiemTra,
        //                   TenHangHoa = hanghoa.TenHangHoa,
        //                   DonViTinh = hanghoa.DonViTinh,

        //               }).AsEnumerable().Select(x => new BaoCaoTonKhoViewModel()
        //               {
        //                   soPhieuKiemKho = x.SoPhieuKiemKho,
        //                   maHangHoa = x.MaHangHoa,
        //                   soLuongHienTai = x.SoLuongHienTai,
        //                   soLuongKiemTra = x.SoLuongKiemTra,
        //                   tenHangHoa = x.TenHangHoa,
        //                   donViTinh = x.DonViTinh,
        //               }).ToList();

        //    //Lấy thông tin chi tiết phiếu từ số phiếu kiểm kho
        //    var information = (from i in all
        //                       where (i.soPhieuKiemKho == soPhieuKiemKho)
        //                       select i).ToList();
        //    return information.ToList();
        //}

        //public IEnumerable<BaoCaoTonKhoViewModel> thongTinPhieuKiemKhoTheoMa(int soPhieuKiemKho)
        //{
        //    IQueryable<PhieuKiemKho> danhSachPhieuKiemKho = _phieuKiemKhoRepo.GetAll();
        //    List<BaoCaoTonKhoViewModel> all = new List<BaoCaoTonKhoViewModel>();

        //    all = (from phieukiemkho in danhSachPhieuKiemKho
        //           join nhanvien in _nhanVienRepo.GetAll()
        //           on phieukiemkho.MaNhanVien equals nhanvien.MaNhanVien
        //           where (phieukiemkho.SoPhieuKiemKho.Equals(soPhieuKiemKho))
        //           select new
        //           {
        //               SoPhieuKiemKho = phieukiemkho.SoPhieuKiemKho,
        //               NgayKiemKho = phieukiemkho.NgayKiemKho,
        //               TenNhanVien = nhanvien.TenNhanvien,
        //               TrangThai = phieukiemkho.TrangThai,
        //               ChuThich = phieukiemkho.GhiChu,
        //           }).AsEnumerable().Select(x => new BaoCaoTonKhoViewModel()
        //           {
        //               soPhieuKiemKho = x.SoPhieuKiemKho,
        //               ngayKiemKho = x.NgayKiemKho,
        //               tenNhanVien = x.TenNhanVien,
        //               trangThai = x.TrangThai,
        //               ghiChu = x.ChuThich,
        //           }).ToList();
        //    return all;
        //}

        // public async Task<object> Find(int ID)
        //{
        //    return await _phieuKiemKhoRepo.GetByIdAsync(ID);
        //}

        // public async Task HuyPhieuKiemKho(object editModel)
        //{
        //    PhieuKiemKho editPhieuKiemKho = (PhieuKiemKho)editModel;
        //    editPhieuKiemKho.TrangThai = false;

        //    await _phieuKiemKhoRepo.EditAsync(editPhieuKiemKho);
        //}
    }
}
