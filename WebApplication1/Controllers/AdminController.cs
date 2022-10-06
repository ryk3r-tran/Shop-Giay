using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DieuKhien()
        {
            return View();
        }
        public ActionResult TatCaTaiKhoan()
        {
            return View();
        }

        public ActionResult ThemTaiKhoan()
        {
            return View();
        }

        public ActionResult ThongKe()
        {
            return View();
        }

        public ActionResult TatCaSanPham()
        {
            return View();
        }

        public ActionResult ThemSanPham()
        {
            return View();
        }
    }
}