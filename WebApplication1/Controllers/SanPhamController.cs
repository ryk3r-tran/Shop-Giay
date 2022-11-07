using KarmaModels.KarmaModels;
using KarmaModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class SanPhamController : Controller
    {
        KarmaDBContext _context = new KarmaDBContext();
        // GET: SanPham
        public ActionResult DanhSachSanPham()
        {
            IRepository<SANPHAM> sanpham = new Repository<SANPHAM>();
            var data = sanpham.GetAll();
            return View(data);
        }
        [HttpPost]
        public ActionResult Find(string search_input)
        {
            var search_name = search_input.ToLower();
            var listProd = _context.SANPHAMs.Where(s => s.TenSP.ToLower().Contains(search_name)).ToList();
            return RedirectToAction("DanhSachSanPham", "SanPham",listProd);
        }

        public ActionResult SanPhamChiTiet()
        {
            return View();
        }
    }
}