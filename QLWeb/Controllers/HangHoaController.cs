using Business.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLWeb.Controllers
{
    public class HangHoaController : Controller
    {
        readonly HangHoaBusiness _hangHoaBus = new HangHoaBusiness();

        // GET: HangHoa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChiTietSanPham(int id)
        {
            return View();
        }

        public ActionResult DanhSachSanPham(int id, int page = 1, int pageSize = 8)
        {
            return View();
        }

        public ActionResult SanPhamKhuyenMai(int page = 1, int pageSize = 8)
        {
            return View();
        }
    }
}