using Business.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLWeb.Areas.Admin.Controllers
{
    public class BaoCaoPhieuChiController : BaseController
    {
        // GET: Admin/BaoCaoPhieuChi
        readonly BaoCaoTonKhoBusiness _baoCaoTonKhoBus = new BaoCaoTonKhoBusiness();
        readonly PhieuKiemKhoBusiness _phieuKiemKhoBus = new PhieuKiemKhoBusiness();
        readonly HangHoaBusiness _hangHoaBus = new HangHoaBusiness();
        readonly NhanVienBusiness _nhanVienBus = new NhanVienBusiness();
        readonly BaoCaoPhieuChiBusiness _baoChiPhieuBus = new BaoCaoPhieuChiBusiness();
        //
        // GET: /Admin/KiemKho/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.maNhanVien = _nhanVienBus.LoadMaNhanVien(HomeController.userName);
            ViewBag.tenNhanVien = _nhanVienBus.LoadTenNhanVien(HomeController.userName);
            ViewBag.soPhieuKiemKhoTuTang = _phieuKiemKhoBus.LoadSoPhieuKiemKho();
            ViewBag.danhSachHangHoa = new SelectList(_hangHoaBus.LoadSanhSachHangHoaKho(), "Value", "Text");
            return View();
        }

        public ActionResult LoadThongTinHangHoa(int id)
        {
            var result = _hangHoaBus.LayThongTinHangHoa(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListName(string q)
        {
            var data = _hangHoaBus.ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DanhSachBaoCaoPhieuChi(DateTime? date)
        {
            var listBaoCao = _baoChiPhieuBus.GetList(date);
            return View(listBaoCao);

        }

        public ActionResult ThongTinPhieuKiemKho(int id)
        {
            ViewBag.chiTietPhieuKiemKho = _phieuKiemKhoBus.thongTinChiTietPhieuKiemKhoTheoMa(id).ToList();
            ViewBag.phieuKiemKho = _phieuKiemKhoBus.thongTinPhieuKiemKhoTheoMa(id).ToList();
            return View();
        }
    }
}