using KarmaModels.KarmaModels;
using KarmaModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        KarmaDBContext _context = new KarmaDBContext();
        // GET: Admin
        
        public ActionResult DieuKhien()
        {
            return View();
        }
        public ActionResult TatCaTaiKhoan()
        {
            var data = _context.TAIKHOANs.Include("KHACHHANG");
            return View(data.ToList());        
        }

        public ActionResult ThemTaiKhoan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemTK(Class1 tk1)
        {
            string HoTen = tk1.hoTen;
            string email = tk1.Email;
            string quyen = tk1.Quyen;
            return View();
        }

        public ActionResult ThongKe()
        {
            return View();
        }

        public ActionResult TatCaSanPham()
        {
            IRepository<SANPHAM> sanpham = new Repository<SANPHAM>();
            var data = sanpham.GetAll();
            return View(data);
        }

        public ActionResult ThemSanPham()
        {
            return View();
        }
    }
}