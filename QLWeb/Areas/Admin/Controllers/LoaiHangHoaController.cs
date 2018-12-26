using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Model;
using System.Web.Security;
using System.Net;
using System.Timers;
using Business.Implements;
using Common.ViewModels;
using System.Threading.Tasks;
using Common;
using Common.Functions;
using System.IO;
using PagedList;

namespace QLWeb.Areas.Admin.Controllers
{
    public class LoaiHangHoaController : Controller
    {
        readonly LoaiHangHoaBusiness _loaiHangHoaKhoBus = new LoaiHangHoaBusiness();

        // GET: Admin/LoaiHangHoa
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Admin/Detail
        public ActionResult Detail()
        {
            return View();
        }

        // GET: Admin/Edit
        public ActionResult Edit()
        {
            return View();
        }
    }
}