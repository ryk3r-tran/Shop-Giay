using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KarmaModels.KarmaModels;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
       public ActionResult Test()
        {

            List<TinhThanh> listTinh = new List<TinhThanh>();
            TinhThanh ttp;
            ttp = new TinhThanh();
            ttp.Ma = 1;
            ttp.Ten = "ha noi";
            listTinh.Add(ttp);

            ttp = new TinhThanh();
            ttp.Ma = 2;
            ttp.Ten = "hcm";
            listTinh.Add(ttp);

            ttp = new TinhThanh();
            ttp.Ma = 3;
            ttp.Ten = "da nang";
            listTinh.Add(ttp);

            ViewBag.TinhThanh = new SelectList(listTinh, "Ma", "Ten");
            return View();

        }
        [HttpPost]
        public ActionResult Test(int gioitinh)
        {

            return View();
        }
    }
}