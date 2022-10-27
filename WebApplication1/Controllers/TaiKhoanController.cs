using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using KarmaModels.KarmaModels;
using WebApplication1.code;
using KarmaModels.Repository;
using KarmaModels;

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
            IRepository<KHACHHANG> khachhang = new Repository<KHACHHANG>();
            
            var account = new AccountModel().IdenAccount(acc.username, acc.password);
            if(account != null)
            {
                var kh = khachhang.GetById(account.MaKH);
                Session["UserLogin"] = kh;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Dang Nhap", "Tai Khoan");
            }
            
        }
    }
}