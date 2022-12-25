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


        // [Post] /TaiKhoan/verify
        [HttpPost]
        public ActionResult verify(LoginModel acc)
        {
            IRepository<KHACHHANG> khachhang = new Repository<KHACHHANG>();

            var account = new AccountModel().IdenAccount(acc.username, acc.password);
            if (account != null)
            {
                var kh = khachhang.GetById(account.MaKH);
                Session["UserLogin"] = kh;
                Session["Quyen"] = account.Quyen.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //ViewBag.LoginError = "Tài khoản hoặc mật khẩu không chính xác";
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(string HoTen, string Email, string DiaChi, string sdt, string TenDangNhap, string MatKhau, int MaKh, string XNMatKhau)
        {
            var db = new KarmaDBContext();
            KHACHHANG kh = new KHACHHANG();
            TAIKHOAN tk = new TAIKHOAN();
            if (XNMatKhau == MatKhau)
            {
                kh.TenKH = HoTen;
                kh.GioiTinh = "Nam";
                kh.DiaChi = DiaChi;
                kh.Email = Email;
                kh.Sdt = sdt;
                tk.MaKH = MaKh;
                tk.username = TenDangNhap;
                tk.pass = MatKhau;
                tk.Quyen = "khách";
                db.KHACHHANGs.Add(kh);
                db.TAIKHOANs.Add(tk);
                db.SaveChanges();
                return RedirectToAction("DangNhap");
            }
            else
            {
                return Json(new
                {
                    status = "Xác nhận mật khẩu không khớp",
                });


            }

        }
        
        
    }
}