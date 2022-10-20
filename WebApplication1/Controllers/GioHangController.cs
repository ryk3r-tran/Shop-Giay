using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GioHang()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ThemVaoGioHang(CartItem cartItem)
        {

            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult ThanhToan()
        {
            return View();
        }

        public ActionResult XacNhanDonHang()
        {
            return View();
        }
    }
}