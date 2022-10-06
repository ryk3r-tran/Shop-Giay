using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class KiemTraDonHangController : Controller
    {
        // GET: KiemTraDonHang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KiemTraDonHang()
        {
            return View();
        }
    }
}