using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using KarmaModels;
using WebApplication1.code;

namespace WebApplication1.Controllers
{
    public class TaiKhoanController : Controller
    {
        
        // [GET] /TaiKhoan/DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }


        // [Post] /TaiKhoan/Verify
        [HttpPost]
        public ActionResult verify(LoginModel acc)
        {
            var username = acc.username;
            var password = acc.password;
            return View("DieuKhien", "Admin");
            
        }
    }
}