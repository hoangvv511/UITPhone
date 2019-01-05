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
    public class BaoCaoTonKhoBusiness
    {
        QLWebDBEntities dbContext;
        private readonly BaoCaoTonKhoReponsitory _baoCaoTonKhoRepo;
        private readonly PhieuKiemKhoReponsitory _phieuKiemKhoRepo;
        private readonly PhieuXuatKhoReponsitory _phieuXuatKhoRepo;
        private readonly ChiTietPhieuXuatKhoReponsitory _chiTietPhieuXuatKho;
        private readonly ChiTietPhieuKiemKhoReponsitory _chiTietPhieuKiemKhoRepo;
        private readonly NhanVienReponsitory _nhanVienRepo;
        private readonly HangHoaReponsitory _hangHoaRepo;
        private readonly PhieuNhapReponsitory _phieuNhapRepo;
        private readonly PhieuBanHangReponsitory _phieuBanHangRepo;
        private readonly NhanVienBusiness _nhanVienBus;
        private readonly ChiTietPhieuNhapReponsitory _chitietPhieuNhapRepo;
        private readonly ChiTietPhieuBanHangReponsitory _chitietPhieuBanHangRepo;

        public BaoCaoTonKhoBusiness()
        {
            dbContext = new QLWebDBEntities();
            _phieuKiemKhoRepo = new PhieuKiemKhoReponsitory(dbContext);
            _nhanVienRepo = new NhanVienReponsitory(dbContext);
            _hangHoaRepo = new HangHoaReponsitory(dbContext);
            _chiTietPhieuKiemKhoRepo = new ChiTietPhieuKiemKhoReponsitory(dbContext);
            _nhanVienBus = new NhanVienBusiness();
            _phieuNhapRepo = new PhieuNhapReponsitory(dbContext);
            _phieuBanHangRepo = new PhieuBanHangReponsitory(dbContext);
            _chitietPhieuNhapRepo = new ChiTietPhieuNhapReponsitory(dbContext);
            _chitietPhieuBanHangRepo = new ChiTietPhieuBanHangReponsitory(dbContext);
        }

        public IList<BaoCaoTonKhoViewModel> GetListBaoCao(int thang, int nam)
        {
            IQueryable<HangHoa> danhSachHangHoa = _hangHoaRepo.GetAll();
            IQueryable<BaoCaoTonKho> danhSachBaoCaoTon = _baoCaoTonKhoRepo.GetAll();

            List<BaoCaoTonKhoViewModel> allForManager = new List<BaoCaoTonKhoViewModel>();

               
                if (DateTime.Now.Month == thang && DateTime.Now.Year == nam)
                {
                allForManager = (from hanghoa in danhSachHangHoa
                                 join baocaotonkho in danhSachBaoCaoTon on hanghoa.MaHangHoa equals baocaotonkho.MaHangHoa
                                 where (baocaotonkho.Thang == DateTime.Now.Month && baocaotonkho.Nam == DateTime.Now.Year)
                                 select new
                                 {
                                     MaBaoCaoTonKho = baocaotonkho.MaBaoCaoTonKho,
                                     Thang =baocaotonkho.Thang,
                                     Nam=baocaotonkho.Nam,
                                     MaHangHoa=baocaotonkho.MaHangHoa,
                                     SoLuongTonDau=baocaotonkho.SoLuongTonDau,
                                     SoLuongNhap=baocaotonkho.SoLuongNhap,
                                     SoLuongXuat=baocaotonkho.SoLuongXuat,
                                     SoLuongTonCuoi=baocaotonkho.SoLuongTonCuoi



                                     }).AsEnumerable().Select(x => new BaoCaoTonKhoViewModel()
                                     {
                                         maBaoCaoTonKho = x.MaBaoCaoTonKho,
                                         thang = x.Thang,
                                         nam = x.Nam,
                                         maHangHoa = x.MaHangHoa,
                                         soLuongTonDau = x.SoLuongTonDau,
                                         soLuongNhap=x.SoLuongNhap,
                                         soLuongXuat=x.SoLuongXuat,
                                         soLuongTonCuoi=x.SoLuongTonCuoi
                                     }).OrderByDescending(x => x.maBaoCaoTonKho).ToList();
                    return allForManager;
                }

            allForManager = (from hanghoa in danhSachHangHoa
                             join baocaotonkho in danhSachBaoCaoTon on hanghoa.MaHangHoa equals baocaotonkho.MaHangHoa
                             where (baocaotonkho.Thang == thang && baocaotonkho.Nam == nam)
                             select new
                             {
                                 MaBaoCaoTonKho = baocaotonkho.MaBaoCaoTonKho,
                                 Thang = baocaotonkho.Thang,
                                 Nam = baocaotonkho.Nam,
                                 MaHangHoa = baocaotonkho.MaHangHoa,
                                 SoLuongTonDau = baocaotonkho.SoLuongTonDau,
                                 SoLuongNhap = baocaotonkho.SoLuongNhap,
                                 SoLuongXuat = baocaotonkho.SoLuongXuat,
                                 SoLuongTonCuoi = baocaotonkho.SoLuongTonCuoi



                             }).AsEnumerable().Select(x => new BaoCaoTonKhoViewModel()
                             {
                                 maBaoCaoTonKho = x.MaBaoCaoTonKho,
                                 thang = x.Thang,
                                 nam = x.Nam,
                                 maHangHoa = x.MaHangHoa,
                                 soLuongTonDau = x.SoLuongTonDau,
                                 soLuongNhap = x.SoLuongNhap,
                                 soLuongXuat = x.SoLuongXuat,
                                 soLuongTonCuoi = x.SoLuongTonCuoi
                             }).OrderByDescending(x => x.maBaoCaoTonKho).ToList();
            return allForManager;

        }
        
        public async Task Create(PhieuNhapViewModel O)
        {
            var hangHoa = _hangHoaRepo.GetById(O.soPhieuNhap);
            //var chitietPhieuXuatKho = _chiTietPhieuXuatKho.Fetch(t => t.MaHangHoa == O.maHangHoa);
            BaoCaoTonKho report = new BaoCaoTonKho
            {
                Thang = O.ngayNhap.Month,
                Nam = O.ngayNhap.Year,
                MaHangHoa = O.maHangHoa,
                SoLuongTonDau = hangHoa.SoLuongTon,
                SoLuongNhap = O.soLuongNhap,
                SoLuongTonCuoi = hangHoa.SoLuongTon - O.soLuongNhap
            };

            await _baoCaoTonKhoRepo.InsertAsync(report);
        }

    }
}
