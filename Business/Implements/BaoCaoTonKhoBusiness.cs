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
         private readonly HangHoaReponsitory _hangHoaRepo;
        private readonly NhanVienBusiness _nhanVienBus;



        public BaoCaoTonKhoBusiness()
        {
            dbContext = new QLWebDBEntities();
        
            _hangHoaRepo = new HangHoaReponsitory(dbContext);
       _baoCaoTonKhoRepo = new BaoCaoTonKhoReponsitory(dbContext);
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
                                     SoLuongTonCuoi=baocaotonkho.SoLuongTonCuoi,
                                     TenHangHoa=hanghoa.TenHangHoa,
                                     DonViTinh=hanghoa.DonViTinh



                                     }).AsEnumerable().Select(x => new BaoCaoTonKhoViewModel()
                                     {
                                         maBaoCaoTonKho = x.MaBaoCaoTonKho,
                                         thang = x.Thang,
                                         nam = x.Nam,
                                         maHangHoa = x.MaHangHoa,
                                         soLuongTonDau = x.SoLuongTonDau,
                                         soLuongNhap=x.SoLuongNhap,
                                         soLuongXuat=x.SoLuongXuat,
                                         soLuongTonCuoi=x.SoLuongTonCuoi,
                                         tenHangHoa=x.TenHangHoa,
                                         donViTinh=x.DonViTinh
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
                                 SoLuongTonCuoi = baocaotonkho.SoLuongTonCuoi,
                                 TenHangHoa=hanghoa.TenHangHoa,
                                 DonViTinh=hanghoa.DonViTinh


                             }).AsEnumerable().Select(x => new BaoCaoTonKhoViewModel()
                             {
                                 maBaoCaoTonKho = x.MaBaoCaoTonKho,
                                 thang = x.Thang,
                                 nam = x.Nam,
                                 maHangHoa = x.MaHangHoa,
                                 soLuongTonDau = x.SoLuongTonDau,
                                 soLuongNhap = x.SoLuongNhap,
                                 soLuongXuat = x.SoLuongXuat,
                                 soLuongTonCuoi = x.SoLuongTonCuoi,
                                 tenHangHoa=x.TenHangHoa,
                                 donViTinh=x.DonViTinh
                                 
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
