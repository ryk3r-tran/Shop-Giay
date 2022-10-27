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
        
        public ActionResult Admin()
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
        public ActionResult ThemTK(TAIKHOAN tk1, KHACHHANG kh1, string check_DK)
        {
            if(kh1.GioiTinh == "option1")
            {
                kh1.GioiTinh = "Nam";
            }
            if (kh1.GioiTinh == "option2")
            {
                kh1.GioiTinh = "Nữ";
            }
            if (tk1.Quyen == "option1")
            {
                tk1.Quyen = "Quản lý";
            }
            if (tk1.Quyen == "option2")
            {
                tk1.Quyen = "Nhân viên";
            }
            if (tk1.Quyen == "option3")
            {
                tk1.Quyen = "Khách hàng";
            }


            _context.KHACHHANGs.Add(kh1);
            _context.TAIKHOANs.Add(tk1);
            

            _context.SaveChanges();

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