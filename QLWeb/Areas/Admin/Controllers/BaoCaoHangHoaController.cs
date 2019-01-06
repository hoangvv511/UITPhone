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
    public class BaoCaoHangHoaController : BaseController
    {
        readonly HangHoaBusiness _hangHoaBus = new HangHoaBusiness();
        readonly BaoCaoHangHoaBusiness _baoCaoHangHoaBus = new BaoCaoHangHoaBusiness();
        // GET: Admin/BaoCaoHangHoa
        public ActionResult Index()
        {
            ViewBag.danhSachHangHoa = new SelectList(_hangHoaBus.LoadSanhSachHangHoaKho(), "Value", "Text");
            return View();
        }
        public ActionResult DanhSachBaoCaoHangHoa(int? id)
        {
           
            var result = _baoCaoHangHoaBus.GetListBaoCao(id);
            HttpContext.Session["BaoCaoHangHoa"] = result;
            return View(result);
            
        }
        public ActionResult XuatExcel()
        {
            var models = (List<BaoCaoHangHoaViewModel>)HttpContext.Session["BaoCaoHangHoa"];
            if (models == null) return View("Index");
            using (ExcelPackage pck = new ExcelPackage(new FileInfo(Server.MapPath("~/Templates/BaoCaoHangHoa.xlsx"))))
            {
                var ws = pck.Workbook.Worksheets[1];

                for (var i = 0; i < models.Count; i++)
                {

                    ws.Cells["A" + (i + 2)].Value = models[i].maHangHoa;
                    ws.Cells["A" + (i + 2)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["A" + (i + 2)].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    ws.Cells["B" + (i + 2)].Value = models[i].tenHangHoa;
                    ws.Cells["B" + (i + 2)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["B" + (i + 2)].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    ws.Cells["C" + (i + 2)].Value = models[i].modelName;
                    ws.Cells["C" + (i + 2)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["C" + (i + 2)].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    ws.Cells["D" + (i + 2)].Value = models[i].tenLoaiHangHoa;
                    ws.Cells["D" + (i + 2)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["D" + (i + 2)].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    ws.Cells["E" + (i + 2)].Value = models[i].giaBan;
                    ws.Cells["E" + (i + 2)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["E" + (i + 2)].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    ws.Cells["F" + (i + 2)].Value = models[i].giamGia;
                    ws.Cells["F" + (i + 2)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["F" + (i + 2)].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    ws.Cells["G" + (i + 2)].Value = models[i].soLuongTon;
                    ws.Cells["G" + (i + 2)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["G" + (i + 2)].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);

                    

                }
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition",
                                   $"attachment;  filename=BaoCaoHangHoa_{DateTime.Now}.xlsx");
                System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
                var ms = new MemoryStream(pck.GetAsByteArray());
                HttpContext.Session["FileBaoCaoHangHoa"] = ms;
                return File(ms, Response.ContentType);
            }
        }
    }
}