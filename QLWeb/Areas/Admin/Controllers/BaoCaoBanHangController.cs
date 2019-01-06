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
    public class BaoCaoBanHangController : BaseController
    {
        // GET: Admin/BaoCaoBanHang
        readonly BaoCaoBanHangBusiness _baoCaoBanHangBus = new BaoCaoBanHangBusiness();
        readonly BaoCaoTonKhoBusiness _baoCaoTonKhoBus = new BaoCaoTonKhoBusiness();
        readonly PhieuKiemKhoBusiness _phieuKiemKhoBus = new PhieuKiemKhoBusiness();
        readonly HangHoaBusiness _hangHoaBus = new HangHoaBusiness();
        readonly NhanVienBusiness _nhanVienBus = new NhanVienBusiness();
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

        public ActionResult DanhSachBaoCaoBanHang(string dateFrom, string dateTo)
        {
            var res = _baoCaoBanHangBus.GetListBaoCao(Convert.ToDateTime(dateFrom), Convert.ToDateTime(dateTo), HomeController.userName);
            HttpContext.Session["BaoCaoBanHang"] = res;
            return View(res);

        }

        public ActionResult XuatExcel()
        {
            var models = (List<BaoCaoBanHangViewModel>)HttpContext.Session["BaoCaoBanHang"];
            if (models == null) return View("Index");
            using (ExcelPackage pck = new ExcelPackage(new FileInfo(Server.MapPath("~/Templates/BaoCaoBanHang.xlsx"))))
            {
                var ws = pck.Workbook.Worksheets[1];

                for (var i = 0; i < models.Count; i++)
                {
                   
                    ws.Cells["A" + (i + 2)].Value = models[i].ngayBan;
                    ws.Cells["A" + (i + 2)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["A" + (i + 2)].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    ws.Cells["B" + (i + 2)].Value = models[i].soDonHang;
                    ws.Cells["B" + (i + 2)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["B" + (i + 2)].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    ws.Cells["C" + (i + 2)].Value = models[i].tongTien;
                    ws.Cells["C" + (i + 2)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["C" + (i + 2)].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                }
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition",
                                   $"attachment;  filename=BaoCaoBanHang_{DateTime.Now}.xlsx");
                System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
                var ms = new MemoryStream(pck.GetAsByteArray());
                HttpContext.Session["FileBaoCaoBanHang"] = ms;
                return File(ms, Response.ContentType);
            }
        }
        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

      

        public ActionResult ThongTinPhieuKiemKho(int id)
        {
            ViewBag.chiTietPhieuKiemKho = _phieuKiemKhoBus.thongTinChiTietPhieuKiemKhoTheoMa(id).ToList();
            ViewBag.phieuKiemKho = _phieuKiemKhoBus.thongTinPhieuKiemKhoTheoMa(id).ToList();
            return View();
        }
    }
}