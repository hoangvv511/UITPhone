using Common.Model;
using Common.ViewModels;
using Data.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class PhieuBanHangBusiness
    {
        QLWebDBEntities dbContext;
        private readonly PhieuBanHangReponsitory _phieuBanHangRepo;
        private readonly ChiTietPhieuBanHangReponsitory _chiTietPhieuBanHangRepo;
        private readonly NhanVienReponsitory _nhanVienRepo;
        private readonly HangHoaReponsitory _hangHoaRepo;
        private NhanVienBusiness _nhanVienBus;
        private HangHoaBusiness _hangHoaBus;

        public PhieuBanHangBusiness()
        {
            dbContext = new QLWebDBEntities();
            _phieuBanHangRepo = new PhieuBanHangReponsitory(dbContext);
            _nhanVienRepo = new NhanVienReponsitory(dbContext);
            _hangHoaRepo = new HangHoaReponsitory(dbContext);
            _chiTietPhieuBanHangRepo = new ChiTietPhieuBanHangReponsitory(dbContext);
            _nhanVienBus = new NhanVienBusiness();
            _hangHoaBus = new HangHoaBusiness();
        }


        public IList<PhieuBanHangViewModel> SearchDanhSachPhieuBanHang(String key, string trangthai, DateTime tungay, DateTime denngay, string userName)
        {
            IQueryable<PhieuBanHang> danhSachPhieuBanHang = _phieuBanHangRepo.GetAll();
            List<PhieuBanHangViewModel> all = new List<PhieuBanHangViewModel>();
            List<PhieuBanHangViewModel> allForManager = new List<PhieuBanHangViewModel>();

            //Nếu là nhân viên
            if (_nhanVienBus.layMaChucVu(userName) == 4)
            {
                if ((!(tungay == default(DateTime))) && (!(denngay == default(DateTime))))
                {
                    all = (from phieubanhang in danhSachPhieuBanHang
                                     join nhanvien in _nhanVienRepo.GetAll()
                                     on phieubanhang.MaNhanVien equals nhanvien.MaNhanVien
                                     where (nhanvien.MaNhanVien.Equals(userName) && (phieubanhang.NgayBan >= tungay.Date && phieubanhang.NgayBan <= denngay.Date))
                                     select new
                                     {
                                         SoPhieuBanHang = phieubanhang.SoPhieuBanHang,
                                         NgayBan = phieubanhang.NgayBan,
                                         TenNhanVien = nhanvien.TenNhanvien,
                                         KhachHang=phieubanhang.TenKhachHang,
                                         TongTien=phieubanhang.TongTien,
                                         TrangThai = phieubanhang.TrangThai,
                                         ChuThich = phieubanhang.Ghichu,
                                         SoDienThoai = phieubanhang.SoDienThoai

                                     }).AsEnumerable().Select(x => new PhieuBanHangViewModel()
                                     {
                                         soPhieuBanHang = x.SoPhieuBanHang,
                                         ngayBan = x.NgayBan,
                                         tenKhachHang = x.KhachHang,
                                         tongTien = x.TongTien,
                                         tenNhanVien = x.TenNhanVien,
                                         trangThai = x.TrangThai,
                                         soDienThoai = x.SoDienThoai,
                                         ghiChu = x.ChuThich,
                                     }).OrderByDescending(x => x.soPhieuBanHang).ToList();
                    return all;
                }
                if (!string.IsNullOrEmpty(key))
                {
                    all = (from phieubanhang in danhSachPhieuBanHang
                           join nhanvien in _nhanVienRepo.GetAll()
                           on phieubanhang.MaNhanVien equals nhanvien.MaNhanVien
                           where (nhanvien.UserName.Equals(userName) && (
                                     phieubanhang.SoPhieuBanHang.ToString().Contains(key)
                                  || phieubanhang.TenKhachHang.Contains(key)
                                  || phieubanhang.SoDienThoai.Contains(key)))
                           select new
                           {
                               KhachHang = phieubanhang.TenKhachHang,
                               TongTien = phieubanhang.TongTien,
                               SoPhieuBanHang = phieubanhang.SoPhieuBanHang,
                               NgayBan = phieubanhang.NgayBan,
                               TenNhanVien = nhanvien.TenNhanvien,
                               TrangThai = phieubanhang.TrangThai,
                               ChuThich = phieubanhang.Ghichu,
                               SoDienThoai = phieubanhang.SoDienThoai

                           }).AsEnumerable().Select(x => new PhieuBanHangViewModel()
                           {
                               tenKhachHang = x.KhachHang,
                               tongTien = x.TongTien,
                               soPhieuBanHang = x.SoPhieuBanHang,
                               ngayBan = x.NgayBan,
                               tenNhanVien = x.TenNhanVien,
                               trangThai = x.TrangThai,
                               ghiChu = x.ChuThich,
                               soDienThoai = x.SoDienThoai,
                           }).OrderByDescending(x => x.soPhieuBanHang).ToList();
                    return all;
                }
                if (!string.IsNullOrEmpty(trangthai))
                {
                    all = (from phieubanhang in danhSachPhieuBanHang
                           join nhanvien in _nhanVienRepo.GetAll()
                           on phieubanhang.MaNhanVien equals nhanvien.MaNhanVien
                           where (nhanvien.UserName.Equals(userName) && phieubanhang.TrangThai.ToString().Equals(trangthai))
                           select new
                           {
                               KhachHang = phieubanhang.TenKhachHang,
                               TongTien = phieubanhang.TongTien,
                               SoPhieuBanHang = phieubanhang.SoPhieuBanHang,
                               NgayBan = phieubanhang.NgayBan,
                               TenNhanVien = nhanvien.TenNhanvien,
                               TrangThai = phieubanhang.TrangThai,
                               ChuThich = phieubanhang.Ghichu,
                               SoDienThoai = phieubanhang.SoDienThoai
                           }).AsEnumerable().Select(x => new PhieuBanHangViewModel()
                           {
                               tenKhachHang = x.KhachHang,
                               tongTien = x.TongTien,
                               soPhieuBanHang = x.SoPhieuBanHang,
                               ngayBan = x.NgayBan,
                               tenNhanVien = x.TenNhanVien,
                               trangThai = x.TrangThai,
                               ghiChu = x.ChuThich,
                               soDienThoai = x.SoDienThoai,
                           }).OrderByDescending(x => x.soPhieuBanHang).ToList();
                    return all;
                }
             
                    all = (from phieubanhang in danhSachPhieuBanHang
                       join nhanvien in _nhanVienRepo.GetAll()
                       on phieubanhang.MaNhanVien equals nhanvien.MaNhanVien
                       where (nhanvien.UserName.Equals(userName) && phieubanhang.TrangThai.Equals(true))
                       select new
                       {
                           KhachHang = phieubanhang.TenKhachHang,
                           TongTien = phieubanhang.TongTien,
                           SoPhieuBanHang = phieubanhang.SoPhieuBanHang,
                           NgayBan = phieubanhang.NgayBan,
                           TenNhanVien = nhanvien.TenNhanvien,
                           TrangThai = phieubanhang.TrangThai,
                           ChuThich = phieubanhang.Ghichu,
                           SoDienThoai = phieubanhang.SoDienThoai

                       }).AsEnumerable().Select(x => new PhieuBanHangViewModel()
                       {
                           tenKhachHang = x.KhachHang,
                           tongTien = x.TongTien,
                           soPhieuBanHang = x.SoPhieuBanHang,
                           ngayBan = x.NgayBan,
                           tenNhanVien = x.TenNhanVien,
                           trangThai = x.TrangThai,
                           ghiChu = x.ChuThich,
                           soDienThoai = x.SoDienThoai,
                       }).OrderByDescending(x => x.soPhieuBanHang).ToList();
                return all;
            }
            else
            {
                if ((!(tungay == default(DateTime))) && (!(denngay == default(DateTime))))
                {
                    allForManager = (from phieubanhang in danhSachPhieuBanHang
                                     join nhanvien in _nhanVienRepo.GetAll()
                                     on phieubanhang.MaNhanVien equals nhanvien.MaNhanVien
                                     where (phieubanhang.NgayBan >= tungay.Date && phieubanhang.NgayBan <= denngay.Date)
                                     select new
                                     {


                                         KhachHang = phieubanhang.TenKhachHang,
                                         TongTien = phieubanhang.TongTien,
                                         SoPhieuBanHang = phieubanhang.SoPhieuBanHang,
                                         NgayBan = phieubanhang.NgayBan,
                                         TenNhanVien = nhanvien.TenNhanvien,
                                         TrangThai = phieubanhang.TrangThai,
                                         ChuThich = phieubanhang.Ghichu,
                                         SoDienThoai = phieubanhang.SoDienThoai

                                     }).AsEnumerable().Select(x => new PhieuBanHangViewModel()
                                     {
                                         tenKhachHang = x.KhachHang,
                                         tongTien = x.TongTien,
                                         soPhieuBanHang = x.SoPhieuBanHang,
                                         ngayBan = x.NgayBan,
                                         tenNhanVien = x.TenNhanVien,
                                         trangThai = x.TrangThai,
                                         ghiChu = x.ChuThich,
                                         soDienThoai = x.SoDienThoai,
                                     }).OrderByDescending(x => x.soPhieuBanHang).ToList();
                    return allForManager;
                }
                if (!string.IsNullOrEmpty(key))
                {
                    allForManager = (from phieubanhang in danhSachPhieuBanHang
                                     join nhanvien in _nhanVienRepo.GetAll()
                                     on phieubanhang.MaNhanVien equals nhanvien.MaNhanVien
                                     where (phieubanhang.SoPhieuBanHang.ToString().Contains(key)
                                            || phieubanhang.TenKhachHang.Contains(key)
                                            || phieubanhang.SoDienThoai.Contains(key))
                                     select new
                                     {
                                         KhachHang = phieubanhang.TenKhachHang,
                                         TongTien = phieubanhang.TongTien,
                                         SoPhieuBanHang = phieubanhang.SoPhieuBanHang,
                                         NgayBan = phieubanhang.NgayBan,
                                         TenNhanVien = nhanvien.TenNhanvien,
                                         TrangThai = phieubanhang.TrangThai,
                                         ChuThich = phieubanhang.Ghichu,
                                         SoDienThoai = phieubanhang.SoDienThoai

                                     }).AsEnumerable().Select(x => new PhieuBanHangViewModel()
                                     {
                                         tenKhachHang = x.KhachHang,
                                         tongTien = x.TongTien,
                                         soPhieuBanHang = x.SoPhieuBanHang,
                                         ngayBan = x.NgayBan,
                                         tenNhanVien = x.TenNhanVien,
                                         trangThai = x.TrangThai,
                                         ghiChu = x.ChuThich,
                                         soDienThoai = x.SoDienThoai,
                                     }).OrderByDescending(x => x.soPhieuBanHang).ToList();
                    return allForManager;
                }            
                if (!string.IsNullOrEmpty(trangthai))
                {
                    allForManager = (from phieubanhang in danhSachPhieuBanHang
                                     join nhanvien in _nhanVienRepo.GetAll()
                                     on phieubanhang.MaNhanVien equals nhanvien.MaNhanVien
                                     where phieubanhang.TrangThai.ToString().Equals(trangthai)
                                     select new
                                     {
                                         KhachHang = phieubanhang.TenKhachHang,
                                         TongTien = phieubanhang.TongTien,
                                         SoPhieuBanHang = phieubanhang.SoPhieuBanHang,
                                         NgayBan = phieubanhang.NgayBan,
                                         TenNhanVien = nhanvien.TenNhanvien,
                                         TrangThai = phieubanhang.TrangThai,
                                         ChuThich = phieubanhang.Ghichu,
                                         SoDienThoai = phieubanhang.SoDienThoai

                                     }).AsEnumerable().Select(x => new PhieuBanHangViewModel()
                                     {
                                         tenKhachHang = x.KhachHang,
                                         tongTien = x.TongTien,
                                         soPhieuBanHang = x.SoPhieuBanHang,
                                         ngayBan = x.NgayBan,
                                         tenNhanVien = x.TenNhanVien,
                                         trangThai = x.TrangThai,
                                         ghiChu = x.ChuThich,
                                         soDienThoai = x.SoDienThoai,
                                     }).OrderByDescending(x => x.soPhieuBanHang).ToList();
                    return allForManager;
                }

                allForManager = (from phieubanhang in danhSachPhieuBanHang
                                 join nhanvien in _nhanVienRepo.GetAll()
                                 on phieubanhang.MaNhanVien equals nhanvien.MaNhanVien
                                 where phieubanhang.TrangThai.Equals(true)
                                 select new
                                 {
                                     KhachHang = phieubanhang.TenKhachHang,
                                     TongTien = phieubanhang.TongTien,
                                     SoPhieuBanHang = phieubanhang.SoPhieuBanHang,
                                     NgayBan = phieubanhang.NgayBan,
                                     TenNhanVien = nhanvien.TenNhanvien,
                                     TrangThai = phieubanhang.TrangThai,
                                     ChuThich = phieubanhang.Ghichu,
                                     SoDienThoai = phieubanhang.SoDienThoai

                                 }).AsEnumerable().Select(x => new PhieuBanHangViewModel()
                                 {
                                     tenKhachHang = x.KhachHang,
                                     tongTien = x.TongTien,
                                     soPhieuBanHang = x.SoPhieuBanHang,
                                     ngayBan = x.NgayBan,
                                     tenNhanVien = x.TenNhanVien,
                                     trangThai = x.TrangThai,
                                     ghiChu = x.ChuThich,
                                     soDienThoai = x.SoDienThoai,
                                 }).OrderByDescending(x => x.soPhieuBanHang).ToList();
                return allForManager;
            }
        }

        public int LoadSoPhieuBanHang()
        {
            var soPhieuBanHang = from phieubanhang in _phieuBanHangRepo.GetAll()
                                 orderby phieubanhang.SoPhieuBanHang descending
                                 select phieubanhang.SoPhieuBanHang;

            int demSoPhieu = _phieuBanHangRepo.GetAll().Count();
            if (demSoPhieu == 0)
            {
                return 1;
            }
            return (soPhieuBanHang.First() + 1);
        }

        public async Task Create(PhieuBanHangViewModel O)
        {
            var nhanVien = _nhanVienRepo.GetAll().ToList();
            var maNhienVien = nhanVien.FirstOrDefault(t => t.TenNhanvien == O.tenNhanVien).MaNhanVien;
            PhieuBanHang order = new PhieuBanHang
            {
                SoPhieuBanHang = O.soPhieuBanHang,
                NgayBan = O.ngayBan,
                MaNhanVien = maNhienVien,
                Ghichu = O.ghiChu,
                TrangThai = true,
                TenKhachHang = O.tenKhachHang,
                SoDienThoai = O.soDienThoai,
                TongTien = O.tongTien,
                NgayChinhSua = DateTime.Now,
                ChiTietPhieuBanHangs = O.chiTietPhieuBanHang
            };
            await _phieuBanHangRepo.InsertAsync(order);
            // Lấy các mã hàng hóa để giảm số lượng => Lấy trong chi tiết phiếu bán hàng
            foreach(var item in order.ChiTietPhieuBanHangs)
            {
                _hangHoaBus.CapNhapHangHoaVaoBaoCaoTonKhiTaoPhieuBanHang(item.MaHangHoa, item.SoLuong, DateTime.Now.Month, DateTime.Now.Year);
                //Tìm trong csdl các hàng hóa có mã hàng hóa ở trên
                var hanghoa = _hangHoaRepo.Fetch(t => t.MaHangHoa == item.MaHangHoa).FirstOrDefault();
                //Trừ số lượng người nhập
                hanghoa.SoLuongTon = hanghoa.SoLuongTon - item.SoLuong;
                //Lưu lại
                await _hangHoaRepo.EditAsync(hanghoa);
            }
        }

        public IEnumerable<ChiTietPhieuBanHang> thongTinChiTietPhieuBanHangTheoMa(int soPhieuBanHang)
        {
            IQueryable<ChiTietPhieuBanHang> dsChiTietPhieuBanHang = _chiTietPhieuBanHangRepo.GetAll();

            var all = (from chitietphieubanhang in dsChiTietPhieuBanHang
                       join hanghoa in _hangHoaRepo.GetAll()
                       on chitietphieubanhang.MaHangHoa equals hanghoa.MaHangHoa
                       select new
                       {
                           SoPhieuBanHang = chitietphieubanhang.SoPhieuBanHang,
                           MaHangHoa = hanghoa.MaHangHoa,
                           SoLuong = chitietphieubanhang.SoLuong,
                           TenHangHoa = hanghoa.TenHangHoa,
                           DonViTinh = hanghoa.DonViTinh,
                           Gia = chitietphieubanhang.Gia,
                           ThanhTien=chitietphieubanhang.ThanhTien

                       }).AsEnumerable().Select(x => new ChiTietPhieuBanHang()
                       {
                           SoPhieuBanHang = x.SoPhieuBanHang,
                           MaHangHoa = x.MaHangHoa,
                           SoLuong = x.SoLuong,
                           Gia = x.Gia,
                           ThanhTien = x.ThanhTien

                       }).ToList();

            //Lấy thông tin chi tiết phiếu từ số phiếu kiểm kho
            var information = (from i in all
                               where (i.SoPhieuBanHang == soPhieuBanHang)
                               select i).ToList();
            //PhieuBanHangViewModel model = new PhieuBanHangViewModel();
            //model.chiTietPhieuBanHang = information;
            //Select * from all where soPhieuBanHang == soPhieuBanHang
            return information.ToList();
        }

        public IEnumerable<PhieuBanHangViewModel> thongTinPhieuBanHangTheoMa(int soPhieuBanHang)
        {
            IQueryable<PhieuBanHang> danhSachPhieuBanHang = _phieuBanHangRepo.GetAll();
            List<PhieuBanHangViewModel> all = new List<PhieuBanHangViewModel>();

            all = (from phieubanhang in danhSachPhieuBanHang
                   join nhanvien in _nhanVienRepo.GetAll()
                   on phieubanhang.MaNhanVien equals nhanvien.MaNhanVien
                   where (phieubanhang.SoPhieuBanHang.Equals(soPhieuBanHang))
                   select new
                   {
                       SoPhieuBanHang = phieubanhang.SoPhieuBanHang,
                       NgayBan = phieubanhang.NgayBan,
                       TenNhanVien = nhanvien.TenNhanvien,
                       TrangThai = phieubanhang.TrangThai,
                       ChuThich = phieubanhang.Ghichu,
                   }).AsEnumerable().Select(x => new PhieuBanHangViewModel()
                   {
                       soPhieuBanHang = x.SoPhieuBanHang,
                       ngayBan = x.NgayBan,
                       tenNhanVien = x.TenNhanVien,
                       trangThai = x.TrangThai,
                       ghiChu = x.ChuThich,
                   }).ToList();
            return all;
        }

        public async Task<object> Find(int ID)
        {
            return await _phieuBanHangRepo.GetByIdAsync(ID);
        }

        public async Task HuyPhieuBanHang(object editModel)
        {
            try
            {
                PhieuBanHang editPhieuBanHang = (PhieuBanHang)editModel;
                var phieuBanHang = dbContext.ChiTietPhieuBanHanges.Where(x => x.SoPhieuBanHang == editPhieuBanHang.SoPhieuBanHang);

                foreach (var i in phieuBanHang)
                {
                    _hangHoaBus.CapNhapHangHoaVaoBaoCaoTonKhiHuyPhieuBanHang(i.MaHangHoa, i.SoLuong, editPhieuBanHang.NgayBan.Month, editPhieuBanHang.NgayBan.Year);
                    _hangHoaBus.CapNhatHangHoaKhiXoaPhieuBanHang(i.MaHangHoa, i.SoLuong);
                }
                editPhieuBanHang.TrangThai = false;
                await _phieuBanHangRepo.EditAsync(editPhieuBanHang);
            }
            catch (Exception)
            {

            }

        }
        
    }

}