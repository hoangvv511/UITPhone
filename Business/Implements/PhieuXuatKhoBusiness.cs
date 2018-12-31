using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;
using Common.Functions;
using Data.Functions;
using Data.Implements;
using System.Data.Entity.Core.Objects;
using Business.Interfaces;
using System.Web.Mvc;
using Common.ViewModels;
using PagedList;
using System.Web.WebPages.Html;

namespace Business.Implements
{
    public class PhieuXuatKhoBusiness : IXuatKhoBusiness
    {
        private QLWebDBEntities _dbContext;
        private readonly PhieuXuatKhoReponsitory _phieuXuatKhoRepo;
        private readonly ChiTietPhieuXuatKhoReponsitory _chiTietPhieuXuatKhoRepo;
        private readonly NhanVienReponsitory _nhanVienRepo;
        private readonly HangHoaReponsitory _hangHoaRepo;
        private NhanVienBusiness _nhanVienBus;
        private HangHoaBusiness _hangHoaBus;

        public PhieuXuatKhoBusiness()
        {
            _dbContext = new QLWebDBEntities();
            _phieuXuatKhoRepo = new PhieuXuatKhoReponsitory(_dbContext);
            _nhanVienRepo = new NhanVienReponsitory(_dbContext);
            _hangHoaRepo = new HangHoaReponsitory(_dbContext);
            _chiTietPhieuXuatKhoRepo = new ChiTietPhieuXuatKhoReponsitory(_dbContext);
            _nhanVienBus = new NhanVienBusiness();
            _hangHoaBus = new HangHoaBusiness();
        }

        public IList<PhieuXuatKhoViewModel> SearchDanhSachPhieuXuatKho(string key, string trangThai, DateTime tungay, DateTime denngay, string userName)
        {
            IQueryable<PhieuXuatKho> danhSachPhieuXuatKho = _phieuXuatKhoRepo.GetAll();
            IQueryable<NhanVien> danhSachNhanVien = _nhanVienRepo.GetAll();
            List<PhieuXuatKhoViewModel> all = new List<PhieuXuatKhoViewModel>();
            List<PhieuXuatKhoViewModel> allForManager = new List<PhieuXuatKhoViewModel>();

            //Nếu là thủ kho
            if (_nhanVienBus.layMaChucVu(userName) == 5)
            {
                if ((!(tungay == default(DateTime))) && (!(denngay == default(DateTime))))
                {
                    allForManager = (from phieuxuat in danhSachPhieuXuatKho
                                     join nhanvien in danhSachNhanVien
                                     on phieuxuat.MaNhanVien equals nhanvien.MaNhanVien
                                     where (nhanvien.UserName.Equals(userName) && phieuxuat.NgayXuat >= tungay.Date && phieuxuat.NgayXuat <= denngay.Date)
                                     select new
                                     {
                                         SoPhieuXuatKho = phieuxuat.SoPhieuXuatKho,
                                         NgayNhap = phieuxuat.NgayXuat,
                                         TenNhanVien = nhanvien.TenNhanvien,
                                         TongTien = phieuxuat.TongTien,
                                         TrangThai = phieuxuat.TrangThai,
                                         LyDoXuat = phieuxuat.LyDoXuat,
                                     }).AsEnumerable().Select(x => new PhieuXuatKhoViewModel()
                                     {
                                         soPhieuXuatKho = x.SoPhieuXuatKho,
                                         ngayXuat = x.NgayNhap,
                                         tenNhanVien = x.TenNhanVien,
                                         tongTien = x.TongTien,
                                         trangThai = x.TrangThai,
                                         lyDoXuat = x.LyDoXuat,
                                     }).OrderByDescending(x => x.soPhieuXuatKho).ToList();

                    return allForManager;

                }
                if (!string.IsNullOrEmpty(key))
                {
                    all = (from phieuxuat in danhSachPhieuXuatKho
                           join nhanvien in danhSachNhanVien
                           on phieuxuat.MaNhanVien equals nhanvien.MaNhanVien
                           where (nhanvien.UserName.Equals(userName) && (
                                     phieuxuat.SoPhieuXuatKho.ToString().Equals(key)))
                           select new
                           {
                               SoPhieuXuatKho = phieuxuat.SoPhieuXuatKho,
                               NgayNhap = phieuxuat.NgayXuat,
                               TenNhanVien = nhanvien.TenNhanvien,
                               TongTien = phieuxuat.TongTien,
                               TrangThai = phieuxuat.TrangThai,
                               LyDoXuat = phieuxuat.LyDoXuat,

                           }).AsEnumerable().Select(x => new PhieuXuatKhoViewModel()
                           {
                               soPhieuXuatKho = x.SoPhieuXuatKho,
                               ngayXuat = x.NgayNhap,
                               tenNhanVien = x.TenNhanVien,
                               tongTien = x.TongTien,
                               trangThai = x.TrangThai,
                               lyDoXuat = x.LyDoXuat,
                           }).OrderByDescending(x => x.soPhieuXuatKho).ToList();

                    return all;

                }
                if (!string.IsNullOrEmpty(trangThai))
                {
                    all = (from phieuxuat in danhSachPhieuXuatKho
                           join nhanvien in danhSachNhanVien
                           on phieuxuat.MaNhanVien equals nhanvien.MaNhanVien
                           where (nhanvien.UserName.Equals(userName) && phieuxuat.TrangThai.ToString().Equals(trangThai))
                           select new
                           {
                               SoPhieuXuatKho = phieuxuat.SoPhieuXuatKho,
                               NgayNhap = phieuxuat.NgayXuat,
                               TenNhanVien = nhanvien.TenNhanvien,
                               TongTien = phieuxuat.TongTien,
                               TrangThai = phieuxuat.TrangThai,
                               LyDoXuat = phieuxuat.LyDoXuat,

                           }).AsEnumerable().Select(x => new PhieuXuatKhoViewModel()
                           {
                               soPhieuXuatKho = x.SoPhieuXuatKho,
                               ngayXuat = x.NgayNhap,
                               tenNhanVien = x.TenNhanVien,
                               tongTien = x.TongTien,
                               trangThai = x.TrangThai,
                               lyDoXuat = x.LyDoXuat,
                           }).OrderByDescending(x => x.soPhieuXuatKho).ToList();

                    return all;

                }

                all = (from phieuxuat in danhSachPhieuXuatKho
                       join nhanvien in danhSachNhanVien
                       on phieuxuat.MaNhanVien equals nhanvien.MaNhanVien
                       where (nhanvien.UserName.Equals(userName))
                       select new
                       {
                           SoPhieuXuatKho = phieuxuat.SoPhieuXuatKho,
                           NgayNhap = phieuxuat.NgayXuat,
                           TenNhanVien = nhanvien.TenNhanvien,
                           TongTien = phieuxuat.TongTien,
                           TrangThai = phieuxuat.TrangThai,
                           LyDoXuat = phieuxuat.LyDoXuat,

                       }).AsEnumerable().Select(x => new PhieuXuatKhoViewModel()
                       {
                           soPhieuXuatKho = x.SoPhieuXuatKho,
                           ngayXuat = x.NgayNhap,
                           tenNhanVien = x.TenNhanVien,
                           tongTien = x.TongTien,
                           trangThai = x.TrangThai,
                           lyDoXuat = x.LyDoXuat,
                       }).OrderByDescending(x => x.soPhieuXuatKho).ToList();

                return all;

            }
            else
            {
                if ((!(tungay == default(DateTime))) && (!(denngay == default(DateTime))))
                {
                    allForManager = (from phieuxuat in danhSachPhieuXuatKho
                                     join nhanvien in danhSachNhanVien
                                     on phieuxuat.MaNhanVien equals nhanvien.MaNhanVien
                                     where (phieuxuat.NgayXuat >= tungay.Date && phieuxuat.NgayXuat <= denngay.Date)
                                     select new
                                     {
                                         SoPhieuXuatKho = phieuxuat.SoPhieuXuatKho,
                                         NgayNhap = phieuxuat.NgayXuat,
                                         TenNhanVien = nhanvien.TenNhanvien,
                                         TongTien = phieuxuat.TongTien,
                                         TrangThai = phieuxuat.TrangThai,
                                         LyDoXuat = phieuxuat.LyDoXuat,

                                     }).AsEnumerable().Select(x => new PhieuXuatKhoViewModel()
                                     {
                                         soPhieuXuatKho = x.SoPhieuXuatKho,
                                         ngayXuat = x.NgayNhap,
                                         tenNhanVien = x.TenNhanVien,
                                         tongTien = x.TongTien,
                                         trangThai = x.TrangThai,
                                         lyDoXuat = x.LyDoXuat,
                                     }).OrderByDescending(x => x.soPhieuXuatKho).ToList();

                    return allForManager;

                }
                if (!string.IsNullOrEmpty(key))
                {
                    allForManager = (from phieuxuat in danhSachPhieuXuatKho
                                     join nhanvien in danhSachNhanVien
                                     on phieuxuat.MaNhanVien equals nhanvien.MaNhanVien
                                     where (phieuxuat.SoPhieuXuatKho.ToString().Equals(key))
                                     select new
                                     {
                                         SoPhieuXuatKho = phieuxuat.SoPhieuXuatKho,
                                         NgayNhap = phieuxuat.NgayXuat,
                                         TenNhanVien = nhanvien.TenNhanvien,
                                         TongTien = phieuxuat.TongTien,
                                         TrangThai = phieuxuat.TrangThai,
                                         LyDoXuat = phieuxuat.LyDoXuat,

                                     }).AsEnumerable().Select(x => new PhieuXuatKhoViewModel()
                                     {
                                         soPhieuXuatKho = x.SoPhieuXuatKho,
                                         ngayXuat = x.NgayNhap,
                                         tenNhanVien = x.TenNhanVien,
                                         tongTien = x.TongTien,
                                         trangThai = x.TrangThai,
                                         lyDoXuat = x.LyDoXuat,
                                     }).OrderByDescending(x => x.soPhieuXuatKho).ToList();

                    return allForManager;

                }
                if (!string.IsNullOrEmpty(trangThai))
                {
                    allForManager = (from phieuxuat in danhSachPhieuXuatKho
                                     join nhanvien in danhSachNhanVien
                                     on phieuxuat.MaNhanVien equals nhanvien.MaNhanVien
                                     where phieuxuat.TrangThai.ToString().Equals(trangThai)
                                     select new
                                     {
                                         SoPhieuXuatKho = phieuxuat.SoPhieuXuatKho,
                                         NgayNhap = phieuxuat.NgayXuat,
                                         TenNhanVien = nhanvien.TenNhanvien,
                                         TongTien = phieuxuat.TongTien,
                                         TrangThai = phieuxuat.TrangThai,
                                         LyDoXuat = phieuxuat.LyDoXuat,

                                     }).AsEnumerable().Select(x => new PhieuXuatKhoViewModel()
                                     {
                                         soPhieuXuatKho = x.SoPhieuXuatKho,
                                         ngayXuat = x.NgayNhap,
                                         tenNhanVien = x.TenNhanVien,
                                         tongTien = x.TongTien,
                                         trangThai = x.TrangThai,
                                         lyDoXuat = x.LyDoXuat,
                                     }).OrderByDescending(x => x.soPhieuXuatKho).ToList();

                    return allForManager;
                }

                allForManager = (from phieuxuat in danhSachPhieuXuatKho
                                 join nhanvien in danhSachNhanVien
                                 on phieuxuat.MaNhanVien equals nhanvien.MaNhanVien
                                 select new
                                 {
                                     SoPhieuXuatKho = phieuxuat.SoPhieuXuatKho,
                                     NgayNhap = phieuxuat.NgayXuat,
                                     TenNhanVien = nhanvien.TenNhanvien,
                                     TongTien = phieuxuat.TongTien,
                                     TrangThai = phieuxuat.TrangThai,
                                     LyDoXuat = phieuxuat.LyDoXuat,

                                 }).AsEnumerable().Select(x => new PhieuXuatKhoViewModel()
                                 {
                                     soPhieuXuatKho = x.SoPhieuXuatKho,
                                     ngayXuat = x.NgayNhap,
                                     tenNhanVien = x.TenNhanVien,
                                     tongTien = x.TongTien,
                                     trangThai = x.TrangThai,
                                     lyDoXuat = x.LyDoXuat,
                                 }).OrderByDescending(x => x.soPhieuXuatKho).ToList();

                return allForManager;

            }
        }
    }
}
