using KarmaModels.KarmaModels;
using KarmaModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.App_Start;

namespace WebApplication1.Controllers
{
    //[Authorization(Quyen = "admin")]
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
        public ActionResult ThemTK()
        {
            
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


        [HttpPost]
        public ActionResult getSanPhamById(string id)
        {
            int i = Int32.Parse(id);
            IRepository<SANPHAM> sanpham = new Repository<SANPHAM>();
            var result = sanpham.GetById(i);
            return Json(new {
                TenSP = result.TenSP,
                SoLuongTong = result.SoLuongTong,
                DonGia = result.DonGia,
                MoTa = result.MoTa,
                NgayCapNhat = result.NgayCapNhat,
            });
        }

    }
}