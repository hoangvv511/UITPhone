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

namespace QLWeb.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        static HomeController curController;
        public static string userName = string.Empty;
        NhanVienBusiness _nhanVienBus = new NhanVienBusiness();
        ChucVuBusiness _chucVuBus = new ChucVuBusiness();

        public ActionResult Index()
        {
            curController = this;
            if (Session["Account"] != null && Session["Account"].ToString() == "Error")
            {
                TempData["notify"] = "Username hoặc Password không đúng!!!";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            string Username = f["username"].ToString();
            string Password = f["Password"].ToString();

            NhanVienViewModel account = _nhanVienBus.Login(Username, Md5Encode.EncodePassword(Password));

            if (account != null)
            {
                if (account.trangThai != true)
                {
                    TempData["notify"] = "Tài khoản của bạn đã bị khóa!!!";
                }
                else
                {
                    string aut = _nhanVienBus.Authority(account);
                    Decentralization(account.maNhanVien.ToString(), aut);
                    Session["Account"] = account;
                    userName = Username;
                }
            }
            else
            {
                TempData["notify"] = "Username hoặc Password không đúng!!!";
            }
            return RedirectToAction("Index");
        }

        //Tạo cookie khóa tài khoản nếu active = False
        public void Decentralization(string userName, string aut)
        {
            FormsAuthentication.Initialize();
            var ticket = new FormsAuthenticationTicket(1,
                                          userName,
                                          DateTime.Now,
                                          DateTime.Now.AddHours(180000),
                                          false,
                                          aut,
                                          FormsAuthentication.FormsCookiePath);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
            Response.Cookies.Add(cookie);
        }

        public ActionResult Logout()
        {
            Session["Account"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
                TempData["AlertType"] = "alert-success";
            else if (type == "warning")
                TempData["AlertType"] = "alert-warning";
            else if (type == "error")
                TempData["AlertType"] = "alert-danger";
        }

        [HttpGet]
        public async Task<ActionResult> UpdatePassword()
        {
            if (Session["Account"] != null)
            {
                ViewBag.employee = await _nhanVienBus.Find(((NhanVienViewModel)(Session["Account"])).maNhanVien);
                return View();
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<ActionResult> UpdatePassword(String matkhaumoi, string matkhaucu)
        {
            NhanVien editEmployee = (NhanVien)await _nhanVienBus.Find(((NhanVienViewModel)(Session["Account"])).maNhanVien);
            try
            {
                await _nhanVienBus.UpdatePassword(editEmployee, Md5Encode.EncodePassword(matkhaumoi));
                SetAlert("Bạn đã cập nhật mật khẩu thành công!!!", "success");
            }
            catch
            {
                SetAlert("Đã xảy ra lỗi! Bạn hãy cập nhật lại", "error");
                return RedirectToAction("UpdatePassword");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult CheckPassword(string matkhaucu)
        {
            var isDuplicate = false;
            var mk = Md5Encode.EncodePassword(matkhaucu).ToLower();

            foreach (var user in _nhanVienBus.GetAllPassword(((NhanVienViewModel)(Session["Account"])).maNhanVien))
            {
                if (user.PassWord.ToLower() != mk)
                    isDuplicate = true;
            }

            var jsonData = new { isDuplicate };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        //Lấy thanh menu của user
        public PartialViewResult GetMenu()
        {
            var menuModel = _chucVuBus.GetMenu(((NhanVienViewModel)Session["Account"]).maChucVu);
            ViewBag.listParent = _chucVuBus.GetListParent(((NhanVienViewModel)Session["Account"]).maChucVu);
            return PartialView("~/Areas/Admin/Views/PartitalView/MenuManagerPartial.cshtml", menuModel);
        }

    }
}