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
    public class BaoCaoBanHangBusiness
    {
        QLWebDBEntities dbContext;
        private readonly BaoCaoBanHangReponsitory _baoCaoBanHangRepo;
        private readonly PhieuBanHangReponsitory _phieuBanHangRepo;
        private readonly NhanVienReponsitory _nhanVienRepo;
        private NhanVienBusiness _nhanVienBus;

        public BaoCaoBanHangBusiness()
        {
            dbContext = new QLWebDBEntities();

            _nhanVienRepo = new NhanVienReponsitory(dbContext);
            _nhanVienBus = new NhanVienBusiness();
            _baoCaoBanHangRepo = new BaoCaoBanHangReponsitory(dbContext);
            _phieuBanHangRepo = new PhieuBanHangReponsitory(dbContext);
        }

        public IList<BaoCaoBanHangViewModel> GetListBaoCao(DateTime dateFrom, DateTime dateTo, string userName)
        {
            IQueryable<BaoCaoBanHang> danhSachBaoCaoBanHang = _baoCaoBanHangRepo.GetAll();
            IQueryable<PhieuBanHang> danhSachPhieuBanHang = _phieuBanHangRepo.GetAll();
            IQueryable<NhanVien> danhSachNhanVien = _nhanVienRepo.GetAll();
            List<BaoCaoBanHangViewModel> all = new List<BaoCaoBanHangViewModel>();
            List<BaoCaoBanHangViewModel> allForManager = new List<BaoCaoBanHangViewModel>();
            if (_nhanVienBus.layMaChucVu(userName) == 4)
            {

                if ((!(dateFrom == default(DateTime))) && (!(dateTo == default(DateTime))))
                {

                    all = (from phieubanhang in danhSachPhieuBanHang
                           join nhanvien in danhSachNhanVien
                           on phieubanhang.MaNhanVien equals nhanvien.MaNhanVien
                           where (nhanvien.MaNhanVien.Equals(userName) && phieubanhang.NgayBan >= dateFrom.Date && phieubanhang.NgayBan <= dateTo.Date)
                           group phieubanhang by phieubanhang.NgayBan into pgroup
                           select new
                           {
                               NgayBan = pgroup.Key,
                               SoDonHang = pgroup.Count(),
                               TongTien = pgroup.Sum(phieubanhang => phieubanhang.TongTien)

                           }).AsEnumerable().Select(x => new BaoCaoBanHangViewModel()
                           {
                               ngayBan = x.NgayBan,
                               soDonHang = x.SoDonHang,
                               tongTien = x.TongTien,

                           }).OrderByDescending(x => x.soDonHang).ToList();
                    return all;
                }

                all = (from phieubanhang in danhSachPhieuBanHang
                       join nhanvien in danhSachNhanVien
                       on phieubanhang.MaNhanVien equals nhanvien.MaNhanVien
                       where (nhanvien.MaNhanVien.Equals(userName))
                       group phieubanhang by phieubanhang.NgayBan into pgroup
                       select new
                       {
                           NgayBan = pgroup.Key,
                           SoDonHang = pgroup.Count(),
                           TongTien = pgroup.Sum(phieubanhang => phieubanhang.TongTien)

                       }).AsEnumerable().Select(x => new BaoCaoBanHangViewModel()
                       {
                           ngayBan = x.NgayBan,
                           soDonHang = x.SoDonHang,
                           tongTien = x.TongTien,

                       }).OrderByDescending(x => x.soDonHang).ToList();
                return all;

            }
            else
            {
                if ((!(dateFrom == default(DateTime))) && (!(dateTo == default(DateTime))))
                {

                    allForManager = (from phieubanhang in danhSachPhieuBanHang

                                     where (phieubanhang.NgayBan >= dateFrom.Date && phieubanhang.NgayBan <= dateTo.Date)
                                     group phieubanhang by phieubanhang.NgayBan into pgroup
                                     select new
                                     {
                                         NgayBan = pgroup.Key,
                                         SoDonHang = pgroup.Count(),
                                         TongTien = pgroup.Sum(phieubanhang => phieubanhang.TongTien)

                                     }).AsEnumerable().Select(x => new BaoCaoBanHangViewModel()
                                     {
                                         ngayBan = x.NgayBan,
                                         soDonHang = x.SoDonHang,
                                         tongTien = x.TongTien,

                                     }).OrderByDescending(x => x.soDonHang).ToList();

                    return allForManager;
                }

                allForManager = (from phieubanhang in danhSachPhieuBanHang

                                 where (phieubanhang.NgayBan >= dateFrom.Date && phieubanhang.NgayBan <= dateTo.Date)
                                 group phieubanhang by phieubanhang.NgayBan into pgroup
                                 select new
                                 {
                                     NgayBan = pgroup.Key,
                                     SoDonHang = pgroup.Count(),
                                     TongTien = pgroup.Sum(phieubanhang => phieubanhang.TongTien)

                                 }).AsEnumerable().Select(x => new BaoCaoBanHangViewModel()
                                 {
                                     ngayBan = x.NgayBan,
                                     soDonHang = x.SoDonHang,
                                     tongTien = x.TongTien,

                                 }).OrderByDescending(x => x.soDonHang).ToList();

                return allForManager;

            } 
        }
    }
}
