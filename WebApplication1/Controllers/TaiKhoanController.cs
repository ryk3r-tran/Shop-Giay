using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TaiKhoanController : Controller
    {
        // [GET] TaiKhoan/DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }

        // [POST] TaiKhoan/verify
        [HttpPost]
    }
}