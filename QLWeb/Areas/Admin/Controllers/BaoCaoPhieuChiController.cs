using Business.Implements;
using Common.ViewModels;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLWeb.Areas.Admin.Controllers
{
    public class BaoCaoPhieuChiController : BaseController
    {
        // GET: Admin/BaoCaoPhieuChi
        readonly BaoCaoPhieuChiBusiness _baoCaoPhieuChiBus = new BaoCaoPhieuChiBusiness();
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
        public ActionResult DanhSachBaoCaoPhieuChi(string dateFrom, string dateTo)
        {
            var res = _baoCaoPhieuChiBus.GetListBaoCao(Convert.ToDateTime(dateFrom), Convert.ToDateTime(dateTo));
            HttpContext.Session["BaoCaoPhieuChi"] = res;

            return View(res);

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
        

        public ActionResult ThongTinPhieuKiemKho(int id)
        {
            ViewBag.chiTietPhieuKiemKho = _phieuKiemKhoBus.thongTinChiTietPhieuKiemKhoTheoMa(id).ToList();
            ViewBag.phieuKiemKho = _phieuKiemKhoBus.thongTinPhieuKiemKhoTheoMa(id).ToList();
            return View();
        }
        public ActionResult XuatExcel()
        {
            var models = (List<BaoCaoPhieuChiViewModel>)HttpContext.Session["BaoCaoPhieuChi"];
            if (models == null) return View("Index");
            using (ExcelPackage pck = new ExcelPackage(new FileInfo(Server.MapPath("~/Templates/BaoCaoPhieuChi.xlsx"))))
            {
                var ws = pck.Workbook.Worksheets[1];

                for (var i = 0; i < models.Count; i++)
                {

                    ws.Cells["A" + (i + 2)].Value = models[i].ngayChi;
                    ws.Cells["A" + (i + 2)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["A" + (i + 2)].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    ws.Cells["B" + (i + 2)].Value = models[i].soPhieuChi;
                    ws.Cells["B" + (i + 2)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["B" + (i + 2)].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    ws.Cells["C" + (i + 2)].Value = models[i].tongTien;
                    ws.Cells["C" + (i + 2)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["C" + (i + 2)].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                }
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition",
                                   $"attachment;  filename=BaoCaoPhieuChi_{DateTime.Now}.xlsx");
                System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
                var ms = new MemoryStream(pck.GetAsByteArray());
                HttpContext.Session["FileBaoCaoPhieuChi"] = ms;
                return File(ms, Response.ContentType);
            }
        }
    }
}