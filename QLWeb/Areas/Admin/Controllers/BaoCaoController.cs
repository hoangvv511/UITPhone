using Business.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLWeb.Areas.Admin.Controllers
{
    public class BaoCaoController : Controller
    {
        private BaoCaoHangHoaBusiness bus = new BaoCaoHangHoaBusiness();

        public BaoCaoController()
        {

        }


        // GET: Admin/BaoCao
        public ActionResult Index(string from, string to)
        {
            var fromDate = DateTime.Parse(from);
            var toDate = DateTime.Parse(to);


            return View();
        }
    }
}