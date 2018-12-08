using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLWeb.Areas.Admin.Models;

namespace QLWeb.Areas.Admin.Controllers
{
    public class LogInController : Controller
    {
        // GET: Admin/LogIn
        public ActionResult Index()
        {
            return View(1);
        }

        //POST : LogIn
        [HttpPost]
        public ActionResult Index(LogInModel logIn)
        {
            var result = new LogInModel(logIn.UserName, Encryptor.MD5Hash(logIn.PassWord));
            int i = 1;
            string password = Encryptor.MD5Hash("admin");
            if (result.UserName == "admin" && result.PassWord == password)
            {
                i = 2;
            }
            else
            {
                i = 3;
            }

            return View(i);
        }
    }
}