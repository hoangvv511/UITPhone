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
    public class BaoCaoHangHoaBusiness
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
        private readonly LoaiHangHoaReponsitory _loaiHangHoaRepo;

        public BaoCaoHangHoaBusiness()
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
            _baoCaoTonKhoRepo = new BaoCaoTonKhoReponsitory(dbContext);
            _loaiHangHoaRepo = new LoaiHangHoaReponsitory(dbContext);
        }

        public IList<BaoCaoHangHoaViewModel> GetListBaoCao(int? maHangHoa)
        {
            IQueryable<HangHoa> danhSachHangHoa = _hangHoaRepo.GetAll();
            IQueryable<LoaiHangHoa> danhSachLoaiHangHoa = _loaiHangHoaRepo.GetAll();
             
            List<BaoCaoHangHoaViewModel> allForManager = new List<BaoCaoHangHoaViewModel>();

           
            allForManager = (from hanghoa in danhSachHangHoa
                             join loaihanghoa in danhSachLoaiHangHoa on hanghoa.MaLoaiHangHoa equals loaihanghoa.MaLoaiHangHoa
                             where (hanghoa.MaHangHoa== maHangHoa)
                            // where (hanghoa.MaHangHoa.Equals(maHangHoa))
                             select new
                             {
                                 TenHangHoa = hanghoa.TenHangHoa,
                                 ModelName = hanghoa.ModelName,
                                 TenLoaiHangHoa = loaihanghoa.TenLoaiHangHoa,
                                 GiaBan = hanghoa.GiaBan,
                                 GiamGia = hanghoa.GiamGia,
                                 TrangThai = hanghoa.TrangThai,
                                 SoLuongTon = hanghoa.SoLuongTon,
                                 MaHangHoa = hanghoa.MaHangHoa



                             }).AsEnumerable().Select(x => new BaoCaoHangHoaViewModel()
                             {
                                 tenHangHoa = x.TenHangHoa,
                                  modelName = x.ModelName,
                                 tenLoaiHangHoa = x.TenLoaiHangHoa,
                                 giaBan = x.GiaBan,
                                 giamGia = x.GiamGia,
                                 trangThai = x.TrangThai,
                                 soLuongTon = x.SoLuongTon,
                                 maHangHoa = x.MaHangHoa
                             }).OrderByDescending(x => x.maHangHoa).ToList();
           
            return allForManager;

        }



    }
}
